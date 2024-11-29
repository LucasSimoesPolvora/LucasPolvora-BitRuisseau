using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitRuisseau.Classes.envelops
{
    public class EnvoieFichier : GenericEnvelope
    {
        private string _content;

        public string Content { get => _content; set => _content = value; }
    }
}
