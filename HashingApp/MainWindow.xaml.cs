using HashingApp.ViewModels;
using System.Windows;

namespace HashingApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        MainWindowViewModel viewModel;
        public MainWindow() {
            InitializeComponent();
            viewModel = new MainWindowViewModel();
            DataContext = viewModel;
            Files.ItemsSource = viewModel.Files;
        }

        private void AddNewFile_Click(object sender, RoutedEventArgs e) {
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true) {
                // Open document
                string filename = dialog.FileName;
                viewModel.AddNewFile(filename);
            }
        }

        private async void UpdateHashes_Click(object sender, RoutedEventArgs e) {
            if (viewModel.Files.Count == 0) return;
            await viewModel.UpdateFilesInfo();
        }
    }
}
