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
        }
    }
}
