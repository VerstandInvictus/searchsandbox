using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.IO;
using System.Collections.Generic;

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
        
        private List<string> StringListFromFileInfo(FileInfo[] FileInfo, string Property)
        {
            List<string> FilenameList = new List<string>();
            foreach (var file in FileInfo)
            {
                FilenameList.Add((string)file.GetType().GetProperty(Property).GetValue(file));
            }
            return FilenameList;
        }

        private void DirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            var dialogResult = dialog.ShowDialog();
            DirectoryButton.Visibility = Visibility.Collapsed;
            ResultsDataGrid.Visibility = Visibility.Visible;
            var dinfo = new DirectoryInfo(dialog.SelectedPath);
            Application.Current.Resources["DirectoryList"] = dinfo.GetFiles();
            MessageBox.Show
            (
                string.Join
                (
                    ",",
                    StringListFromFileInfo((FileInfo[])Application.Current.Resources["DirectoryList"], "Name")
                )
            );
        }
        
        private void FillDataList(object FileList)
        {

        }
    }
}
