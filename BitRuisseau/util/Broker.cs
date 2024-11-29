﻿using MQTTnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitRuisseau.Classes;

namespace BitRuisseau.util
{
    public class Broker
    {
        private IMqttClient mqttClient;
        string mqttHost;
        int mqttPort;
        string mqttUsername;
        string mqttPassword;

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
                .WithClientId(Guid.NewGuid().ToString())
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
                            f.WithTopic("test");
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

        
    }
}