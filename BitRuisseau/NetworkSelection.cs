using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitRuisseau
{
    public partial class NetworkSelection : Form
    {
        public IMqttClient _mqttClient { get; set; }
        public NetworkSelection()
        {
            InitializeComponent();
        }

        async private void ConnectionButton(object sender, EventArgs e)
        {
            if(HostTextBox.Text == "" || UsernameTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                MessageBox.Show("There is some blank information you need to complete",
                    "Bad Inputs",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            MqttFactory factory = new MqttFactory();

            _mqttClient = factory.CreateMqttClient();

            MqttClientOptions options = new MqttClientOptionsBuilder()
                .WithTcpServer(HostTextBox.Text, Convert.ToInt32(PortValue.Value))
                .WithCredentials(UsernameTextBox.Text, PasswordTextBox.Text)
                .WithClientId(Guid.NewGuid().ToString())
                .Build();
            try
            {
                var connectResult = _mqttClient.ConnectAsync(options).Result;
                await _mqttClient.SubscribeAsync("test");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Failed to connect to the MQTT broker. Reason: {ex}", 
                    "Connection failed", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);        
            }

            
            this.Close();
        }
    }
}
