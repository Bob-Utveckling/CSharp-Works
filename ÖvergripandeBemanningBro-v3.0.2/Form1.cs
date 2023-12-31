using ÖvergripandeBemanningBro_v3._0._2.Model;
using System;
using System.Windows.Forms;

namespace ÖvergripandeBemanningBro_v3._0._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolStripProgressBar1.Visible = false;
        }
        string fileThatWasFed = "";

        List<Personnel> okPersonnelInFile = new List<Personnel>();
        List<Personnel> notOkPersonnelInFile = new List<Personnel>();
        string fileLocation = "";
        string fileName = "";
        string language = "sv";
        List<SchedItem> okSchedItems = new List<SchedItem>();
        List<SchedItem> notOkSchedItems = new List<SchedItem>();
        List<Note> notes = new List<Note>();
        List<Note> unclearNotes = new List<Note>();

        public void updateLabel(string text)
        {
            toolStripStatusLabel1.Text = text;
        }

        private void button1_Click_visaPersonalLista(object sender, EventArgs e)
        {
            var personnelForm = new Form2();
            personnelForm.Show();
        }

        private void button3_Click_valjFil(object sender, EventArgs e)
        {

            //set the path to Downloads for the request after:
            string path = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            path = Path.Combine(path, "Downloads");
            toolStripStatusLabel1.Text = "Väntar...";
            toolStripProgressBar1.Visible = true;


            var dlg = new OpenFileDialog()
            {
                InitialDirectory = path,
                DefaultExt = "csv",
                //Filter = "csv files (*.csv)|*.csv|Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*",
                Title = "Välj 'Tjänstgöringslista' som du tidigare sparade på Multi Access.",
                CheckFileExists = true,
                CheckPathExists = true,
            };
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                string message = "Det behövs att du väljer Tjänstgöringslista för importering av alla personals arbetspass under viss period.";
                string title = "Tjänstgöringslista behövs";
                MessageBox.Show(message, title);
                updateLabel("Redo");

            }
            else
            {
                fileThatWasFed = dlg.FileName;
                toolStripStatusLabel1.Text = "Fil mottagen.";
                var files = File.ReadAllLines(fileThatWasFed);
                //MessageBox.Show("Length of file: " + files.Length.ToString());
                var tuple = excel_ReadTheCsvFileAndPrepareToCreateTheExcelFile.prepare(dlg.FileName, toolStripStatusLabel1, toolStripProgressBar1);
                tabControl1.SelectedIndex = 1;

                List<DateTime> calendarDates = tuple.Item1;
                //highlightCalendarDates(tuple.Item1);
                monthCalendar1.RemoveAllBoldedDates();
                for (int c = 0; c < calendarDates.Count; c++)
                { monthCalendar1.AddBoldedDate(calendarDates[c]); }
                monthCalendar1.UpdateBoldedDates();

                //MessageBox.Show(string.Join(",", calendarDates.ToArray()));
                calendarLabelBox.Text = string.Join(",", calendarDates.ToArray()).Length > 35 ?
                    string.Join(",", calendarDates.ToArray()).Substring(0, 35) + "..." :
                    string.Join(",", calendarDates.ToArray()).Length > 15 ?
                    string.Join(",", calendarDates.ToArray()).Substring(0, 15) + "..." :
                    "";



                okPersonnelInFile = tuple.Item2;
                notOkPersonnelInFile = tuple.Item3;
                dataGridView1.DataSource = okPersonnelInFile;
                dataGridView2.DataSource = notOkPersonnelInFile;

                okSchedItems = tuple.Item4;
                notOkSchedItems = tuple.Item5;
                dataGridView3.DataSource = okSchedItems;
                dataGridView4.DataSource = notOkSchedItems;

                notes = tuple.Item6;
                dataGridView5Notes.DataSource = notes;
                label4Notes.Text = $"{notes.Count} Anteckningar övanpå dagarna";

                unclearNotes = tuple.Item7;
                dataGridView5UnclearNotes.DataSource = unclearNotes;
                checkBox1.Text = $"Tillsätt {unclearNotes.Count} anteckningar övanpå dagarna också:";

                label4OkPersonal.Text = okPersonnelInFile.Count + " Personal som kommer finnas i färdiga filen:";
                label5NotOkPersonal.Text = notOkPersonnelInFile.Count + " Personal som inte hittades i databasen.";
                label6OkSchema.Text = okSchedItems.Count + " Schema som ska tillsättas i  den nya exporterade filen:";
                label7NotOkSchema.Text = notOkSchedItems.Count + " Schema som inte kommer tillsättas i  den nya exporterade filen:";
                //MessageBox.Show(fileThatWasFed.ToString());
                label4FileNameArbetarMed.Text = fileThatWasFed.ToString();
                toolStripStatusLabel1.Text = $"Det finns {okSchedItems.Count} stycken arbetspass som kan tillsättas i din ny fil, " + notes.Count + " anteckningar, " + unclearNotes.Count + " \"möjliga\" anteckningar om du väljer dem för tillsättning.";

            }

        }

        private void button4_Click_InformationStammer(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;

            //get file path
            fileLocation = folderLocationTextBox.Text;
            //get file name
            fileName = fileLocationTextBox.Text;
            //get language
            switch (languageComboBox.Text)
            {
                case "Exporterings språk":
                case "Svenska":
                    language = "sv";
                    break;
                case "Engelska":
                    language = "en";
                    break;
            }
            //schedItems and okPersonnelInFile is preset
            if (okSchedItems.Count > 0)
            {
                //doing a check to see if unclearNotes should be sent to generate function or not
                List<Note> unclearNotesToSend = new List<Note>();
                if (checkBox1.Checked)
                {
                    unclearNotesToSend = unclearNotes;
                }
                else
                {
                    unclearNotesToSend.Clear();
                }
                var result = excel_CreateTheExcelFile.generate(okSchedItems, okPersonnelInFile, notes, unclearNotesToSend, fileLocation, fileName, language);
                string smallDetails = "Arbetade med schemat som fanns i filen:\n " + fileThatWasFed +
                    "\nSpråk: " + language +
                    "\nAntal ok schema = " + okSchedItems.Count +
                    "\nAntal ej ok schema = " + notOkSchedItems.Count +
                    "\nAntal anteckningar = " + notes.Count;
                if (checkBox1.Checked) { smallDetails += "\nAntal extra anteckningar = " + unclearNotes.Count; }
                else
                {
                    smallDetails += "\nAntal ej tillsatt extra anteckningar = " + unclearNotes.Count;
                }
                smallDetails += "\nAntal okej personal = " + okPersonnelInFile.Count +
                "\nAntal ej okej personal = " + notOkPersonnelInFile.Count +
                "\n\n";

                if (result.Item1 == "ok")
                {
                    //give the confirmation message
                    resultMessageTextbox.Text = result.Item2;
                    //createdFileDateTimeDetailTextbox.Text = File.GetCreationTime(result.Item3).ToString();
                    createdFileDateTimeDetailTextbox.Text = File.GetLastWriteTime(result.Item3).ToString();
                    resultSmallDetailsTextbox.Text = smallDetails;

                }
                else
                {
                    resultMessageTextbox.Text = result.Item2;
                    tabControl1.SelectedIndex = 1;
                }
            }
            else
            {
                MessageBox.Show("Det saknas en lista med tidtabel info. Välj först en fil som har denna information.");
                tabControl1.SelectedIndex = 0;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void schedItemBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var personnelForm = new Form2();
            personnelForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AboutBox2 a = new AboutBox2();
            a.Show();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void folderLocationTextBox_onClick(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = true;
            DialogResult result = folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderLocationTextBox.Text = folderDialog.SelectedPath;
            }
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView5UnclearNotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}