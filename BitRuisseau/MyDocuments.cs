using BitRuisseau.Classes;
using System.Reflection;

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

        private void populateDataGrid()
        {
            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\audios";
            string[] filePaths = Directory.GetFiles(path);

            filePaths.ToList().ForEach(filePath =>
            {
                var tfile = TagLib.File.Create(filePath);
                string title = tfile.Tag.Title;
                string artist = tfile.Tag.FirstArtist;
                long size = new FileInfo(filePath).Length;
                TimeSpan duration = new TimeSpan(tfile.Properties.Duration.Hours, tfile.Properties.Duration.Minutes, tfile.Properties.Duration.Seconds);
                switch (tfile.Properties.MediaTypes)
                {
                    case TagLib.MediaTypes.Audio:
                        mediaLibrary.Add(new Audio(title, artist, size, duration));
                        break;
                    case TagLib.MediaTypes.Video:
                        mediaLibrary.Add(new Video(title, artist, size, duration));
                        break;
                    case TagLib.MediaTypes.Photo:
                        mediaLibrary.Add(new Photo(title, artist, size));
                        break;
                }
            });

            DataGrid.DataSource = mediaLibrary;
        }

        private void OpenNetworkSelection(object sender, EventArgs e)
        {
            networkSelection = new NetworkSelection();
            networkSelection.ShowDialog();
        }

        private void ExploreButton_Click(object sender, EventArgs e)
        {
            explore = new Explore();
            explore.Show();
            this.Hide();
            explore.BringToFront();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
