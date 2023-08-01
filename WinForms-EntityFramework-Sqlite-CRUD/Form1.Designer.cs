namespace WinForms_EntityFramework_Sqlite_CRUD
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
            button1_loadPersonnelList = new Button();
            button2_update = new Button();
            button3_delete = new Button();
            personnelBindingSource1 = new BindingSource(components);
            personnelBindingSource = new BindingSource(components);
            textBox1FN = new TextBox();
            textBox2LN = new TextBox();
            textBox3Email = new TextBox();
            textBox4AleId = new TextBox();
            textBox6LastUpdated = new TextBox();
            toolStrip1 = new ToolStrip();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            textBox0id = new TextBox();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            firstNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            aleIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            phoneDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastUpdatedDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            personnelBindingSource2 = new BindingSource(components);
            textBox5Phone = new TextBox();
            ((System.ComponentModel.ISupportInitialize)personnelBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personnelBindingSource).BeginInit();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personnelBindingSource2).BeginInit();
            SuspendLayout();
            // 
            // button1_loadPersonnelList
            // 
            button1_loadPersonnelList.Location = new Point(396, 28);
            button1_loadPersonnelList.Name = "button1_loadPersonnelList";
            button1_loadPersonnelList.Size = new Size(246, 45);
            button1_loadPersonnelList.TabIndex = 0;
            button1_loadPersonnelList.Text = "Load personnel list";
            button1_loadPersonnelList.UseVisualStyleBackColor = true;
            button1_loadPersonnelList.Click += button1_Click_loadPersonnelList;
            // 
            // button2_update
            // 
            button2_update.Location = new Point(678, 28);
            button2_update.Name = "button2_update";
            button2_update.Size = new Size(202, 45);
            button2_update.TabIndex = 1;
            button2_update.Text = "Update";
            button2_update.UseVisualStyleBackColor = true;
            button2_update.Click += button2_Click_upload;
            // 
            // button3_delete
            // 
            button3_delete.Location = new Point(912, 28);
            button3_delete.Name = "button3_delete";
            button3_delete.Size = new Size(196, 45);
            button3_delete.TabIndex = 2;
            button3_delete.Text = "Delete";
            button3_delete.UseVisualStyleBackColor = true;
            button3_delete.Click += button3_Click_delete;
            // 
            // personnelBindingSource1
            // 
            personnelBindingSource1.DataSource = typeof(Model.Personnel);
            // 
            // personnelBindingSource
            // 
            personnelBindingSource.DataSource = typeof(Model.Personnel);
            // 
            // textBox1FN
            // 
            textBox1FN.Location = new Point(12, 142);
            textBox1FN.Name = "textBox1FN";
            textBox1FN.Size = new Size(276, 27);
            textBox1FN.TabIndex = 4;
            // 
            // textBox2LN
            // 
            textBox2LN.Location = new Point(12, 184);
            textBox2LN.Name = "textBox2LN";
            textBox2LN.Size = new Size(276, 27);
            textBox2LN.TabIndex = 5;
            // 
            // textBox3Email
            // 
            textBox3Email.Location = new Point(12, 232);
            textBox3Email.Name = "textBox3Email";
            textBox3Email.Size = new Size(276, 27);
            textBox3Email.TabIndex = 6;
            // 
            // textBox4AleId
            // 
            textBox4AleId.Location = new Point(12, 275);
            textBox4AleId.Name = "textBox4AleId";
            textBox4AleId.Size = new Size(276, 27);
            textBox4AleId.TabIndex = 7;
            // 
            // textBox6LastUpdated
            // 
            textBox6LastUpdated.Location = new Point(13, 362);
            textBox6LastUpdated.Name = "textBox6LastUpdated";
            textBox6LastUpdated.Size = new Size(276, 27);
            textBox6LastUpdated.TabIndex = 8;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1263, 25);
            toolStrip1.TabIndex = 9;
            toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 493);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1263, 22);
            statusStrip1.TabIndex = 10;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 16);
            // 
            // textBox0id
            // 
            textBox0id.Location = new Point(12, 94);
            textBox0id.Name = "textBox0id";
            textBox0id.Size = new Size(274, 27);
            textBox0id.TabIndex = 11;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, firstNameDataGridViewTextBoxColumn, lastNameDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, aleIdDataGridViewTextBoxColumn, phoneDataGridViewTextBoxColumn, lastUpdatedDataGridViewTextBoxColumn });
            dataGridView1.DataSource = personnelBindingSource2;
            dataGridView1.Location = new Point(307, 94);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(935, 371);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellClick += dataGridView1_CellContentClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "id";
            idDataGridViewTextBoxColumn.HeaderText = "id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 125;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            firstNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            firstNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            lastNameDataGridViewTextBoxColumn.HeaderText = "LastName";
            lastNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            lastNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.Width = 125;
            // 
            // aleIdDataGridViewTextBoxColumn
            // 
            aleIdDataGridViewTextBoxColumn.DataPropertyName = "AleId";
            aleIdDataGridViewTextBoxColumn.HeaderText = "AleId";
            aleIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            aleIdDataGridViewTextBoxColumn.Name = "aleIdDataGridViewTextBoxColumn";
            aleIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
            phoneDataGridViewTextBoxColumn.MinimumWidth = 6;
            phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            phoneDataGridViewTextBoxColumn.Width = 125;
            // 
            // lastUpdatedDataGridViewTextBoxColumn
            // 
            lastUpdatedDataGridViewTextBoxColumn.DataPropertyName = "LastUpdated";
            lastUpdatedDataGridViewTextBoxColumn.HeaderText = "LastUpdated";
            lastUpdatedDataGridViewTextBoxColumn.MinimumWidth = 6;
            lastUpdatedDataGridViewTextBoxColumn.Name = "lastUpdatedDataGridViewTextBoxColumn";
            lastUpdatedDataGridViewTextBoxColumn.Width = 125;
            // 
            // personnelBindingSource2
            // 
            personnelBindingSource2.DataSource = typeof(Model.Personnel);
            // 
            // textBox5Phone
            // 
            textBox5Phone.Location = new Point(12, 319);
            textBox5Phone.Name = "textBox5Phone";
            textBox5Phone.Size = new Size(277, 27);
            textBox5Phone.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1263, 515);
            Controls.Add(textBox5Phone);
            Controls.Add(dataGridView1);
            Controls.Add(textBox0id);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(textBox6LastUpdated);
            Controls.Add(textBox4AleId);
            Controls.Add(textBox3Email);
            Controls.Add(textBox2LN);
            Controls.Add(textBox1FN);
            Controls.Add(button3_delete);
            Controls.Add(button2_update);
            Controls.Add(button1_loadPersonnelList);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)personnelBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)personnelBindingSource).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)personnelBindingSource2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1_loadPersonnelList;
        private Button button2_update;
        private Button button3_delete;
        private TextBox textBox1FN;
        private TextBox textBox2LN;
        private TextBox textBox3Email;
        private TextBox textBox4AleId;
        private TextBox textBox6LastUpdated;
        private BindingSource personnelBindingSource;
        private ToolStrip toolStrip1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TextBox textBox0id;
        private BindingSource personnelBindingSource1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn aleIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastUpdatedDataGridViewTextBoxColumn;
        private TextBox textBox5Phone;
        private BindingSource personnelBindingSource2;
    }
}