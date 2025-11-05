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

namespace cw2_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            var windowOther = new OtherWindow();
            if (checkBox.IsChecked == true) {
                windowOther.ShowDialog();
            }
            else {
                windowOther.Show();
            }
                
        }

        private void ButtonClose(object sender, RoutedEventArgs e) {
            //Close(); // closes only the MainWindow
            Application.Current.Shutdown(); // closes the entire application
        }
    }
}