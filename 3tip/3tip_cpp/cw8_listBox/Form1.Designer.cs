namespace cw8_listBox
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
            panel1 = new Panel();
            lbItems = new ListBox();
            panel3 = new Panel();
            btnAddItem = new Button();
            tbAddItem = new TextBox();
            panel2 = new Panel();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            btnClear = new Button();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSalmon;
            panel1.Controls.Add(lbItems);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(308, 449);
            panel1.TabIndex = 0;
            // 
            // lbItems
            // 
            lbItems.Dock = DockStyle.Fill;
            lbItems.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lbItems.FormattingEnabled = true;
            lbItems.Location = new Point(0, 64);
            lbItems.Name = "lbItems";
            lbItems.Size = new Size(308, 385);
            lbItems.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(btnAddItem);
            panel3.Controls.Add(tbAddItem);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(308, 64);
            panel3.TabIndex = 1;
            // 
            // btnAddItem
            // 
            btnAddItem.Enabled = false;
            btnAddItem.Location = new Point(150, 22);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(117, 23);
            btnAddItem.TabIndex = 1;
            btnAddItem.Text = "dodaj nowy";
            btnAddItem.UseVisualStyleBackColor = true;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // tbAddItem
            // 
            tbAddItem.Location = new Point(22, 22);
            tbAddItem.Name = "tbAddItem";
            tbAddItem.Size = new Size(100, 23);
            tbAddItem.TabIndex = 0;
            tbAddItem.TextChanged += tbAddItem_TextChanged;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(btnClear);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(308, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(399, 449);
            panel2.TabIndex = 1;
            // 
            // button4
            // 
            button4.Location = new Point(39, 149);
            button4.Name = "button4";
            button4.Size = new Size(331, 38);
            button4.TabIndex = 3;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(39, 107);
            button3.Name = "button3";
            button3.Size = new Size(331, 38);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(39, 65);
            button2.Name = "button2";
            button2.Size = new Size(331, 38);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(39, 23);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(331, 38);
            btnClear.TabIndex = 0;
            btnClear.Text = "Wyczyść wszystko";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(707, 449);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Praca z listą";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private ListBox lbItems;
        private Panel panel2;
        private Button btnAddItem;
        private TextBox tbAddItem;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button btnClear;
    }
}
