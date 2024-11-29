﻿using System;
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
        MyDocuments md;
        NetworkSelection ns;
        Broker broker;
        public Explore()
        {
            InitializeComponent();
            getMessages();
        }
        private void MyDocumentsButton_Click(object sender, EventArgs e)
        {
            md = new MyDocuments();
            md.Show();
            this.Hide();
        }

        private void getMessages()
        {
            ns = new NetworkSelection();

            /*if(broker.mqttClient != null)
            {
                broker.mqttClient.ApplicationMessageReceivedAsync += e =>
                {
                    Debug.WriteLine($"Received message: {Encoding.UTF8.GetString(e.ApplicationMessage.PayloadSegment)}");
                    return Task.CompletedTask;
                };
            }*/
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
