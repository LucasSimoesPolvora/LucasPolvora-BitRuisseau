using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitRuisseau.Classes
{
    public class Video(string title, string author, long size, TimeSpan duration) : Media(title, author, size)
    {
        private TimeSpan _duration = duration;
        private string _type = "video";

        // Property to get or set the duration
        public TimeSpan Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        public string type
        {
            get { return _type; }
        }
    }
}
