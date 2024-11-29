using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitRuisseau.Interface
{
    public interface IJsonSerializableMessage
    {
        public string ToJson();
    }
}
