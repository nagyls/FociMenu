using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Focimeccs
{
    internal class CsapatEredmeny
    {
        public string csapat;
        public int pontok;
        public int gyozelem;
        public int vereseg;
        public int dontetlen;

        public CsapatEredmeny(string csapat)
        {
            this.csapat = csapat;
        }
    }
}
