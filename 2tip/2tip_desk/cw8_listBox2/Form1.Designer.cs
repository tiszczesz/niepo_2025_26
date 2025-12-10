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
            btnLoad.Location = new Point(336, 15);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(177, 58);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Wczytaj z pliku";
            btnLoad.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLoad);
            Controls.Add(lbStudents);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ListBox lbStudents;
        private Button btnLoad;
    }
}
