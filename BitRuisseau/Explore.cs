using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BitRuisseau.Classes;
using BitRuisseau.util;
using TagLib.Flac;

namespace BitRuisseau
{
    public partial class Explore : Form
    {
        MyDocuments? md = new MyDocuments();
        NetworkSelection? networkSelection;
        public List<Media> ExploreMediaLibrary = new List<Media>();
        Broker? _broker;

        public Explore(Broker broker)
        {
            if (_broker == null)
            {
                networkSelection = new NetworkSelection();
                networkSelection.ShowDialog();
                broker = networkSelection.returnBroker();
                _broker = broker;
            }

            _broker.OnNewMediaReceived += UpdateMediaLibrary;

            InitializeComponent();
            getMessages();
            PopulateDataGrid();
        }
        private void MyDocumentsButton_Click(object sender, EventArgs e)
        {
            md = new MyDocuments();
            md.Show();
            this.Hide();
        }

        private void getMessages()
        {
            _broker.getMessages();
            PopulateDataGrid();
        }

        public void PopulateDataGrid()
        {
            PopulateMediaLibrary();
            DataGridMedia.DataSource = ExploreMediaLibrary;
        }

        public void PopulateMediaLibrary()
        {
            md.PopulateMyCatalog();
            //ExploreMediaLibrary = md.mediaLibrary;
            foreach (var sender in _broker._senderAndTheirCatalog)
            {
                sender.Value.ForEach(media =>
                {
                    ExploreMediaLibrary.Add(media);
                });
            }
        }

        private void UpdateMediaLibrary()
        {
            this.Invoke(new Action(() =>
            {

                ExploreMediaLibrary.Clear();
                PopulateMediaLibrary();

                DataGridMedia.DataSource = null; // Reset the DataSource

                
                DataGridMedia.DataSource = ExploreMediaLibrary; // Reassign the updated list

            }));
            // Ensure updates happen on the UI thread
            /*if (InvokeRequired)
            {
                Invoke(new Action(UpdateMediaLibrary));
                return;
            }*/

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                Media chosenMeida = ExploreMediaLibrary[e.RowIndex];
                _broker.AskForMedia(chosenMeida);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Erreur : Téléchargement du fichier impossible", "Échec du téléchargement du fichier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridMedia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridMedia_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ExploreButton_Click(object sender, EventArgs e)
        {
            try
            {
                int result;
                Int32.TryParse(searchBar.Text, out result);
                Media chosenMeida = ExploreMediaLibrary[result];
                _broker.AskForMedia(chosenMeida);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Erreur : Téléchargement du fichier impossible", "Échec du téléchargement du fichier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
