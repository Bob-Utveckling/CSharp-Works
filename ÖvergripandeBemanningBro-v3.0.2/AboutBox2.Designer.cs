namespace ÖvergripandeBemanningBro_v3._0._2
{
    partial class AboutBox2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(216, 35);
            label1.Name = "label1";
            label1.Size = new Size(238, 20);
            label1.TabIndex = 0;
            label1.Text = "Övergripande Bemanning Bro App";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(216, 79);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 1;
            label2.Text = "Version 3.0.2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(216, 126);
            label3.Name = "label3";
            label3.Size = new Size(326, 20);
            label3.TabIndex = 2;
            label3.Text = "Written by: Bob Lotfabadi bob.lotfabadi@ale.se";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(216, 184);
            label4.Name = "label4";
            label4.Size = new Size(95, 20);
            label4.TabIndex = 3;
            label4.Text = "Ale Kommun";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(216, 248);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(340, 158);
            textBox1.TabIndex = 4;
            textBox1.Text = "This application bridges \"Time Care Multi Access\" and \"Microsoft Shifts\" for the purpose of personnel schedule accessibility and planning.";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.AleLogo;
            pictureBox1.Location = new Point(37, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(110, 152);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // AboutBox2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 435);
            Controls.Add(pictureBox1);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutBox2";
            Padding = new Padding(12, 14, 12, 14);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "AboutBox2";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private PictureBox pictureBox1;
    }
}
