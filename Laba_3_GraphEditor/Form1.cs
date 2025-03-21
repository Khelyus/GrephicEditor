using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static Laba_3_GraphEditor.Work;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Laba_3_GraphEditor
{
    public partial class Form1 : Form
    {


        private Rectangle selectionRectangle = Rectangle.Empty;


        private List<Bitmap> undoList = new List<Bitmap>();
        private Stack<Bitmap> redoList = new Stack<Bitmap>();

        private bool isRectDrawing = false;
        private Pen rectPen = new Pen(Color.LightGray, 5);

        private bool isDrawingShape = false;
        bool IsMouseDown;

        bool check_paint;

        public Point StartPoint, EndPoint;

        Bitmap bitMap;
        Graphics g;
        bool isDrawing = false;
        Point PointX, PointY; //px py
        Pen pen = new Pen(Color.Black, 1);
        Pen erase = new Pen(Color.White, 10);
        int x, y, sX, sY, cX, cY;

        private bool isSelecting = false;


        private Rectangle selectedArea;
        private Bitmap copiedArea;

       

        private bool isDragging = false;
        private Point dragStartLocation;
        private Point dragOffset;

        private bool isDraggingCopiedArea = false;
        ColorDialog colorDialog = new ColorDialog();
        Color New_Color;
        public enum TOOL
        {
            SELECT,
            PEN,
            ERASER,
            FILLCOLOR,
            LINE,
            ELLIPSE,
            RECTANGLE,
        }
        public TOOL curTool = TOOL.PEN;

      

        public Form1()
        {
            InitializeComponent();



            //PanelDraw.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            DoubleBuffered = true;
            g = PanelDraw.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
            bitMap = new Bitmap(PanelDraw.Width, PanelDraw.Height);
            g = Graphics.FromImage(bitMap);
            g.Clear(Color.White);
            PanelDraw.Image = bitMap;
            pen.Width = (float)PenWidth.Value;
            IsMouseDown = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PanelDraw.Location = new Point((this.ClientSize.Width - PanelDraw.Width) / 2, (this.ClientSize.Height - PanelDraw.Height) / 2);
            IsMouseDown = false;
        }

        private void PanelDraw_MouseDown(object sender, MouseEventArgs e)
        {


            check_paint = true;
            PointY = e.Location;

            cX = e.X;
            cY = e.Y;
            StartPoint = e.Location;
            EndPoint = e.Location;
            IsMouseDown = true;

            if (curTool == TOOL.SELECT)
            {
                isSelecting = true;
                selectionRectangle.Location = e.Location;
            }
            if (curTool == TOOL.ERASER)
            {
                PointY = e.Location;
            }
            if (copiedArea != null)
            {
                
                if (e.X >= dragOffset.X && e.X <= dragOffset.X + copiedArea.Width &&
                    e.Y >= dragOffset.Y && e.Y <= dragOffset.Y + copiedArea.Height)
                {
                    isDraggingCopiedArea = true;
                    dragStartLocation = e.Location;
                }
            }
        }


        private void PanelDraw_MouseMove(object sender, MouseEventArgs e)
        {

            if (check_paint)
            {
                if (curTool == TOOL.PEN)
                {
                    PointX = e.Location;
                    g.DrawLine(pen, PointX, PointY);
                    PointY = PointX;
                }
                if (curTool == TOOL.ERASER)
                {
                    PointX = e.Location;
                    g.DrawLine(erase, PointX, PointY);
                    PointY = PointX;
                }
                if (curTool == TOOL.ERASER)
                {
                    PointX = e.Location;
                    g.DrawLine(erase, PointX, PointY);
                    PointY = PointX;
                }
            }
            PanelDraw.Refresh();

            x = e.X;
            y = e.Y;
            sX = e.X - cX;
            sY = e.Y - cY;


            if (isSelecting && curTool == TOOL.SELECT)
            {
             
                selectionRectangle.Location = new Point(Math.Min(e.X, selectionRectangle.X), Math.Min(e.Y, selectionRectangle.Y));
                selectionRectangle.Width = Math.Abs(e.X - selectionRectangle.X);
                selectionRectangle.Height = Math.Abs(e.Y - selectionRectangle.Y);
            }

            if (isDraggingCopiedArea && copiedArea != null)
            {
                
                dragOffset.X = e.X - dragStartLocation.X;
                dragOffset.Y = e.Y - dragStartLocation.Y;
            }
        }
        private void PanelDraw_MouseUp(object sender, MouseEventArgs e)
        {
            check_paint = false;
            sX = Math.Abs(x - cX);
            sY = Math.Abs(y - cY);

            if (curTool == TOOL.ELLIPSE)
                g.DrawEllipse(pen, cX, cY, sX, sY);
            if (curTool == TOOL.RECTANGLE)
                g.DrawRectangle(pen, Math.Min(cX, x), Math.Min(cY, y), sX, sY);
            if (curTool == TOOL.LINE)
                g.DrawLine(pen, cX, cY, x, y);


            if (curTool == TOOL.ERASER)
            {
                AddToUndoList();
            }
            IsMouseDown = false;


            if (isSelecting)
            {
                isSelecting = false;
                
            }
           
            AddToUndoList();

            isDragging = false;
            dragStartLocation = Point.Empty;
            dragOffset = Point.Empty;
            isDraggingCopiedArea = false;

        }


        private void PanelDraw_Paint(object sender, PaintEventArgs e)
        {



            Graphics graphics = e.Graphics;
            if (check_paint)
            {
                sX = Math.Abs(x - cX);
                sY = Math.Abs(y - cY);

                if (curTool == TOOL.ELLIPSE)
                    graphics.DrawEllipse(pen, cX, cY, sX, sY);
                if (curTool == TOOL.RECTANGLE)
                    graphics.DrawRectangle(pen, Math.Min(cX, x), Math.Min(cY, y), sX, sY);
                if (curTool == TOOL.LINE)
                    graphics.DrawLine(pen, cX, cY, x, y);

              


            }

            if (copiedArea != null)
            {
             
                e.Graphics.DrawImage(copiedArea, dragOffset);
            }

            if (isSelecting && curTool == TOOL.SELECT)
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, selectionRectangle);
                }
            }


        }


        private void ButtonPaint_Click(object sender, EventArgs e)
        {
            curTool = TOOL.PEN;
        }

        private void toolStripLine_Click(object sender, EventArgs e)
        {
            curTool = TOOL.LINE;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            curTool = TOOL.ELLIPSE;

        }



        private void buttonChangeColorPen_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            New_Color = colorDialog.Color;
            PanelDraw.BackColor = colorDialog.Color;
            pen.Color = colorDialog.Color;

        }

        private void toolStripRectangle_Click(object sender, EventArgs e)
        {
            curTool = TOOL.RECTANGLE;
        }

        private void PenWidth_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = (float)PenWidth.Value;
            erase.Width = (float)PenWidth.Value;
        }

        private void ÒÓı‡ÌËÚ¸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image Files (*.jpg)|*.jpg|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImageFormat imageFormat = ImageFormat.Jpeg;
                bitMap.Save(saveFileDialog.FileName, imageFormat);
            }
        }

        private void ÒÓı‡ÌËÚ¸ ‡ÍToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image Files (*.jpg)|*.jpg|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImageFormat imageFormat = ImageFormat.Jpeg;
                bitMap.Save(saveFileDialog.FileName, imageFormat);
            }
        }

        private void toolStripFullColor_Click(object sender, EventArgs e)
        {
            curTool = TOOL.FILLCOLOR;
        }

        private void PanelDraw_MouseClick(object sender, MouseEventArgs e)
        {
            if (curTool == TOOL.FILLCOLOR)
            {
                Point point = set_Point(PanelDraw, e.Location);
                Fill(bitMap, point.X, point.Y, New_Color);
            }

        }
        static Point set_Point(PictureBox pb, Point pt)
        {
            float px = 1f * pb.Width / pb.Width;
            float py = 1f * pb.Height / pb.Height;
            return new Point((int)(pt.X * px), (int)(pt.Y * py));
        }


        public void Fill(Bitmap bm, int x, int y, Color New_Clr)
        {
            Color Old_Color = bm.GetPixel(x, y);
            Stack<Point> pixel = new Stack<Point>();
            pixel.Push(new Point(x, y));
            bm.SetPixel(x, y, New_Clr);
            if (Old_Color == New_Clr) { return; }

            while (pixel.Count > 0)
            {
                Point pt = (Point)pixel.Pop();
                if (pt.X > 0 && pt.Y > 0 && pt.X < bm.Width - 1 && pt.Y < bm.Height - 1)
                {
                    Validate(bm, pixel, pt.X - 1, pt.Y, Old_Color, New_Clr);
                    Validate(bm, pixel, pt.X, pt.Y - 1, Old_Color, New_Clr);
                    Validate(bm, pixel, pt.X + 1, pt.Y, Old_Color, New_Clr);
                    Validate(bm, pixel, pt.X, pt.Y + 1, Old_Color, New_Clr);
                }
            }
        }

        private void Validate(Bitmap bm, Stack<Point> sp, int x, int y, Color Old_Color, Color New_Color)
        {
            Color cx = bm.GetPixel(x, y);
            if (cx == Old_Color)
            {
                sp.Push(new Point(x, y));
                bm.SetPixel(x, y, New_Color);
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            curTool = TOOL.SELECT;
         //  isSelecting = false; // Reset the selection state
            //PanelDraw.Invalidate();
     
        }



        private void buttonPaste_Click(object sender, EventArgs e)
        {
            /* if (copiedArea != null)
             {
                 Bitmap transparentImage = MakeTransparent(copiedArea, Color.White, 5);

                 using (Graphics g = Graphics.FromImage(bitMap))
                 {
                     g.DrawImage(transparentImage, new Point(0, 0));
                 }

                 PanelDraw.Image = bitMap;
                 PanelDraw.Refresh();
             }*/

            if (copiedArea != null)
            {
                Bitmap transparentImage = MakeTransparent(copiedArea, Color.White, 5);

                using (Graphics g = Graphics.FromImage(bitMap))
                {
                    g.DrawImage(transparentImage, new Point(0, 0));
                }

                PanelDraw.Image = bitMap;
                PanelDraw.Refresh();

                
                isDragging = true;
                dragStartLocation = Point.Empty;
                dragOffset = new Point(0,0); 
            }

        }

        private Bitmap MakeTransparent(Bitmap bitmap, Color color, int tolerance)
        {
            Bitmap transparentImage = new Bitmap(bitmap);

            for (int i = 0; i < transparentImage.Width; i++)
            {
                for (int j = 0; j < transparentImage.Height; j++)
                {
                    var currentColor = transparentImage.GetPixel(i, j);
                    if (Math.Abs(color.R - currentColor.R) < tolerance &&
                        Math.Abs(color.G - currentColor.G) < tolerance &&
                        Math.Abs(color.B - currentColor.B) < tolerance)
                    {
                        transparentImage.SetPixel(i, j, Color.Transparent);
                    }
                }
            }

            return transparentImage;
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {

            if (selectionRectangle != Rectangle.Empty)
            {
                copiedArea = new Bitmap(selectionRectangle.Width, selectionRectangle.Height);
                using (Graphics g = Graphics.FromImage(copiedArea))
                {
                    g.DrawImage(bitMap, new Rectangle(0, 0, copiedArea.Width, copiedArea.Height),
                        selectionRectangle, GraphicsUnit.Pixel);
                }
            }


        }

        private void PanelDraw_Click(object sender, EventArgs e)
        {

        }



        private void buttonCancel_Click(object sender, EventArgs e)
        {

            UndoLastAction();



        }

        private void AddToUndoList()
        {
            Bitmap currentState = new Bitmap(PanelDraw.Image);
            undoList.Add(currentState);
        }
        private void UndoLastAction()
        {


            if (undoList.Count > 0)
            {
                Bitmap currentState = new Bitmap(PanelDraw.Image);
                redoList.Push(currentState); 
                Bitmap previousState = undoList[undoList.Count - 1];
                undoList.RemoveAt(undoList.Count - 1);
                PanelDraw.Image = previousState;
                PanelDraw.Refresh(); 
                g = Graphics.FromImage(PanelDraw.Image); 
            }


        }


        private void buttonForward_Click(object sender, EventArgs e)
        {

            if (redoList.Count > 0)
            {
                Bitmap previousState = redoList.Pop();
                undoList.Add(previousState);
                PanelDraw.Image = previousState;
                PanelDraw.Refresh(); 
                g = Graphics.FromImage(PanelDraw.Image); 
            }

        }

        private void ÓÚÍ˚Ú¸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg;*.jpeg;*.jpe;*.jfif;*.png|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    Image image = Image.FromFile(openFileDialog.FileName);
                    bitMap = new Bitmap(image);
                    g = Graphics.FromImage(bitMap);
                    //g.Clear(Color.White);
                    PanelDraw.Image = bitMap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Œ¯Ë·Í‡: " + ex.Message, "Œ¯Ë·Í‡", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ÌÓ‚˚ÈToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "’ÓÚËÚÂ ÒÓı‡ÌËÚ¸?";
            string title = "«‡Í˚Ú¸";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                StripMenuSaveAs.PerformClick();
            }
            else
            {
                g.Clear(Color.White);
                PanelDraw.Image = bitMap;
                curTool = TOOL.SELECT;
            }
        }

        private void ‚˚ıÓ‰ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ÓÚÏÂÌ‡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UndoLastAction();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void toolStripEraser_Click(object sender, EventArgs e)
        {
            curTool = TOOL.ERASER;
        }
    }
}


