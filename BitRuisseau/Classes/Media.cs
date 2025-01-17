﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TagLib;
using TagLib.Asf;

namespace BitRuisseau.Classes
{
    public class Media
    {
        private string _title;
        private string _artist;
        private long _size;
        private string _duration;
        private string _type;

        public Media(string title, string artist, long size, string duration, string type)
        {
            _title = title;
            _artist = artist;
            _size = size;
            _duration = duration;
            _type = type;
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
        public long Size
        {
            get { return _size; }
            set { _size = value; }
        }
        public string Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
