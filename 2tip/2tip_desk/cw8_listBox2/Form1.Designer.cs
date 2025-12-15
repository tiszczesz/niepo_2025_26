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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
