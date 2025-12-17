namespace cw8_listBox2
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
            lbStudents = new ListBox();
            btnLoad = new Button();
            lbListInfo = new Label();
            btnDelete = new Button();
            btnAdd = new Button();
            label1 = new Label();
            tbFirstname = new TextBox();
            tbLastName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // lbStudents
            // 
            lbStudents.Dock = DockStyle.Left;
            lbStudents.FormattingEnabled = true;
            lbStudents.Location = new Point(0, 0);
            lbStudents.Name = "lbStudents";
            lbStudents.Size = new Size(308, 450);
            lbStudents.TabIndex = 0;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(341, 45);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(177, 58);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Wczytaj z pliku";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // lbListInfo
            // 
            lbListInfo.AutoSize = true;
            lbListInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lbListInfo.ForeColor = Color.Maroon;
            lbListInfo.Location = new Point(341, 9);
            lbListInfo.Name = "lbListInfo";
            lbListInfo.Size = new Size(170, 21);
            lbListInfo.TabIndex = 2;
            lbListInfo.Text = "Brak elementów listy";
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(341, 125);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(177, 58);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Usuń zaznaczonego studenta";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Enabled = false;
            btnAdd.Location = new Point(341, 206);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(177, 58);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Dodaj studenta";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(580, 53);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 5;
            label1.Text = "Imię:";
            // 
            // tbFirstname
            // 
            tbFirstname.Location = new Point(623, 50);
            tbFirstname.Name = "tbFirstname";
            tbFirstname.PlaceholderText = "Podaj imię";
            tbFirstname.Size = new Size(200, 23);
            tbFirstname.TabIndex = 6;
            tbFirstname.Leave += dateTimePicker1_Leave;
            // 
            // tbLastName
            // 
            tbLastName.Location = new Point(623, 95);
            tbLastName.Name = "tbLastName";
            tbLastName.PlaceholderText = "Podaj nazwisko";
            tbLastName.Size = new Size(200, 23);
            tbLastName.TabIndex = 8;
            tbLastName.Leave += dateTimePicker1_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(553, 102);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 7;
            label2.Text = "Nazwisko:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(524, 146);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 9;
            label3.Text = "Data urodzenia:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(619, 140);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 10;
            dateTimePicker1.Leave += dateTimePicker1_Leave;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 450);
            Controls.Add(dateTimePicker1);
            Controls.Add(label3);
            Controls.Add(tbLastName);
            Controls.Add(label2);
            Controls.Add(tbFirstname);
            Controls.Add(label1);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(lbListInfo);
            Controls.Add(btnLoad);
            Controls.Add(lbStudents);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbStudents;
        private Button btnLoad;
        private Label lbListInfo;
        private Button btnDelete;
        private Button btnAdd;
        private Label label1;
        private TextBox tbFirstname;
        private TextBox tbLastName;
        private Label label2;
        private Label label3;
        private DateTimePicker dateTimePicker1;
    }
}
