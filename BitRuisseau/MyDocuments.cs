using BitRuisseau.Classes;
using System.Diagnostics;
using System.Reflection;
using TagLib;

namespace BitRuisseau
{
    public partial class MyDocuments : Form
    {
        public List<Media> mediaLibrary = new List<Media>();
        NetworkSelection networkSelection;
        Explore explore;
        public MyDocuments()
        {
            InitializeComponent();
            populateDataGrid();
        }

        /// <summary>
        /// Populates the datagrid that is in the forms
        /// </summary>
        private void populateDataGrid()
        {
            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\audios";
            string[] filePaths = Directory.GetFiles(path);

            filePaths.ToList().ForEach(filePath =>
            {
                var tfile = TagLib.File.Create(filePath);
                string title = tfile.Tag.Title ?? Path.GetFileNameWithoutExtension(filePath);
                string artist = tfile.Tag.FirstArtist;
                long size = new FileInfo(filePath).Length;
                TimeSpan duration = new TimeSpan(tfile.Properties.Duration.Hours, tfile.Properties.Duration.Minutes, tfile.Properties.Duration.Seconds);
                switch (tfile.Properties.MediaTypes)
                {
                    case TagLib.MediaTypes.Audio:
                        mediaLibrary.Add(new Media(title, artist, size, duration, MediaTypes.Audio));
                        break;
                    case TagLib.MediaTypes.Video:
                        mediaLibrary.Add(new Media(title, artist, size, duration, MediaTypes.Video));
                        break;
                    case TagLib.MediaTypes.Photo:
                        mediaLibrary.Add(new Media(title, artist, size, null, MediaTypes.Photo));
                        break;
                }
            });
            DataGrid.DataSource = mediaLibrary;
        }

        /// <summary>
        /// Open the forms page that will allow us to create a connection to the broker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenNetworkSelection(object sender, EventArgs e)
        {
            networkSelection = new NetworkSelection();
            networkSelection.ShowDialog();
        }

        /// <summary>
        /// Opens the forms page that will allow us to see the medias available in the network
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExploreButton_Click(object sender, EventArgs e)
        {
            explore = new Explore();
            explore.Show();
            this.Hide();
            explore.BringToFront();
        }

        /// <summary>
        /// Closes the app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
