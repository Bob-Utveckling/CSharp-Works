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
            textBox0id.Text = row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString();
            textBox1FN.Text = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
            textBox2LN.Text = row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString();
            textBox3Email.Text = row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString();
            textBox4AleId.Text = row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString();
            textBox5Phone.Text = row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString();
            textBox6LastUpdated.Text = row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString();
            toolStripStatusLabel1.Text = "Row " + selectedRow + " selected. Make changes and click Update to update";
        }

        private void button1_Click_loadPersonnelList(object sender, EventArgs e)
        {
            using (var context = new PersonnelContext())
            {
                toolStripStatusLabel1.Text = "Loading Personnel details...";
                var myPersonnels = context.Personnels;
                dataGridView1.DataSource = myPersonnels.ToList(); //BindingList?
                toolStripStatusLabel1.Text = "Ready";

            }
        }

        private void button2_Click_upload(object sender, EventArgs e)
        {

            DataGridViewRow newDataRow = dataGridView1.Rows[selectedRow];
            newDataRow.Cells[0].Value = textBox0id.Text;
            newDataRow.Cells[1].Value = textBox1FN.Text;
            newDataRow.Cells[2].Value = textBox2LN.Text;
            newDataRow.Cells[3].Value = textBox3Email.Text;
            newDataRow.Cells[4].Value = textBox4AleId.Text;
            newDataRow.Cells[5].Value = textBox5Phone.Text;
            newDataRow.Cells[6].Value = textBox6LastUpdated.Text;
            using (var context = new PersonnelContext())
            {
                var result = context.Personnels.SingleOrDefault(p => p.id.ToString() == newDataRow.Cells[0].Value.ToString());
                if (result != null)
                {
                    MessageBox.Show("has result id: " + result.id);

                    result.FirstName = newDataRow.Cells[1].Value.ToString() == null? "": newDataRow.Cells[1].Value.ToString();
                    result.LastName = newDataRow.Cells[2].Value.ToString() == null ? "" : newDataRow.Cells[2].Value.ToString();
                    result.Email = newDataRow.Cells[3].Value.ToString() == null ? "" : newDataRow.Cells[3].Value.ToString();
                    result.AleId = newDataRow.Cells[4].Value.ToString() == null ? "" : newDataRow.Cells[4].Value.ToString();
                    result.Phone = newDataRow.Cells[5].Value.ToString() == null ? "" : newDataRow.Cells[5].Value.ToString();
                    //except that if empty it won't work: result.LastUpdated = DateTime.Parse(newDataRow.Cells[6].Value.ToString() == null ? "" : newDataRow.Cells[6].Value.ToString());
                    result.LastUpdated = DateTime.Now;
                    context.SaveChanges();
                } else
                {
                    MessageBox.Show("result null");
                }
            }

        }

        private void button3_Click_delete(object sender, EventArgs e)
        {
            selectedRow = dataGridView1.CurrentCell.RowIndex;
            //dataGridView1.Rows.RemoveAt(selectedRow);
            /*using (var context = new PersonnelContext())
            {
                var myPersonnels = context.Personnels;
                myPersonnels.
            }*/
        }
    }
}