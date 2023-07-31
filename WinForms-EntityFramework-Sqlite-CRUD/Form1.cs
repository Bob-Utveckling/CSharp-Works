using System.Windows.Forms;

namespace WinForms_EntityFramework_Sqlite_CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int selectedRow;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            textBox1FN.Text = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
            textBox2LN.Text = row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString();
            textBox3Email.Text = row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString();
            textBox4AleId.Text = row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString();
            textBox5LastUpdated.Text = row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString();
            toolStripStatusLabel1.Text = "Row " + selectedRow + " selected. Make changes and click Update to update";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new PersonnelContext())
            {
                toolStripStatusLabel1.Text = "Loading Personnel details...";
                var myPersonnels = context.Personnels;
                dataGridView1.DataSource = myPersonnels.ToList();
                toolStripStatusLabel1.Text = "Ready";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DataGridViewRow newDataRow = dataGridView1.Rows[selectedRow];
            newDataRow.Cells[1].Value = textBox1FN.Text;
            newDataRow.Cells[2].Value = textBox2LN.Text;
            newDataRow.Cells[3].Value = textBox3Email.Text;
            newDataRow.Cells[4].Value = textBox4AleId.Text;
            newDataRow.Cells[5].Value = textBox5LastUpdated.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectedRow = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(selectedRow);
        }
    }
}