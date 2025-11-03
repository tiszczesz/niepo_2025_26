namespace cw6_wf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Tworzymy obiekt okna Form2
            Form2 form2 = new Form2(this);
            //Wyświetlamy okno Form2 jako okno modalne
            form2.ShowDialog();
            //Wyświetlamy okno Form2 jako okno niemodalne
           // form2.Show();
           //this.Visible = false;
        }
    }
}
