namespace WinFormsApp1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            features1ToolStripMenuItem = new ToolStripMenuItem();
            item1ToolStripMenuItem = new ToolStripMenuItem();
            item2ToolStripMenuItem = new ToolStripMenuItem();
            doNowToolStripMenuItem = new ToolStripMenuItem();
            butDoThisRatherToolStripMenuItem = new ToolStripMenuItem();
            importeraOchMarkeraToolStripMenuItem = new ToolStripMenuItem();
            monthCalendar1 = new MonthCalendar();
            notifyIcon1 = new NotifyIcon(components);
            button1 = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripSplitButton1 = new ToolStripSplitButton();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            button2 = new Button();
            label1 = new Label();
            button3 = new Button();
            textBox1 = new TextBox();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { features1ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(958, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // features1ToolStripMenuItem
            // 
            features1ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { item1ToolStripMenuItem, item2ToolStripMenuItem, importeraOchMarkeraToolStripMenuItem });
            features1ToolStripMenuItem.Name = "features1ToolStripMenuItem";
            features1ToolStripMenuItem.Size = new Size(90, 24);
            features1ToolStripMenuItem.Text = "Features 1";
            features1ToolStripMenuItem.Click += features1ToolStripMenuItem_Click;
            // 
            // item1ToolStripMenuItem
            // 
            item1ToolStripMenuItem.Name = "item1ToolStripMenuItem";
            item1ToolStripMenuItem.Size = new Size(291, 26);
            item1ToolStripMenuItem.Text = "Item 1";
            item1ToolStripMenuItem.Click += item1ToolStripMenuItem_Click;
            // 
            // item2ToolStripMenuItem
            // 
            item2ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { doNowToolStripMenuItem, butDoThisRatherToolStripMenuItem });
            item2ToolStripMenuItem.Name = "item2ToolStripMenuItem";
            item2ToolStripMenuItem.Size = new Size(291, 26);
            item2ToolStripMenuItem.Text = "Item 2";
            // 
            // doNowToolStripMenuItem
            // 
            doNowToolStripMenuItem.Name = "doNowToolStripMenuItem";
            doNowToolStripMenuItem.Size = new Size(211, 26);
            doNowToolStripMenuItem.Text = "Open Form 2";
            doNowToolStripMenuItem.Click += doNowToolStripMenuItem_Click;
            // 
            // butDoThisRatherToolStripMenuItem
            // 
            butDoThisRatherToolStripMenuItem.Name = "butDoThisRatherToolStripMenuItem";
            butDoThisRatherToolStripMenuItem.Size = new Size(211, 26);
            butDoThisRatherToolStripMenuItem.Text = "But Do This rather";
            // 
            // importeraOchMarkeraToolStripMenuItem
            // 
            importeraOchMarkeraToolStripMenuItem.Name = "importeraOchMarkeraToolStripMenuItem";
            importeraOchMarkeraToolStripMenuItem.Size = new Size(291, 26);
            importeraOchMarkeraToolStripMenuItem.Text = "Importera och markera datum";
            importeraOchMarkeraToolStripMenuItem.Click += importeraOchMarkeraToolStripMenuItem_Click;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(236, 156);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 1;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipText = "Hi I am a BalloonTipText";
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // button1
            // 
            button1.Location = new Point(766, 64);
            button1.Name = "button1";
            button1.Size = new Size(156, 53);
            button1.TabIndex = 2;
            button1.Text = "Give value 1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripSplitButton1, toolStripStatusLabel2, toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 517);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(958, 26);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            statusStrip1.ItemClicked += statusStrip1_ItemClicked_1;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(151, 20);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripSplitButton1
            // 
            toolStripSplitButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripSplitButton1.Image = (Image)resources.GetObject("toolStripSplitButton1.Image");
            toolStripSplitButton1.ImageTransparentColor = Color.Magenta;
            toolStripSplitButton1.Name = "toolStripSplitButton1";
            toolStripSplitButton1.Size = new Size(39, 24);
            toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(151, 20);
            toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 18);
            toolStripProgressBar1.Click += toolStripProgressBar1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(766, 156);
            button2.Name = "button2";
            button2.Size = new Size(156, 61);
            button2.TabIndex = 4;
            button2.Text = "Run foreach";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(766, 233);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 5;
            label1.Text = "label1";
            // 
            // button3
            // 
            button3.Location = new Point(766, 294);
            button3.Name = "button3";
            button3.Size = new Size(156, 69);
            button3.TabIndex = 6;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(766, 386);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(156, 27);
            textBox1.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 543);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(statusStrip1);
            Controls.Add(button1);
            Controls.Add(monthCalendar1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem features1ToolStripMenuItem;
        private ToolStripMenuItem item1ToolStripMenuItem;
        private ToolStripMenuItem item2ToolStripMenuItem;
        private ToolStripMenuItem doNowToolStripMenuItem;
        private ToolStripMenuItem butDoThisRatherToolStripMenuItem;
        private MonthCalendar monthCalendar1;
        private ToolStripMenuItem importeraOchMarkeraToolStripMenuItem;
        private NotifyIcon notifyIcon1;
        private Button button1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripProgressBar toolStripProgressBar1;
        private Button button2;
        private Label label1;
        private Button button3;
        private TextBox textBox1;
    }
}