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
using BitRuisseau.util;

namespace BitRuisseau
{
    public partial class Explore : Form
    {
        MyDocuments? md;
        NetworkSelection networkSelection;

        public Explore(Broker broker)
        {
            if (broker == null)
            {
                networkSelection = new NetworkSelection();
                networkSelection.ShowDialog();
                broker = networkSelection.returnBroker();
            }
            InitializeComponent();
            getMessages(broker);
        }
        private void MyDocumentsButton_Click(object sender, EventArgs e)
        {
            md = new MyDocuments();
            md.Show();
            this.Hide();
        }

        private void getMessages(Broker? broker)
        {
            broker.getMessages();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
