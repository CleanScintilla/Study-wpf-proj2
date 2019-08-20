namespace WpfApp1
{
    /// <summary>
    /// Information about a directory item such as a drive, a file or a folder
    /// </summary>
    public class DirectoryItem
    {
        /// <summary>
        /// The Type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }
        /// <summary>
        /// The absolute path for this item
        /// </summary>
        public string FullPath { get; set; }
        /// <summary>
        /// The name of this directory item
        /// </summary>
        public string Name { get { return DirectoryStructure.GetFileFolderName(this.FullPath); } }
    }
}
