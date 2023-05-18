using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proves1.model
{
    public class Jugador
    {
        public string Nom { get; set; }
        public string Cognom { get; set; }
        public int Dorsal { get; set; }

        public Jugador(string nom, string cognom, int dorsal)
        {
            Nom = nom;
            Cognom = cognom;
            Dorsal = dorsal;
        }
    }
}
