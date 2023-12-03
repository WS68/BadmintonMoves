namespace BadmMoves
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
            components = new System.ComponentModel.Container();
            panelTop = new Panel();
            label2 = new Label();
            buttonStart = new Button();
            label1 = new Label();
            comboBoxServe = new ComboBox();
            comboBoxGame = new ComboBox();
            panelBottom = new Panel();
            panelRight = new Panel();
            buttonZone = new Button();
            buttonRedo = new Button();
            buttonUndo = new Button();
            groupBox1 = new GroupBox();
            radioButtonStrike = new RadioButton();
            radioButtonMove = new RadioButton();
            panelMain = new Panel();
            timer = new System.Windows.Forms.Timer(components);
            panelTop.SuspendLayout();
            panelRight.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(label2);
            panelTop.Controls.Add(buttonStart);
            panelTop.Controls.Add(label1);
            panelTop.Controls.Add(comboBoxServe);
            panelTop.Controls.Add(comboBoxGame);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(800, 46);
            panelTop.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(138, 16);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 4;
            label2.Text = "Serve";
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(281, 12);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 3;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 15);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "Game";
            // 
            // comboBoxServe
            // 
            comboBoxServe.FormattingEnabled = true;
            comboBoxServe.Items.AddRange(new object[] { "#1", "#2", "#3", "#4" });
            comboBoxServe.Location = new Point(179, 12);
            comboBoxServe.Name = "comboBoxServe";
            comboBoxServe.Size = new Size(80, 23);
            comboBoxServe.TabIndex = 1;
            // 
            // comboBoxGame
            // 
            comboBoxGame.FormattingEnabled = true;
            comboBoxGame.Items.AddRange(new object[] { "MD", "WD", "XD", "MXD" });
            comboBoxGame.Location = new Point(55, 12);
            comboBoxGame.Name = "comboBoxGame";
            comboBoxGame.Size = new Size(64, 23);
            comboBoxGame.TabIndex = 0;
            // 
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 386);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(800, 64);
            panelBottom.TabIndex = 1;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(buttonZone);
            panelRight.Controls.Add(buttonRedo);
            panelRight.Controls.Add(buttonUndo);
            panelRight.Controls.Add(groupBox1);
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new Point(679, 46);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(121, 340);
            panelRight.TabIndex = 2;
            // 
            // buttonZone
            // 
            buttonZone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonZone.Location = new Point(18, 101);
            buttonZone.Name = "buttonZone";
            buttonZone.Size = new Size(75, 23);
            buttonZone.TabIndex = 3;
            buttonZone.Text = "Zones";
            buttonZone.UseVisualStyleBackColor = true;
            // 
            // buttonRedo
            // 
            buttonRedo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonRedo.Location = new Point(18, 305);
            buttonRedo.Name = "buttonRedo";
            buttonRedo.Size = new Size(75, 23);
            buttonRedo.TabIndex = 2;
            buttonRedo.Text = "Redo >>";
            buttonRedo.UseVisualStyleBackColor = true;
            // 
            // buttonUndo
            // 
            buttonUndo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonUndo.Location = new Point(18, 270);
            buttonUndo.Name = "buttonUndo";
            buttonUndo.Size = new Size(75, 23);
            buttonUndo.TabIndex = 1;
            buttonUndo.Text = "<< Undo";
            buttonUndo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.Controls.Add(radioButtonStrike);
            groupBox1.Controls.Add(radioButtonMove);
            groupBox1.Location = new Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(112, 76);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "On Double Click";
            // 
            // radioButtonStrike
            // 
            radioButtonStrike.AutoSize = true;
            radioButtonStrike.Location = new Point(6, 22);
            radioButtonStrike.Name = "radioButtonStrike";
            radioButtonStrike.Size = new Size(54, 19);
            radioButtonStrike.TabIndex = 1;
            radioButtonStrike.TabStop = true;
            radioButtonStrike.Text = "Strike";
            radioButtonStrike.UseVisualStyleBackColor = true;
            // 
            // radioButtonMove
            // 
            radioButtonMove.AutoSize = true;
            radioButtonMove.Location = new Point(6, 47);
            radioButtonMove.Name = "radioButtonMove";
            radioButtonMove.Size = new Size(55, 19);
            radioButtonMove.TabIndex = 0;
            radioButtonMove.TabStop = true;
            radioButtonMove.Text = "Move";
            radioButtonMove.UseVisualStyleBackColor = true;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 46);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(679, 340);
            panelMain.TabIndex = 3;
            panelMain.Paint += panelMain_Paint;
            panelMain.MouseClick += panelMain_MouseClick;
            panelMain.MouseDoubleClick += panelMain_MouseDoubleClick;
            // 
            // timer
            // 
            timer.Interval = 200;
            timer.Tick += timer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelMain);
            Controls.Add(panelRight);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Name = "Form1";
            Text = "Badminton Moves";
            Load += Form1_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelRight.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Panel panelBottom;
        private Panel panelRight;
        private Panel panelMain;
        private System.Windows.Forms.Timer timer;
        private Label label2;
        private Button buttonStart;
        private Label label1;
        private ComboBox comboBoxServe;
        private ComboBox comboBoxGame;
        private GroupBox groupBox1;
        private RadioButton radioButtonStrike;
        private RadioButton radioButtonMove;
        private Button buttonZone;
        private Button buttonRedo;
        private Button buttonUndo;
    }
}