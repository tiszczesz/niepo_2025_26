using cw7_edit.Models;

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
            cbClassname.DataSource = ClassList.GetClasses(); //wypełnia combobox danymi z metody GetClasses
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //ustawia stan przycisku w zależności od zaznaczenia checkboxa
            btnSend.Enabled = checkBox1.Checked;
        }

        private void btnSend_Click(object sender, EventArgs e) {
            Person p1 = new Person {
                Firstname = tbFirstname.Text.Trim(),
                Lastname = tbLastname.Text.Trim(),
                Classname = cbClassname.Text
            };
            lbResult.Text = p1.ToString();
        }
    }
}
