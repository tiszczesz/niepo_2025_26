using cw11.Models;

namespace cw11
{
    public partial class Form1 : Form {
        private readonly StudentsRepo _repo;
        private List<Student> _students;
        public Form1()
        {
            InitializeComponent();
            _repo = new StudentsRepo();
            _students = _repo.GetStudents();
            LoadStudentsToGrid();
        }

        private void LoadStudentsToGrid() {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _students;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns["DivisionId"]?.Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
