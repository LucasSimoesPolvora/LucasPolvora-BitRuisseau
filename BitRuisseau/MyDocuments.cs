using BitRuisseau.Classes;
using System.Reflection;

namespace BitRuisseau
{
    public partial class MyDocuments : Form
    {
        public List<Media> mediaLibrary= new List<Media>();
        public MyDocuments()
        {
            InitializeComponent();
        }

        private void OnPageLoad(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\audios";
            string[] filePaths = Directory.GetFiles(path);

            filePaths.ToList().ForEach(filePath =>
            {
                var tfile = TagLib.File.Create(filePath);
                string title = tfile.Tag.Title;
                string author = tfile.Tag.FirstArtist;
                switch (tfile.Properties.MediaTypes)
                {
                    case TagLib.MediaTypes.Audio:
                        //mediaLibrary.Add(new Audio());
                        break;
                    case TagLib.MediaTypes.Video:

                        break;
                    case TagLib.MediaTypes.Photo:

                        break;
                }
            });
        }
    }
}
