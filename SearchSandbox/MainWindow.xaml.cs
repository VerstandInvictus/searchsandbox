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
            Application.Current.Properties["CharacterArrays"] = 
        }

        private void DirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            var dialogResult = dialog.ShowDialog();
            DirectoryButton.Visibility = Visibility.Collapsed;
            Application.Current.Properties["DirectoryList"] = System.IO.Directory.GetFiles(dialog.SelectedPath);
        }

        private string[] SplitLetters
    }
}
