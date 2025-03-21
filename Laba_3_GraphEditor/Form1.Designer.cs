namespace Laba_3_GraphEditor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            новыйToolStripMenuItem = new ToolStripMenuItem();
            ToolStripSave = new ToolStripMenuItem();
            StripMenuSaveAs = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            ещеToolStripMenuItem = new ToolStripMenuItem();
            отменаToolStripMenuItem = new ToolStripMenuItem();
            впередToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            ButtonPaint = new ToolStripButton();
            toolStripLine = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripRectangle = new ToolStripButton();
            toolStripFullColor = new ToolStripButton();
            toolStripEraser = new ToolStripButton();
            buttonChangeColorPen = new Button();
            colorDialog1 = new ColorDialog();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            PanelDraw = new PictureBox();
            PenWidth = new NumericUpDown();
            label1 = new Label();
            buttonSelect = new Button();
            buttonCopy = new Button();
            buttonPaste = new Button();
            buttonCancel = new Button();
            buttonForward = new Button();
            panel1 = new Panel();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PanelDraw).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PenWidth).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, ещеToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1027, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { новыйToolStripMenuItem, ToolStripSave, StripMenuSaveAs, открытьToolStripMenuItem, выходToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // новыйToolStripMenuItem
            // 
            новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            новыйToolStripMenuItem.Size = new Size(216, 26);
            новыйToolStripMenuItem.Text = "Новый";
            новыйToolStripMenuItem.Click += новыйToolStripMenuItem_Click;
            // 
            // ToolStripSave
            // 
            ToolStripSave.Name = "ToolStripSave";
            ToolStripSave.ShortcutKeys = Keys.Control | Keys.S;
            ToolStripSave.Size = new Size(216, 26);
            ToolStripSave.Text = "Сохранить";
            ToolStripSave.Click += сохранитьToolStripMenuItem_Click;
            // 
            // StripMenuSaveAs
            // 
            StripMenuSaveAs.Name = "StripMenuSaveAs";
            StripMenuSaveAs.Size = new Size(216, 26);
            StripMenuSaveAs.Text = "Сохранить как";
            StripMenuSaveAs.Click += сохранитьКакToolStripMenuItem_Click;
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(216, 26);
            открытьToolStripMenuItem.Text = "Открыть";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(216, 26);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // ещеToolStripMenuItem
            // 
            ещеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { отменаToolStripMenuItem, впередToolStripMenuItem });
            ещеToolStripMenuItem.Name = "ещеToolStripMenuItem";
            ещеToolStripMenuItem.Size = new Size(51, 24);
            ещеToolStripMenuItem.Text = "Еще";
            // 
            // отменаToolStripMenuItem
            // 
            отменаToolStripMenuItem.Name = "отменаToolStripMenuItem";
            отменаToolStripMenuItem.Size = new Size(145, 26);
            отменаToolStripMenuItem.Text = "Отмена";
            отменаToolStripMenuItem.Click += отменаToolStripMenuItem_Click;
            // 
            // впередToolStripMenuItem
            // 
            впередToolStripMenuItem.Name = "впередToolStripMenuItem";
            впередToolStripMenuItem.Size = new Size(145, 26);
            впередToolStripMenuItem.Text = "Вперед";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { ButtonPaint, toolStripLine, toolStripButton2, toolStripRectangle, toolStripFullColor, toolStripEraser });
            toolStrip1.Location = new Point(0, 28);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1027, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // ButtonPaint
            // 
            ButtonPaint.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ButtonPaint.Image = (Image)resources.GetObject("ButtonPaint.Image");
            ButtonPaint.ImageTransparentColor = Color.Magenta;
            ButtonPaint.Name = "ButtonPaint";
            ButtonPaint.Size = new Size(29, 24);
            ButtonPaint.Text = "Карандаш";
            ButtonPaint.Click += ButtonPaint_Click;
            // 
            // toolStripLine
            // 
            toolStripLine.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripLine.Image = (Image)resources.GetObject("toolStripLine.Image");
            toolStripLine.ImageTransparentColor = Color.Magenta;
            toolStripLine.Name = "toolStripLine";
            toolStripLine.Size = new Size(29, 24);
            toolStripLine.Text = "Линия";
            toolStripLine.Click += toolStripLine_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(29, 24);
            toolStripButton2.Text = "Круг";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // toolStripRectangle
            // 
            toolStripRectangle.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripRectangle.Image = (Image)resources.GetObject("toolStripRectangle.Image");
            toolStripRectangle.ImageTransparentColor = Color.Magenta;
            toolStripRectangle.Name = "toolStripRectangle";
            toolStripRectangle.Size = new Size(29, 24);
            toolStripRectangle.Text = "Прямоугольник";
            toolStripRectangle.Click += toolStripRectangle_Click;
            // 
            // toolStripFullColor
            // 
            toolStripFullColor.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripFullColor.Image = (Image)resources.GetObject("toolStripFullColor.Image");
            toolStripFullColor.ImageTransparentColor = Color.Magenta;
            toolStripFullColor.Name = "toolStripFullColor";
            toolStripFullColor.Size = new Size(29, 24);
            toolStripFullColor.Text = "Заливка";
            toolStripFullColor.Click += toolStripFullColor_Click;
            // 
            // toolStripEraser
            // 
            toolStripEraser.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripEraser.Image = (Image)resources.GetObject("toolStripEraser.Image");
            toolStripEraser.ImageTransparentColor = Color.Magenta;
            toolStripEraser.Name = "toolStripEraser";
            toolStripEraser.Size = new Size(29, 24);
            toolStripEraser.Text = "toolStripButton1";
            toolStripEraser.Click += toolStripEraser_Click;
            // 
            // buttonChangeColorPen
            // 
            buttonChangeColorPen.Location = new Point(3, 6);
            buttonChangeColorPen.Name = "buttonChangeColorPen";
            buttonChangeColorPen.Size = new Size(94, 26);
            buttonChangeColorPen.TabIndex = 3;
            buttonChangeColorPen.Text = "ЦВЕТ";
            buttonChangeColorPen.UseVisualStyleBackColor = true;
            buttonChangeColorPen.Click += buttonChangeColorPen_Click;
            // 
            // PanelDraw
            // 
            PanelDraw.Anchor = AnchorStyles.None;
            PanelDraw.BackColor = Color.Transparent;
            PanelDraw.Location = new Point(103, 146);
            PanelDraw.Name = "PanelDraw";
            PanelDraw.Size = new Size(806, 412);
            PanelDraw.TabIndex = 4;
            PanelDraw.TabStop = false;
            PanelDraw.Click += PanelDraw_Click;
            PanelDraw.Paint += PanelDraw_Paint;
            PanelDraw.MouseClick += PanelDraw_MouseClick;
            PanelDraw.MouseDown += PanelDraw_MouseDown;
            PanelDraw.MouseMove += PanelDraw_MouseMove;
            PanelDraw.MouseUp += PanelDraw_MouseUp;
            // 
            // PenWidth
            // 
            PenWidth.Location = new Point(181, 5);
            PenWidth.Name = "PenWidth";
            PenWidth.Size = new Size(150, 27);
            PenWidth.TabIndex = 5;
            PenWidth.ValueChanged += PenWidth_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(103, 9);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 6;
            label1.Text = "Толщина";
            label1.Click += label1_Click;
            // 
            // buttonSelect
            // 
            buttonSelect.Location = new Point(337, 3);
            buttonSelect.Name = "buttonSelect";
            buttonSelect.Size = new Size(94, 30);
            buttonSelect.TabIndex = 7;
            buttonSelect.Text = "Выбрать";
            buttonSelect.UseVisualStyleBackColor = true;
            buttonSelect.Click += buttonSelect_Click;
            // 
            // buttonCopy
            // 
            buttonCopy.Location = new Point(437, 5);
            buttonCopy.Name = "buttonCopy";
            buttonCopy.Size = new Size(104, 30);
            buttonCopy.TabIndex = 8;
            buttonCopy.Text = "Копировать";
            buttonCopy.UseVisualStyleBackColor = true;
            buttonCopy.Click += buttonCopy_Click;
            // 
            // buttonPaste
            // 
            buttonPaste.Location = new Point(547, 8);
            buttonPaste.Name = "buttonPaste";
            buttonPaste.Size = new Size(94, 30);
            buttonPaste.TabIndex = 9;
            buttonPaste.Text = "Вставить";
            buttonPaste.UseVisualStyleBackColor = true;
            buttonPaste.Click += buttonPaste_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(647, 8);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(93, 30);
            buttonCancel.TabIndex = 10;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonForward
            // 
            buttonForward.Location = new Point(746, 8);
            buttonForward.Name = "buttonForward";
            buttonForward.Size = new Size(94, 30);
            buttonForward.TabIndex = 11;
            buttonForward.Text = "Вперед";
            buttonForward.UseVisualStyleBackColor = true;
            buttonForward.Click += buttonForward_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonChangeColorPen);
            panel1.Controls.Add(buttonCancel);
            panel1.Controls.Add(buttonForward);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(PenWidth);
            panel1.Controls.Add(buttonPaste);
            panel1.Controls.Add(buttonSelect);
            panel1.Controls.Add(buttonCopy);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(1027, 41);
            panel1.TabIndex = 12;
            panel1.Paint += panel1_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1027, 623);
            Controls.Add(panel1);
            Controls.Add(PanelDraw);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PanelDraw).EndInit();
            ((System.ComponentModel.ISupportInitialize)PenWidth).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStrip toolStrip1;
        private ToolStripButton ButtonPaint;
        private ToolStripButton toolStripLine;
        private ToolStripButton toolStripButton2;
        private Button buttonChangeColorPen;
        private ColorDialog colorDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private PictureBox PanelDraw;
        private NumericUpDown PenWidth;
        private ToolStripButton toolStripRectangle;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem ToolStripSave;
        private ToolStripMenuItem StripMenuSaveAs;
        private ToolStripButton toolStripFullColor;
        private Label label1;
        private Button buttonSelect;
        private Button buttonCopy;
        private Button buttonPaste;
        private Button buttonCancel;
        private Button buttonForward;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem новыйToolStripMenuItem;
        private ToolStripMenuItem ещеToolStripMenuItem;
        private ToolStripMenuItem отменаToolStripMenuItem;
        private ToolStripMenuItem впередToolStripMenuItem;
        private Panel panel1;
        private ToolStripButton toolStripEraser;
    }
}
