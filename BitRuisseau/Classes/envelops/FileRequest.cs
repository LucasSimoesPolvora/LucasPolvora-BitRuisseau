using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BitRuisseau.Classes.envelops
{
    public class FileRequest
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
