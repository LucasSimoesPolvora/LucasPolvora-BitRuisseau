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
    public partial class mediaPlayer : Form
    {
        public mediaPlayer(string path)
        {
            InitializeComponent();
            
            if(File.Exists(path))
            {
                axWindowsMediaPlayer1.URL = path;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            else
            {
                MessageBox.Show("File not found");
            }

        }

    }
}
