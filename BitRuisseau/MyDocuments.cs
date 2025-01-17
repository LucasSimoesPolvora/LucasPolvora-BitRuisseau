using BitRuisseau.Classes;
using BitRuisseau.util;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using TagLib;

namespace BitRuisseau
{
    public partial class MyDocuments : Form
    {
        public List<Media> mediaLibrary = new List<Media>();
        NetworkSelection networkSelection;
        Explore explore;
        Broker broker;
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
            PopulateMyCatalog();
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
            broker = networkSelection.returnBroker();
        }

        /// <summary>
        /// Opens the forms page that will allow us to see the medias available in the network
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExploreButton_Click(object sender, EventArgs e)
        {
            explore = new Explore(broker);
            explore.Show();
            this.Hide();
            explore.BringToFront();

        }

        public void PopulateMyCatalog()
        {
            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\medias";
            string[] filePaths = Directory.GetFiles(path);
            filePaths.ToList().ForEach(filePath =>
            {
                var tfile = TagLib.File.Create(filePath);
                string title = Path.GetFileNameWithoutExtension(filePath);
                string artist = tfile.Tag.FirstArtist ?? "Unknown";
                long size = new FileInfo(filePath).Length;
                string type = Path.GetExtension(filePath);
                string minutes = tfile.Properties.Duration.Minutes < 10 ? "0" + tfile.Properties.Duration.Minutes : tfile.Properties.Duration.Minutes.ToString();
                string seconds = tfile.Properties.Duration.Seconds < 10 ? "0" + tfile.Properties.Duration.Seconds : tfile.Properties.Duration.Seconds.ToString();
                string hours = tfile.Properties.Duration.Hours < 10 ? "0" + tfile.Properties.Duration.Hours : tfile.Properties.Duration.Hours.ToString();
                string duration = $"{hours}:{minutes}:{seconds}";
                switch (tfile.Properties.MediaTypes)
                {
                    case TagLib.MediaTypes.Audio:
                        mediaLibrary.Add(new Media(title, artist, size, duration, type));
                        break;
                    case TagLib.MediaTypes.Video:
                        mediaLibrary.Add(new Media(title, artist, size, duration, type));
                        break;
                    case TagLib.MediaTypes.Photo:
                        mediaLibrary.Add(new Media(title, artist, size, null, type));
                        break;
                }
            });
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

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\medias\\" + DataGrid.CurrentRow.Cells[0].Value.ToString() + DataGrid.CurrentRow.Cells[4].Value.ToString();

            mediaPlayer mp = new mediaPlayer(path);

            mp.Show();
        }
    }
}
