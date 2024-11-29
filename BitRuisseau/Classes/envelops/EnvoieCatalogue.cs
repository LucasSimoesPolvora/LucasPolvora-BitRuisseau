using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib.Flac;

namespace BitRuisseau.Classes.envelops
{
    public class EnvoieCatalogue
    {
        private List<Media> _content;

        public List<Media> Content { get => _content; set => _content = value; }
    }
}
