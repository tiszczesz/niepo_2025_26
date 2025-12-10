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
    }
}
