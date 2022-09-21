using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobel
{
    class Dij
    {
        readonly int ev; //mivel beolvasott adatot tartalmaz, ezért csak olvashatóvá tesszük, így nem lesznek set-ek és get-ek
        readonly string tipus;
        readonly string keresztnev;
        readonly string vezeteknev;

        public int Ev => ev;

        public string Tipus => tipus;

        public string KeresztNev => keresztnev;

        public string VezetekNev => vezeteknev;

        public Dij(int ev, string tipus, string keresztNev, string vezetekNev)
        {
            this.ev = ev;
            this.tipus = tipus;
            this.keresztnev = keresztNev;
            this.vezeteknev = vezetekNev;
        }
    }
}
