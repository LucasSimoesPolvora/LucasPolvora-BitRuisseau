﻿using System;
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
    public partial class Explore : Form
    {
        MyDocuments md;
        public Explore()
        {
            InitializeComponent();
        }
        private void MyDocumentsButton_Click(object sender, EventArgs e)
        {
            md = new MyDocuments();
            md.Show();
            this.Hide();
        }
    }
}
