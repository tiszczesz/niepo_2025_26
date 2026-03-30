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
            LoadStudentsToGrid();
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            // dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            //MessageBox.Show("Kliknięto w wiersz o indeksie: "
            //                + dataGridView1.CurrentRow.Index);
            //pobieranie danych studenta z klikniętego wiersza
            Student? student = dataGridView1.CurrentRow.DataBoundItem as Student;
            if (student == null) return;
            UpdateStudentForm(student);
        }

        private void UpdateStudentForm(Student student)
        {
            tbFirstName.Text = student.Firstname;
            tbLastName.Text = student.Lastname;
            dtEnrolment.Value = student.EnrollmentDate;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFirstName.Text)
                || string.IsNullOrEmpty(tbLastName.Text)
                || string.IsNullOrEmpty(dtEnrolment.Text))
            {
                MessageBox.Show("Wypełnij wszystkie pola!");
                return;
            }
            string firstName = tbFirstName.Text.Trim();
            string lastName = tbLastName.Text.Trim();
            DateTime enrollmentDate = dtEnrolment.Value;
            var student = new Student
            {
                Firstname = firstName,
                Lastname = lastName,
                EnrollmentDate = enrollmentDate
            };
            //zapisanie studenta do bazy danych
            _studentsRepo.AddStudent(student);

            //odświeżenie danych w DataGridView
            LoadStudentsToGrid();
        }

        private void LoadStudentsToGrid()
        {
            //załadowanie danych z bazy danych do listy _students

            //ustawiamy właściwości DataGridView
            //dataGridView1.Columns[0].Visible = false;
            _students = _studentsRepo.GetAll();
            dataGridView1.DataSource = null;
            //wyświetlenie danych w kontrolce DataGridView
            dataGridView1.DataSource = _students;
            dataGridView1.Columns[0].Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1) {
                if (dataGridView1.CurrentRow == null) return;
                Student? student = dataGridView1.CurrentRow.DataBoundItem as Student;
                if (student == null) return;
                _studentsRepo.DeleteStudent(student.Id);
                LoadStudentsToGrid();
            }
        }
    }
}
