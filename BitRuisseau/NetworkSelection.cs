using MQTTnet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BitRuisseau.util;

namespace BitRuisseau
{
    public partial class NetworkSelection : Form
    {
        public Broker broker = new Broker();
        public NetworkSelection()
        {
            InitializeComponent();
        }

        private void ConnectionButton(object sender, EventArgs e)
        {
            broker.connectionToTheBroker(HostTextBox.Text, UsernameTextBox.Text, PasswordTextBox.Text, Convert.ToInt32(PortValue.Value));
            this.Close();
        }

        public Broker returnBroker()
        {
            return broker;
        }
    }
}
