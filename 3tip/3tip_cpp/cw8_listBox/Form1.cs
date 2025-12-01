namespace cw8_listBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tbAddItem_TextChanged(object sender, EventArgs e)
        {
            //przycisk jest aktywny tylko gdy w polu tekstowym jest coś wpisane
            btnAddItem.Enabled = tbAddItem.Text.Trim().Length > 0;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            lbItems.Items.Add(tbAddItem.Text.Trim());
            tbAddItem.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbItems.Items.Clear();
        }
    }
}
