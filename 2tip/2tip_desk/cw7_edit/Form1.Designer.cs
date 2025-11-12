namespace cw7_edit
{
    partial class MainWindow
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
            panel1 = new Panel();
            btnSend = new Button();
            checkBox1 = new CheckBox();
            cbClassname = new ComboBox();
            tbLasname = new TextBox();
            tbFirstname = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MistyRose;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnSend);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(cbClassname);
            panel1.Controls.Add(tbLasname);
            panel1.Controls.Add(tbFirstname);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(469, 450);
            panel1.TabIndex = 0;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.Silver;
            btnSend.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnSend.Location = new Point(182, 265);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(233, 32);
            btnSend.TabIndex = 7;
            btnSend.Text = "Zatwierdź dane";
            btnSend.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            checkBox1.Location = new Point(182, 216);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(249, 25);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Zgoda na przetwarzanie danych";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // cbClassname
            // 
            cbClassname.Font = new Font("Segoe UI", 12F);
            cbClassname.FormattingEnabled = true;
            cbClassname.Location = new Point(182, 158);
            cbClassname.Name = "cbClassname";
            cbClassname.Size = new Size(233, 29);
            cbClassname.TabIndex = 5;
            // 
            // tbLasname
            // 
            tbLasname.Font = new Font("Segoe UI", 12F);
            tbLasname.Location = new Point(182, 105);
            tbLasname.Name = "tbLasname";
            tbLasname.Size = new Size(233, 29);
            tbLasname.TabIndex = 4;
            // 
            // tbFirstname
            // 
            tbFirstname.Font = new Font("Segoe UI", 12F);
            tbFirstname.Location = new Point(182, 53);
            tbFirstname.Name = "tbFirstname";
            tbFirstname.Size = new Size(233, 29);
            tbFirstname.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(37, 161);
            label3.Name = "label3";
            label3.Size = new Size(109, 21);
            label3.TabIndex = 2;
            label3.Text = "Wybierz klasę:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(27, 108);
            label2.Name = "label2";
            label2.Size = new Size(119, 21);
            label2.TabIndex = 1;
            label2.Text = "Podaj nazwisko:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(61, 51);
            label1.Name = "label1";
            label1.Size = new Size(85, 21);
            label1.TabIndex = 0;
            label1.Text = "Podaj imię:";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainWindow";
            Text = "Formularz zgłoszeniowy";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ComboBox cbClassname;
        private TextBox tbLasname;
        private TextBox tbFirstname;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnSend;
        private CheckBox checkBox1;
    }
}
