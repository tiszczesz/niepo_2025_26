using cw2_EF_Sqlite.Models;

namespace cw2_EF_Sqlite
{
    public partial class Form1 : Form {
        private StudentDbContext _context;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            _context = new StudentDbContext();
        }
    }
}
