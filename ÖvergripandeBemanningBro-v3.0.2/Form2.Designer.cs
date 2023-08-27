namespace ÖvergripandeBemanningBro_v3._0._2
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            firstNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            AlternativeFirstName1 = new DataGridViewTextBoxColumn();
            lastNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            AlternativeLastName1 = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            aleIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            phoneDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastUpdatedDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            personnelBindingSource1 = new BindingSource(components);
            personnelBindingSource = new BindingSource(components);
            button1_loadPersonnelList = new Button();
            button_insert = new Button();
            button2_update = new Button();
            button3_delete = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox0id = new TextBox();
            textBox1FN = new TextBox();
            textBox3LN = new TextBox();
            textBox5Email = new TextBox();
            textBox6AleId = new TextBox();
            textBox7Phone = new TextBox();
            textBox8LastUpdated = new TextBox();
            statusStrip1 = new StatusStrip();
            statusStrip2 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            label8 = new Label();
            label9 = new Label();
            pictureBox1 = new PictureBox();
            textBox2AFN1 = new TextBox();
            label10 = new Label();
            label11 = new Label();
            textBox4ALN1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personnelBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personnelBindingSource).BeginInit();
            statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, firstNameDataGridViewTextBoxColumn, AlternativeFirstName1, lastNameDataGridViewTextBoxColumn, AlternativeLastName1, emailDataGridViewTextBoxColumn, aleIdDataGridViewTextBoxColumn, phoneDataGridViewTextBoxColumn, lastUpdatedDataGridViewTextBoxColumn });
            dataGridView1.DataSource = personnelBindingSource1;
            dataGridView1.Location = new Point(242, 182);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1190, 373);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellContentClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 125;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            firstNameDataGridViewTextBoxColumn.HeaderText = "Förnamn";
            firstNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            firstNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // AlternativeFirstName1
            // 
            AlternativeFirstName1.DataPropertyName = "AlternativeFirstName1";
            AlternativeFirstName1.HeaderText = "Alternativ Förnamn";
            AlternativeFirstName1.MinimumWidth = 6;
            AlternativeFirstName1.Name = "AlternativeFirstName1";
            AlternativeFirstName1.Width = 125;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            lastNameDataGridViewTextBoxColumn.HeaderText = "Efternamn";
            lastNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            lastNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // AlternativeLastName1
            // 
            AlternativeLastName1.DataPropertyName = "AlternativeLastName1";
            AlternativeLastName1.HeaderText = "Alternativ Efternamn";
            AlternativeLastName1.MinimumWidth = 6;
            AlternativeLastName1.Name = "AlternativeLastName1";
            AlternativeLastName1.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Mejl";
            emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.Width = 125;
            // 
            // aleIdDataGridViewTextBoxColumn
            // 
            aleIdDataGridViewTextBoxColumn.DataPropertyName = "AleId";
            aleIdDataGridViewTextBoxColumn.HeaderText = "Ale Id (viktig)";
            aleIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            aleIdDataGridViewTextBoxColumn.Name = "aleIdDataGridViewTextBoxColumn";
            aleIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            phoneDataGridViewTextBoxColumn.HeaderText = "Telefonnummer";
            phoneDataGridViewTextBoxColumn.MinimumWidth = 6;
            phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            phoneDataGridViewTextBoxColumn.Width = 125;
            // 
            // lastUpdatedDataGridViewTextBoxColumn
            // 
            lastUpdatedDataGridViewTextBoxColumn.DataPropertyName = "LastUpdated";
            lastUpdatedDataGridViewTextBoxColumn.HeaderText = "Senast uppdaterad";
            lastUpdatedDataGridViewTextBoxColumn.MinimumWidth = 6;
            lastUpdatedDataGridViewTextBoxColumn.Name = "lastUpdatedDataGridViewTextBoxColumn";
            lastUpdatedDataGridViewTextBoxColumn.Width = 125;
            // 
            // personnelBindingSource1
            // 
            personnelBindingSource1.DataSource = typeof(Model.Personnel);
            // 
            // personnelBindingSource
            // 
            personnelBindingSource.DataSource = typeof(Model.Personnel);
            personnelBindingSource.CurrentChanged += personnelBindingSource_CurrentChanged;
            // 
            // button1_loadPersonnelList
            // 
            button1_loadPersonnelList.Location = new Point(242, 79);
            button1_loadPersonnelList.Name = "button1_loadPersonnelList";
            button1_loadPersonnelList.Size = new Size(259, 58);
            button1_loadPersonnelList.TabIndex = 1;
            button1_loadPersonnelList.Text = "Ladda om personals lista";
            button1_loadPersonnelList.UseVisualStyleBackColor = true;
            button1_loadPersonnelList.Click += button1_Click;
            // 
            // button_insert
            // 
            button_insert.Location = new Point(547, 79);
            button_insert.Name = "button_insert";
            button_insert.Size = new Size(216, 60);
            button_insert.TabIndex = 2;
            button_insert.Text = "Tillsätt ny personal";
            button_insert.UseVisualStyleBackColor = true;
            button_insert.Click += button_insert_Click;
            // 
            // button2_update
            // 
            button2_update.Location = new Point(36, 497);
            button2_update.Name = "button2_update";
            button2_update.Size = new Size(173, 58);
            button2_update.TabIndex = 3;
            button2_update.Text = "Uppdatera personal";
            button2_update.UseVisualStyleBackColor = true;
            button2_update.Click += button2_update_Click;
            // 
            // button3_delete
            // 
            button3_delete.Location = new Point(807, 79);
            button3_delete.Name = "button3_delete";
            button3_delete.Size = new Size(179, 58);
            button3_delete.TabIndex = 4;
            button3_delete.Text = "Ta bort personal";
            button3_delete.UseVisualStyleBackColor = true;
            button3_delete.Click += button3_delete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 33);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 5;
            label1.Text = "Id";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 84);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 6;
            label2.Text = "Förnman";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 186);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 7;
            label3.Text = "Efternamn";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 288);
            label4.Name = "label4";
            label4.Size = new Size(38, 20);
            label4.TabIndex = 8;
            label4.Text = "Mejl";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(41, 341);
            label5.Name = "label5";
            label5.Size = new Size(147, 20);
            label5.TabIndex = 9;
            label5.Text = "Ale ID (viktigt att ha)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(41, 393);
            label6.Name = "label6";
            label6.Size = new Size(113, 20);
            label6.TabIndex = 10;
            label6.Text = "Telefonnummer";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(41, 443);
            label7.Name = "label7";
            label7.Size = new Size(134, 20);
            label7.TabIndex = 11;
            label7.Text = "Senast uppdaterad";
            // 
            // textBox0id
            // 
            textBox0id.Location = new Point(36, 56);
            textBox0id.Name = "textBox0id";
            textBox0id.Size = new Size(174, 27);
            textBox0id.TabIndex = 12;
            // 
            // textBox1FN
            // 
            textBox1FN.Location = new Point(37, 103);
            textBox1FN.Name = "textBox1FN";
            textBox1FN.Size = new Size(173, 27);
            textBox1FN.TabIndex = 13;
            // 
            // textBox3LN
            // 
            textBox3LN.Location = new Point(37, 208);
            textBox3LN.Name = "textBox3LN";
            textBox3LN.Size = new Size(173, 27);
            textBox3LN.TabIndex = 14;
            // 
            // textBox5Email
            // 
            textBox5Email.Location = new Point(37, 311);
            textBox5Email.Name = "textBox5Email";
            textBox5Email.Size = new Size(173, 27);
            textBox5Email.TabIndex = 15;
            // 
            // textBox6AleId
            // 
            textBox6AleId.Location = new Point(37, 364);
            textBox6AleId.Name = "textBox6AleId";
            textBox6AleId.Size = new Size(172, 27);
            textBox6AleId.TabIndex = 16;
            // 
            // textBox7Phone
            // 
            textBox7Phone.Location = new Point(36, 416);
            textBox7Phone.Name = "textBox7Phone";
            textBox7Phone.Size = new Size(174, 27);
            textBox7Phone.TabIndex = 17;
            // 
            // textBox8LastUpdated
            // 
            textBox8LastUpdated.Location = new Point(37, 466);
            textBox8LastUpdated.Name = "textBox8LastUpdated";
            textBox8LastUpdated.Size = new Size(173, 27);
            textBox8LastUpdated.TabIndex = 18;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 602);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1444, 22);
            statusStrip1.TabIndex = 19;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusStrip2
            // 
            statusStrip2.ImageScalingSize = new Size(20, 20);
            statusStrip2.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip2.Location = new Point(0, 576);
            statusStrip2.Name = "statusStrip2";
            statusStrip2.Size = new Size(1444, 26);
            statusStrip2.TabIndex = 20;
            statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(364, 20);
            toolStripStatusLabel1.Text = "Välj alternativ för att arbeta med personalinformation";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(256, 33);
            label8.Name = "label8";
            label8.Size = new Size(867, 20);
            label8.TabIndex = 21;
            label8.Text = "Det antas att personal som finns här har lagts till på Microsoft Teams team när du arbetar med appen Microsoft Shifts/Arbetspass.";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(77, 9);
            label9.Name = "label9";
            label9.Size = new Size(1046, 20);
            label9.TabIndex = 22;
            label9.Text = "För att schemat som du arbetar med ska läggas till korrekt, så behövs det att alla personal finns i Microsoft Teams  team och har samma Ale ID som finns här.";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(1129, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(51, 63);
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // textBox2AFN1
            // 
            textBox2AFN1.Location = new Point(39, 155);
            textBox2AFN1.Name = "textBox2AFN1";
            textBox2AFN1.Size = new Size(172, 27);
            textBox2AFN1.TabIndex = 24;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(36, 132);
            label10.Name = "label10";
            label10.Size = new Size(133, 20);
            label10.TabIndex = 25;
            label10.Text = "Alternativ förnamn";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(41, 238);
            label11.Name = "label11";
            label11.Size = new Size(145, 20);
            label11.TabIndex = 26;
            label11.Text = "Alternativ efternamn";
            // 
            // textBox4ALN1
            // 
            textBox4ALN1.Location = new Point(37, 261);
            textBox4ALN1.Name = "textBox4ALN1";
            textBox4ALN1.Size = new Size(176, 27);
            textBox4ALN1.TabIndex = 27;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1444, 624);
            Controls.Add(textBox4ALN1);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(textBox2AFN1);
            Controls.Add(pictureBox1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(statusStrip2);
            Controls.Add(statusStrip1);
            Controls.Add(textBox8LastUpdated);
            Controls.Add(textBox7Phone);
            Controls.Add(textBox6AleId);
            Controls.Add(textBox5Email);
            Controls.Add(textBox3LN);
            Controls.Add(textBox1FN);
            Controls.Add(textBox0id);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3_delete);
            Controls.Add(button2_update);
            Controls.Add(button_insert);
            Controls.Add(button1_loadPersonnelList);
            Controls.Add(dataGridView1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)personnelBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)personnelBindingSource).EndInit();
            statusStrip2.ResumeLayout(false);
            statusStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource personnelBindingSource;
        private Button button1_loadPersonnelList;
        private Button button_insert;
        private Button button2_update;
        private Button button3_delete;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox0id;
        private TextBox textBox1FN;
        private TextBox textBox3LN;
        private TextBox textBox5Email;
        private TextBox textBox6AleId;
        private TextBox textBox7Phone;
        private TextBox textBox8LastUpdated;
        private StatusStrip statusStrip1;
        private StatusStrip statusStrip2;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Label label8;
        private Label label9;
        private PictureBox pictureBox1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn AlternativeFirstName1;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn AlternativeLastName1;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn aleIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastUpdatedDataGridViewTextBoxColumn;
        private BindingSource personnelBindingSource1;
        private TextBox textBox2AFN1;
        private Label label10;
        private Label label11;
        private TextBox textBox4ALN1;
    }
}