using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region On Loaded

        #endregion

        #region Folder Expanded
        /// <summary>
        /// When the folder is expanded, find the subfolders/files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            #region Initial Cheks
            var item = (TreeViewItem)sender;

            //if the item only contains the dummy data
            if (item.Items.Count != 1 && item.Items[0] != null)
                return;

            //Clear dummy data
            item.Items.Clear();

            //Get full path
            var fullpath = (string)item.Tag;
            #endregion

            #region Get Folders
            //Create a blank list for directories
            var directories = new List<string>();

            //Try and get directories from the folder
            //ignoring any issues doing so
            try
            {
                var dirs = Directory.GetDirectories(fullpath);
                if (dirs.Length > 0)
                    directories.AddRange(dirs);
            }
            catch { }

            //For each directory...
            directories.ForEach(directoryPath =>
            {
                //Create directory item
                var subItem = new TreeViewItem()
                {
                    //Set header as folder name
                    Header = GetFileFolderName(directoryPath),
                    //and tag as full path
                    Tag = directoryPath
                };

                //Add dummy item so we can expand folder
                subItem.Items.Add(null);

                subItem.Expanded += Folder_Expanded;

                //Add this item to the parent
                item.Items.Add(subItem);
            });
            #endregion

            #region Get Files
            //Create a blank list for files
            var files = new List<string>();

            //Try and get files from the folder
            //ignoring any issues doing so
            try
            {
                var fs = Directory.GetFiles(fullpath);
                if (fs.Length > 0)
                    files.AddRange(fs);
            }
            catch { }

            //For each file...
            files.ForEach(filePath =>
            {
                //Create file item
                var subItem = new TreeViewItem()
                {
                    //Set header as file name
                    Header = GetFileFolderName(filePath),
                    //and tag as full path
                    Tag = filePath
                };

              
                //Add this item to the parent
                item.Items.Add(subItem);
            });
            #endregion
        }
        #endregion

      
    }
}
