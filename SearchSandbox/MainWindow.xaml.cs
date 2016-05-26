using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.IO;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Data;
using ByteSizeLib;

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
            List<string> PropList = new List<string>();
            foreach (var file in FileInfo)
            {
                PropList.Add((string)file.GetType().GetProperty(Property).GetValue(file));
            }
            return PropList;
        }

        private void DirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            var dialogResult = dialog.ShowDialog();
            DirectoryButton.Visibility = Visibility.Collapsed;
            ResultsDataGrid.Visibility = Visibility.Visible;
            var dinfo = new DirectoryInfo(dialog.SelectedPath);
            Application.Current.Resources["DirectoryList"] = dinfo.GetFiles();
            FillDataList((FileInfo[])Application.Current.Resources["DirectoryList"], this.ResultsDataGrid);
        }
        
        private void FillDataList(FileInfo[] FileList, DataGrid DataGrid)
        {
            DataTable FileData = new DataTable();
            FileData.Columns.Add("Filename");
            FileData.Columns.Add("File Path");
            FileData.Columns.Add("File Size");
            FileData.Columns.Add("Byte Size");
            foreach (var file in FileList)
            {
                var dr = FileData.NewRow();
                dr["Filename"] = file.Name;
                dr["File Path"] = file.Directory.FullName;
                var flbytes = new ByteSize(file.Length);
                dr["File Size"] = flbytes.ToString();
                dr["Byte Size"] = flbytes.KiloBytes;
                FileData.Rows.Add(dr);
            }
            DataGrid.DataContext = FileData.DefaultView;
            DataGrid.ItemsSource = FileData.DefaultView;
            foreach (DataGridColumn col in DataGrid.Columns)
            {
                if ((string)col.Header == "File Size")
                {
                    col.CanUserSort = false;
                }
            }
            DataGrid.Items.Refresh();
        }
    }
}
