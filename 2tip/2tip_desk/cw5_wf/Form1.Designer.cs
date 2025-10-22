namespace cw5_wf;

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
        button1 = new Button();
        label1 = new Label();
        comboBox1 = new ComboBox();
        SuspendLayout();
        // 
        // button1
        // 
        button1.BackColor = Color.IndianRed;
        button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
        button1.Location = new Point(86, 49);
        button1.Name = "button1";
        button1.Size = new Size(321, 116);
        button1.TabIndex = 0;
        button1.Text = "Pokaż aktualną datę";
        button1.UseVisualStyleBackColor = false;
        // 
        // label1
        // 
        label1.BorderStyle = BorderStyle.Fixed3D;
        label1.Font = new Font("Segoe UI", 20F, FontStyle.Underline);
        label1.Location = new Point(86, 205);
        label1.Name = "label1";
        label1.Size = new Size(286, 135);
        label1.TabIndex = 1;
        label1.Text = "Ala ma kota";
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new Point(604, 87);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(184, 23);
        comboBox1.TabIndex = 2;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Info;
        ClientSize = new Size(884, 761);
        Controls.Add(comboBox1);
        Controls.Add(label1);
        Controls.Add(button1);
        Name = "Form1";
        Text = "Okienko główne";
        ResumeLayout(false);
    }

    #endregion

    private Button button1;
    private Label label1;
    private ComboBox comboBox1;
}
