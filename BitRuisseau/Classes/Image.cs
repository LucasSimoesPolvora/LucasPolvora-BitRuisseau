using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitRuisseau.Classes
{
    class Image(string title, string author, int size) : Media(title, author, size)
    {
        private string _type = "image";
        public string type
        {
            get { return _type; }
        }
    }
}
