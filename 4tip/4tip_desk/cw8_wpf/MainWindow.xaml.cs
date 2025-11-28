using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cw8_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged {
        private int _boundNumber;

        public int BoundNumber {
            get { return _boundNumber; }
            set {
                _boundNumber = value;
                info.Content = _boundNumber;
                OnPropertyChanged();
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;// Set the data context for data binding
            BoundNumber = 67;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Reset_OnClick(object sender, RoutedEventArgs e) {
            BoundNumber = 0;
            MessageBox.Show(BoundNumber.ToString());
        }

        private void OpenWindow_OnClick(object sender, RoutedEventArgs e) {
                throw new NotImplementedException();
        }

      
    }
}