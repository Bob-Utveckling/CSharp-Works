using System.IO;

namespace ÖvergripandeBemanningBro_v1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            updateLabel("Redo");

        }

        public void updateLabel(string text)
        {
            toolStripStatusLabel1.Text = text;
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateLabel("Välj 'tjänstgöringslista' filen som du hämtade från Multi Access");

            //set the path to Downloads for the request after:
            string path = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            path = Path.Combine(path, "Downloads");

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
                //CreateFinalExcelFile.createTheFile(dlg.FileName);
                tabControl1.SelectedIndex = 1;
                ReadTheCsvFileAndPrepareToCreateTheExcelFile.prepare(dlg.FileName);
                
                //tabPage2.Select();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //CreateTheExcelFile.generate(schedItems);
        }
    }
}