using SummerEx.Models;

namespace SummerEx
{
    public partial class Form1 : Form {
        private readonly HolidaysRepo _repo;
        public Form1()
        {
            InitializeComponent();
            _repo = new HolidaysRepo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
