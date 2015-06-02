using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    public interface ITwitterSerializer
    {
       // string SerializeTwitter(ObiektDanych twitt);
        List<ObiektDanych> DeserializeTwitter(string stream);
    }
}
