using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proves1.model
{
    public class Club
    {
        public string Nom { get; set; }
        public int Divisio { get; set; }
        public Entrenador Entrenador { get; set; }
        public Jugador Capita { get; set; }
        public List<Jugador> Jugadors { get; set; }

        public Club(string nom, int divisio, Entrenador entrenador, Jugador capita, List<Jugador> jugadors)
        {
            Nom = nom;
            Divisio = divisio;
            Entrenador = entrenador;
            Capita = capita;
            Jugadors = jugadors;
        }

        public Club()
        {

        }
    }


}
