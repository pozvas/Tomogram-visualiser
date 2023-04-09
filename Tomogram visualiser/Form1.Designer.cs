namespace Tomogram_visualiser
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
            button1 = new Button();
            glControl1 = new OpenTK.GLControl();
            trackBar1 = new TrackBar();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            trackBar2 = new TrackBar();
            trackBar3 = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(865, 546);
            button1.Name = "button1";
            button1.Size = new Size(111, 23);
            button1.TabIndex = 0;
            button1.Text = "Открыть";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // glControl1
            // 
            glControl1.BackColor = Color.Black;
            glControl1.Location = new Point(13, 22);
            glControl1.Margin = new Padding(4, 3, 4, 3);
            glControl1.Name = "glControl1";
            glControl1.Size = new Size(963, 505);
            glControl1.TabIndex = 1;
            glControl1.VSync = false;
            glControl1.Paint += glControl1_Paint;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(509, 546);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(350, 45);
            trackBar1.TabIndex = 2;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(407, 533);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(59, 19);
            radioButton1.TabIndex = 3;
            radioButton1.TabStop = true;
            radioButton1.Text = "Quads";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(407, 558);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(63, 19);
            radioButton2.TabIndex = 4;
            radioButton2.TabStop = true;
            radioButton2.Text = "Texture";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(406, 584);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(86, 19);
            radioButton3.TabIndex = 5;
            radioButton3.TabStop = true;
            radioButton3.Text = "Quads Strip";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(13, 533);
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(169, 45);
            trackBar2.TabIndex = 6;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(204, 533);
            trackBar3.Maximum = 255;
            trackBar3.Minimum = 10;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(186, 45);
            trackBar3.TabIndex = 7;
            trackBar3.Value = 10;
            trackBar3.Scroll += trackBar3_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 576);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 8;
            label1.Text = "Min";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(261, 576);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 9;
            label2.Text = "Width";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(646, 587);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 10;
            label3.Text = "Слои";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(997, 610);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(trackBar3);
            Controls.Add(trackBar2);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(trackBar1);
            Controls.Add(glControl1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private OpenTK.GLControl glControl1;
        private TrackBar trackBar1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private TrackBar trackBar2;
        private TrackBar trackBar3;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}