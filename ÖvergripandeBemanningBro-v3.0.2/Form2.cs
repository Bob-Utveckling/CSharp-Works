using ÖvergripandeBemanningBro_v3._0._2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ÖvergripandeBemanningBro_v3._0._2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            using (var context = new PersonnelContext())
            {
                var myPersonnels = context.Personnels;

                dataGridView1.DataSource = myPersonnels.ToList(); //BindingList?
                //err:value cannot be null. dataGridView1.Sort(this.dataGridView1.Columns["firstName"], ListSortDirection.Ascending);
                toolStripStatusLabel1.Text = "Redo";
            };
        }







        int selectedRow;

        private void personnelBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new PersonnelContext())
            {
                toolStripStatusLabel1.Text = "Laddar personals detaljer...";

                var myPersonnels = context.Personnels;

                //BindingSource source = new BindingSource();
                //source.DataSource = myPersonnels;
                //dataGridView1.DataSource = source;
                dataGridView1.DataSource = myPersonnels.ToList(); //BindingList?
                toolStripStatusLabel1.Text = "Redo";

            }
        }

        private void button_insert_Click(object sender, EventArgs e)
        {
            using (var context = new PersonnelContext())
            {
                var personnel = new Personnel();
                personnel.FirstName = "Ny";
                context.Personnels.Add(personnel);
                context.SaveChanges();

                //var myPersonnel1 = context.Personnels;

                dataGridView1.DataSource = null;
                //dataGridView1.DataSource = myPersonnel1.ToList(); //if using myPersonnel1 only, gives err: cannot bind directly.
                dataGridView1.DataSource = context.Personnels.ToList(); //if using myPersonnel1 only, gives err: cannot bind directly.

            }

        }

        private void button2_update_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[selectedRow];
            newDataRow.Cells[0].Value = textBox0id.Text;
            newDataRow.Cells[1].Value = textBox1FN.Text;
            newDataRow.Cells[2].Value = textBox2AFN1.Text;
            newDataRow.Cells[3].Value = textBox3LN.Text;
            newDataRow.Cells[4].Value = textBox4ALN1.Text;
            newDataRow.Cells[5].Value = textBox5Email.Text;
            newDataRow.Cells[6].Value = textBox6AleId.Text;
            newDataRow.Cells[7].Value = textBox7Phone.Text;
            newDataRow.Cells[8].Value = textBox8LastUpdated.Text;
            using (var context = new PersonnelContext())
            {
                var result = context.Personnels.SingleOrDefault(p => p.id.ToString() == newDataRow.Cells[0].Value.ToString());
                if (result != null)
                {

                    result.FirstName = newDataRow.Cells[1].Value.ToString() == null ? "" : newDataRow.Cells[1].Value.ToString();
                    result.AlternativeFirstName1 = newDataRow.Cells[2].Value.ToString() == null ? "" : newDataRow.Cells[2].Value.ToString();
                    result.LastName = newDataRow.Cells[3].Value.ToString() == null ? "" : newDataRow.Cells[3].Value.ToString();
                    result.AlternativeLastName1 = newDataRow.Cells[4].Value.ToString() == null ? "" : newDataRow.Cells[4].Value.ToString();
                    result.Email = newDataRow.Cells[5].Value.ToString() == null ? "" : newDataRow.Cells[5].Value.ToString();
                    result.AleId = newDataRow.Cells[6].Value.ToString() == null ? "" : newDataRow.Cells[6].Value.ToString();
                    result.Phone = newDataRow.Cells[7].Value.ToString() == null ? "" : newDataRow.Cells[7].Value.ToString();
                    //except that if empty it won't work: result.LastUpdated = DateTime.Parse(newDataRow.Cells[6].Value.ToString() == null ? "" : newDataRow.Cells[6].Value.ToString());
                    result.LastUpdated = DateTime.Now;
                    MessageBox.Show("Uppdaterade databaspost med id: " + result.id);

                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Välj en databaspost först, ändra detaljer på textrutor, och klicka på den här knappen efteråt.");
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                //selectedAleId = row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString();

                textBox0id.Text = row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString();
                textBox1FN.Text = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
                textBox2AFN1.Text = row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString();
                textBox3LN.Text = row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString();
                textBox4ALN1.Text = row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString();
                textBox5Email.Text = row.Cells[5].Value == null ? "" : row.Cells[5].Value.ToString();
                textBox6AleId.Text = row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString();
                textBox7Phone.Text = row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString();
                textBox8LastUpdated.Text = row.Cells[8].Value == null ? "" : row.Cells[8].Value.ToString();
                toolStripStatusLabel1.Text = "Uppdatera databaspost med id " + row.Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_delete_Click(object sender, EventArgs e)
        {

            using (var context = new PersonnelContext())
            {
                var myPersonnel1 = context.Personnels;
                var dgv1Row = dataGridView1.Rows[selectedRow];
                DialogResult dialogResult = MessageBox.Show("Ta bort databaspost med id " + context.Personnels.FirstOrDefault(a => a.id.ToString() == dgv1Row.Cells[0].Value.ToString()).id + "?",
                                                            "Nu tas bort databaspost med id: " + context.Personnels.FirstOrDefault(a => a.id.ToString() == dgv1Row.Cells[0].Value.ToString()).id,
                                                            MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //MessageBox.Show("deleting record with id: " + context.Personnels.FirstOrDefault(a => a.AleId == selectedAleId).id);
                    myPersonnel1.Remove(context.Personnels.FirstOrDefault(a => a.id.ToString() == dgv1Row.Cells[0].Value.ToString()));
                    context.SaveChanges();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = myPersonnel1.ToList(); //if using myPersonnel1 only, gives err: cannot bind directly.
                }
                else
                {
                    //Nothing
                }
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tillsätt ny personal, välj en personal om du vill updatera eller ta bort informationen.";
        }
    }
}
