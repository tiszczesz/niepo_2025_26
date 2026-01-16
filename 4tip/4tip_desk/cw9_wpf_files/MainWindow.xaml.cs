using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
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

namespace cw9_wpf_files
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

        private void New_Open(object sender, RoutedEventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Wybierz plik";
            openFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                // Odczytaj zawartość pliku
                string filePath = openFileDialog.FileName;
                string fileContent = File.ReadAllText(filePath);

                // Możesz teraz użyć tej zawartości, np.:
                //MessageBox.Show($"Wybrano plik: {filePath}", "Informacja");
                // lub wyświetlić w TextBlock
                TextShow.Text = fileContent;
                //pokaznie nazwy pliku otwartego w ToolBar
                FileNameLabel.Content = System.IO.Path.GetFileName(filePath);
            }
        }

        private void Save_FileMenu(object sender, RoutedEventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Zapisz plik jako";
            saveFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (saveFileDialog.ShowDialog() == true)
            {
                // Zapisz zawartość do pliku
                string filePath = saveFileDialog.FileName;
                File.WriteAllText(filePath, TextShow.Text, Encoding.UTF8);
                // Możesz teraz poinformować użytkownika o zapisaniu pliku
                MessageBox.Show($"Plik został zapisany: {filePath}", "Informacja");
            }
        }

        private void MernuItem_MicLearn(object sender, RoutedEventArgs e) {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "https://learn.microsoft.com/",
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nie można otworzyć przeglądarki: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}