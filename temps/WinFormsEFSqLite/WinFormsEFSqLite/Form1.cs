using WinFormsEFSqLite.Models;

namespace WinFormsEFSqLite
{
    public partial class Form1 : Form
    {
        private readonly BooksDbContext _dbContext = new BooksDbContext();
        private List<Book> _books;
        private BindingSource _bindingSource = new BindingSource();

        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _books = _dbContext.Books.ToList();
            _bindingSource.DataSource = _books;
            dataGridView1.DataSource = _bindingSource;
        }
    }
}
