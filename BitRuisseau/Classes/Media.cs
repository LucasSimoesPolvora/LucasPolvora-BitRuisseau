using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BitRuisseau.Classes
{
    public class Media
    {
        private string _title;
        private string _artist;
        private int _size;
        public Media(string title, string artist, int size)
        {
            _title = title;
            _artist = artist;
            _size = size;
        }

        public string Title 
        { 
            get { return _title; }
            set { _title = value; }
        }
        public string Artist
        {
            get { return _artist; }
            set { _artist = value; }
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }
    }
}
