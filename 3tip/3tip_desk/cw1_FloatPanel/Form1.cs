namespace cw1_FloatPanel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            flowLayoutPanel1.Dock = DockStyle.Fill;              // wypełnij rodzica
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight; // jak flex-direction: row
            flowLayoutPanel1.WrapContents = true;                // zawijanie linii
            flowLayoutPanel1.AutoScroll = true;                  // pasek przewijania przy potrzebie
            flowLayoutPanel1.Padding = new Padding(10);
            flowLayoutPanel1.AutoSize = false;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // Dodaj kontrolki dynamicznie
            
        }

        private void button1_Click(object sender, EventArgs e) {
            int limit = Convert.ToInt32(numUpDown.Value);
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < limit; i++)
            {
                Panel p = new Panel();
                Label label = new Label();
                label.Text = $"Panel {i + 1}";
                p.Controls.Add(label);
                p.Margin = new Padding(5);
                p.Height = 100;
                p.Width = 100;
                p.BackColor = Color.Orange;
                flowLayoutPanel1.Controls.Add(p);
            }
        }
    }
}
