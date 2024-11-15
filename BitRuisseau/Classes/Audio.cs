using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitRuisseau.Classes
{
    public class Audio(string title, string author, int size, TimeSpan duration) : Media(title, author, size)
    {
        private TimeSpan _duration = duration;

        // Property to get or set the duration
        public TimeSpan Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
    }
}
