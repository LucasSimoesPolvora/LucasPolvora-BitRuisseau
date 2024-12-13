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
            DataGrid.DataSource = ExploreMediaLibrary;
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
            // Ensure updates happen on the UI thread
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateMediaLibrary));
                return;
            }

            ExploreMediaLibrary.Clear();
            foreach (var sender in _broker._senderAndTheirCatalog)
            {
                ExploreMediaLibrary.AddRange(sender.Value);
            }

            DataGrid.DataSource = null; // Reset the DataSource
            DataGrid.DataSource = ExploreMediaLibrary; // Reassign the updated list
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
