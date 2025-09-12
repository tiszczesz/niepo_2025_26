using cw2_EF_Sqlite.Models;

namespace cw2_EF_Sqlite
{
    public partial class Form1 : Form {
        private StudentDbContext _context;
        //public List<Student> students;
        public BindingSource bindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            _context = new StudentDbContext();
            //students = _context.Students.ToList();
            bindingSource.DataSource = _context.Students.ToList();
            
            dataGridView1.DataSource = bindingSource;
        }
    }
}
