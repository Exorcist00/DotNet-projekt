using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    class NoTwittsException:Exception
    {
        public NoTwittsException()
        {

        }

        public string GetErrMess()
        {
            return "Brak wyników do wyświetlenia.";
        }
    }
}
