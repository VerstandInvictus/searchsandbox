using System;
using System.Windows;   

namespace SearchSandbox
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

        private void DirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            var dialogResult = dialog.ShowDialog();
            DirectoryButton.Visibility = Visibility.Collapsed;
            Application.Current.Properties["DirectoryList"] = System.IO.Directory.GetFiles(dialog.SelectedPath);
            string result = string.Join(", ", (string[])Application.Current.Properties["DirectoryList"]);
            MessageBox.Show(result);
        }
    }
}
