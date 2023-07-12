using System;
using System.Threading;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "I am a NotifyIcon Balloon";
            notifyIcon1.BalloonTipTitle = "Welcome Message";
            notifyIcon1.ShowBalloonTip(2000);
        }

        private void features1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void item1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Item 1 selected message. Click Yes to Close", "I have a title", MessageBoxButtons.YesNoCancel);
            if (d == DialogResult.Yes)
            {
                Close();
            }
        }

        private void doNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Form2()).Show();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void importeraOchMarkeraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime date1 = new DateTime(2023, 07, 15);
            DateTime date2 = new DateTime(2023, 07, 16);
            DateTime date3 = new DateTime(2023, 07, 17);
            DateTime date4 = new DateTime(2023, 07, 18);
            //monthCalendar1.AddBoldedDate(date1);
            //monthCalendar1.AddBoldedDate(date2);
            DateTime[] markedDates = { date1, date2, date3, date4 };
            monthCalendar1.BoldedDates = markedDates;
            //remove highlight:
            //monthCalendar1.RemoveAllBoldedDates();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
            string value = "test1";
            if (value == "test1")
            {
                //statusStrip1.Text = "OK"; //apparently not working
                toolStripStatusLabel1.Text = "OK!"; //need a label, progress bar etc to be set first

            }

            switch (value)
            {
                case "test1":
                    //did not find where this is written to: Console.WriteLine("Value is equal to test1");
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.BalloonTipText = value;
                    notifyIcon1.BalloonTipTitle = "Welcome " + value;
                    notifyIcon1.ShowBalloonTip(2000);
                    break;
                case "test2":
                    Console.WriteLine("Value is nicely test2!");

                    break;
            }
        }

        private void statusStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var myArray = new List<int> { 2, 4, 5, 56, 67, 7 };
            foreach (int i in myArray)
            {
                //didn't get this: Console.Write($"{i}");
                label1.Text = i.ToString();
                //didn't work: Thread.Sleep(1000);
                MessageBox.Show(i.ToString());
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var myArray = new List<int> { 2, 4, 5, 56, 67, 7 };
            foreach (int i in myArray)
            {
                await ExampleMethodAsync();
                textBox1.Text = i.ToString();
            }
        }
        private async Task ExampleMethodAsync()
        {
            await Task.Delay(1000);
        }
    }
}