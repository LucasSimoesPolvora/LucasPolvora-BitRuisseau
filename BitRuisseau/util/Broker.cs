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
        string _clientID = "lucasSP";
        string _topic = "1234";

        public Dictionary<string, List<Media>> _senderAndTheirCatalog = new Dictionary<string, List<Media>>();

        public event Action? OnNewMediaReceived;

        MediaManagement mediaManagement = new MediaManagement();
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

                    SendMessage(null, MessageType.CATALOG_REQUEST);

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
                    await mqttClient.SubscribeAsync(_clientID);


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
            
        }

        public void AskForMedia(Media media)
        {
            FileRequest fileRequest = new FileRequest();
            fileRequest.FileName = media.Title + media.Type;

            SendMessage(fileRequest, MessageType.FILE_REQUEST, _senderAndTheirCatalog.First(keyValue => keyValue.Value.Contains(media)).Key);
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
                GenericEnvelope envelope = JsonSerializer.Deserialize<GenericEnvelope>(Encoding.UTF8.GetString(message.ApplicationMessage.Payload));
                if (_clientID == envelope.SenderId) return;

                switch(envelope.MessageType)
                {
                    case MessageType.CATALOG_SENDER:
                        var listOfMedias = JsonSerializer.Deserialize<CatalogSender>(envelope.EnvelopeJson);

                        if (_senderAndTheirCatalog.Keys.Contains(envelope.SenderId))
                        {
                            _senderAndTheirCatalog[envelope.SenderId] = listOfMedias.Content;
                        } else
                        {
                            _senderAndTheirCatalog.Add(envelope.SenderId, listOfMedias.Content);
                        }
                        OnNewMediaReceived?.Invoke();
                        break;
                    case MessageType.FILE_SENDER:
                        FileSender fileSender = JsonSerializer.Deserialize<FileSender>(envelope.EnvelopeJson);
                        mediaManagement.ConvertBase64ToMedia(fileSender);
                        break;
                    case MessageType.CATALOG_REQUEST:
                        CatalogSender envoieCatalogue = new CatalogSender();
                        _md.PopulateMyCatalog();
                        envoieCatalogue.Content = _md.mediaLibrary;
                        SendMessage(envoieCatalogue, MessageType.CATALOG_SENDER);
                        break;
                    case MessageType.FILE_REQUEST:
                        FileRequest fileRequest = JsonSerializer.Deserialize<FileRequest>(envelope.EnvelopeJson);
                        FileSender sender = new FileSender();
                        sender.Content = mediaManagement.ConvertMediaToBase64(fileRequest.FileName);
                        sender.FileInfo = _md.mediaLibrary.Find(media => (media.Title + media.Type).ToString() == fileRequest.FileName);
                        SendMessage(sender, MessageType.FILE_SENDER, envelope.SenderId);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while receiving messages", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async public void SendMessage(IJsonSerializableMessage content, MessageType messageType, string topic = "1234")
        {
            GenericEnvelope envelop = new GenericEnvelope();
            envelop.SenderId = _clientID;
            envelop.EnvelopeJson = content == null ? null : content.ToJson();
            envelop.MessageType = messageType;

            var a = new MqttApplicationMessageBuilder()
                            .WithTopic(topic)
                            .WithPayload(JsonSerializer.Serialize(envelop))
                            .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce)
                            .Build();
            await mqttClient.PublishAsync(a);
        }
    }
}
