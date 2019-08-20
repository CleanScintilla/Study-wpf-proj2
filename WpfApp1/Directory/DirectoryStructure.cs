namespace WpfApp1
{
    /// <summary>
    /// A helper class to query information about directories
    /// </summary>
    public static class DirectoryStructure
    {
        public static List<DirectoryItem> GetLogicalDrives()
        {
            //Get every logical Drive on the machine
            foreach (var drive in Directory.GetLogicalDrives())
            {
                //Create a new item for it
                var item = new TreeViewItem()
                {
                    //Set the header
                    Header = drive,
                    //And the full path
                    Tag = drive
                };

                //Add summary item
                item.Items.Add(null);

                //Listen out for the item being expanded
                item.Expanded += Folder_Expanded;

                //Add it to the main tree-view
                FolderView.Items.Add(item);
            }
        }
        #region Helpers
        /// <summary>
        /// Find file or folder name from the full path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {

            //if we have no path return empty
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            //Make all slashes backslashes
            var normalizedPath = path.Replace('/', '\\');

            //Find the last \ in the path
            var lastIndex = normalizedPath.LastIndexOf('\\');

            //If we don`t find \, return the path itself
            if (lastIndex <= 0)
                return path;

            //return the name after \
            return path.Substring(lastIndex + 1);
        }
        #endregion
    }
}
