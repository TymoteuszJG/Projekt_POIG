using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Poig.Model
{
    class Gry
    {
        public int id_gry
        {
            get;
            set;
        }


        public string nazwa_gry
        {
            get;
            set;
        }

        public int id_Typu
        {
            get;
            set;
        }


        public Gry(int ID_GRY, string NAZWA_GRY, int ID_TYPU)
        {
            id_gry = ID_GRY;
            nazwa_gry = NAZWA_GRY;
            id_Typu = ID_TYPU;
        }

        public override string ToString()
        {
            return $"{id_gry} {nazwa_gry} {id_Typu}";
        }
    }
}
