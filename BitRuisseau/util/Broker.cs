using MQTTnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitRuisseau.Classes;
using System.Diagnostics;
using System.Text.Json;
using BitRuisseau.Classes.envelops;
using MQTTnet.Protocol;
using BitRuisseau.Interface;
using System.Windows.Forms;

namespace BitRuisseau.util
{
    public class Broker
    {
        private IMqttClient mqttClient;
        string mqttHost;
        int mqttPort;
        string mqttUsername;
        string mqttPassword;
        string _clientID;
        string _topic = "test";

        MyDocuments _md = new MyDocuments();

        /// <summary>
        /// Create a connection to the broker using mqttnet
        /// </summary>
        /// <param name="host">host of the broker</param>
        /// <param name="username">the username to connect to the broker</param>
        /// <param name="password">the password of the username to connect to the broker</param>
        /// <param name="port">The port of the host where the broker is</param>
        async public void connectionToTheBroker(string host, string username, string password, int port)
        {
            if (host == "" || username == "" || password == "")
            {
                MessageBox.Show("There is some blank information you need to complete",
                    "Bad Inputs",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            mqttHost = host;
            mqttPort = port;
            mqttUsername = username;
            mqttPassword = password;
            _clientID = Guid.NewGuid().ToString();

            MqttClientFactory factory = new MqttClientFactory();
            mqttClient = factory.CreateMqttClient();
            

            MqttClientOptions options = new MqttClientOptionsBuilder()
                .WithTcpServer(mqttHost, mqttPort)
                .WithCredentials(mqttUsername, mqttPassword)
                .WithClientId(_clientID)
                .Build();
            try
            {
                var connectResult = mqttClient.ConnectAsync(options).Result;
                if (connectResult.ResultCode == MqttClientConnectResultCode.Success)
                {
                    MessageBox.Show("Connected to MQTT broker successfully.");

                    // Se Subscribe with "No Local" option
                    var subscribeOptions = new MqttClientSubscribeOptionsBuilder()
                        .WithTopicFilter(f =>
                        {
                            f.WithTopic(_topic);
                            f.WithNoLocal(true); // Ensure the client does not receive its own messages
                        })
                        .Build();
                    // S'abonner à un topic
                    await mqttClient.SubscribeAsync(subscribeOptions);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect to the MQTT broker. Reason: {ex}",
                    "Connection failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public void AskForCatalog()
        {
            if (mqttHost == null || mqttUsername == null || mqttPassword == null)
            {
                MessageBox.Show("You did not established a connection to the broker", "connection not established", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public void getMessages()
        {
            if (mqttClient != null)
            {
                mqttClient.ApplicationMessageReceivedAsync += e =>
                {
                    ReceiveMessages(e);
                    return Task.CompletedTask;
                };
            }
        }

        public void ReceiveMessages(MqttApplicationMessageReceivedEventArgs message)
        {
            try
            {
                Debug.WriteLine($"Received message: {Encoding.UTF8.GetString(message.ApplicationMessage.Payload)}");
                GenericEnvelope envelope = JsonSerializer.Deserialize<GenericEnvelope>(Encoding.UTF8.GetString(message.ApplicationMessage.Payload));
                Debug.Write(envelope);
                if (_clientID == envelope.SenderId) return;

                switch(envelope.MessageType)
                {
                    case MessageType.ENVOIE_CATALOGUE:
                        break;
                    case MessageType.ENVOIE_FICHIER:
                        break;
                    case MessageType.DEMANDE_CATALOGUE:
                        EnvoieCatalogue envoieCatalogue = new EnvoieCatalogue();
                        _md.PopulateMyCatalog();
                        envoieCatalogue.Content = _md.mediaLibrary;

                        SendMessage(envoieCatalogue, MessageType.ENVOIE_CATALOGUE);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while receiving messages", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async public void SendMessage(IJsonSerializableMessage content, MessageType messageType)
        {
            GenericEnvelope envelop = new GenericEnvelope();
            envelop.SenderId = _clientID;
            envelop.EnveloppeJson = content.ToJson();
            envelop.MessageType = messageType;

            var a = new MqttApplicationMessageBuilder()
                            .WithTopic(_topic)
                            .WithPayload(JsonSerializer.Serialize(envelop))
                            .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce)
                            .WithRetainFlag()
                            .Build();
            await mqttClient.PublishAsync(a);
            await Task.Delay(1000);
        }
    }
}
