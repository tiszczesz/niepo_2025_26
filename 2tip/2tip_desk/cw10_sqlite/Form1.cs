using cw10_sqlite.Models;

namespace cw10_sqlite
{
    public partial class Form1 : Form
    {
        private readonly StudentsRepo _studentsRepo;
        private List<Student> _students;
        public Form1()
        {
            InitializeComponent();
            //utworzenie repozytorium, które będzie odpowiedzialne za komunikację z bazą danych
            _studentsRepo = new StudentsRepo();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //załadowanie danych z bazy danych do listy _students
            _students = _studentsRepo.GetAll();
            //wyświetlenie danych w kontrolce DataGridView
            dataGridView1.DataSource = _students;
        }
    }
}
