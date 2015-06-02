using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    public class ObiektDanych
    {
        public string Name { get; set; }

        public string Date { get; set; }

        public string Text { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
