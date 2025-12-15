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
            if (selectedStudent != null) {
                _studentsRepo.Students.Remove(selectedStudent);
                LoadToListBox();
            }
        }
    }
}
