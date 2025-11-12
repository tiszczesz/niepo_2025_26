namespace cw7_edit
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.MaximizeBox = false;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            btnSend.Enabled = false; //przycisk wysyłania jest domyślnie wyłączony
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            //ustawia stan przycisku w zależności od zaznaczenia checkboxa
            btnSend.Enabled = checkBox1.Checked;
        }
    }
}
