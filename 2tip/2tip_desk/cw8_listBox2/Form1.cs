using System.ComponentModel;
using cw8_listBox2.Models;

namespace cw8_listBox2
{
    public partial class Form1 : Form
    {
        private StudentsRepo _studentsRepo;
        public Form1()
        {
            InitializeComponent();
            _studentsRepo = new StudentsRepo("students.txt");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //wyczyść listbox
            LoadToListBox();
            btnDelete.Enabled = lbStudents.SelectedIndex != -1;
        }

        private void LoadToListBox()
        {
            lbStudents.DataSource = null;
            //utwórz BindingList na podstawie listy studentów
            //automatyczna aktualizacja listboxa przy zmianie listy
            BindingList<Student> bindingList =
                new BindingList<Student>(_studentsRepo.Students);
            lbStudents.DataSource = bindingList;
            lbListInfo.Text = "Ilość studentów: " + bindingList.Count;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // usuwanie zaznaczonego studenta z listy
            var selectedStudent = lbStudents.SelectedItem as Student;
            if (selectedStudent != null)
            {
                _studentsRepo.Students.Remove(selectedStudent);
                LoadToListBox();
            }
        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            btnAdd.Enabled = tbFirstname.Text.Length > 2
                             && tbLastName.Text.Length > 2
                             && dateTimePicker1.Text.Length > 2;
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            Student newStudent = new Student() {
                Id = 1,
                FirstName = tbFirstname.Text,
                LastName = tbLastName.Text,
                BirthDate = dateTimePicker1.Value
            };
        }
    }
}
