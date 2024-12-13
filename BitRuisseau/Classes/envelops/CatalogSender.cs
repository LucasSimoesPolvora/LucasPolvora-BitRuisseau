using BitRuisseau.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TagLib.Flac;

namespace BitRuisseau.Classes.envelops
{
    public class CatalogSender : IJsonSerializableMessage
    {
        private List<Media> _content;

        public List<Media> Content { get => _content; set => _content = value; }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
