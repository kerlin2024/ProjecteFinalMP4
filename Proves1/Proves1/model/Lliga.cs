using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Proves1.model
{
    public static class Lliga
    {
        private static List<Club> Clubs = new List<Club>();

        public static bool carregarModel(string filepath)
        {
            bool bres = false;
            XmlDocument document = new XmlDocument();
            document.Load(filepath);
            XmlNodeList ElementsLliga = document.SelectNodes("//club");

            foreach (XmlNode club in ElementsLliga)
            {
                Club Club = new Club();
                Club.Nom = club.Attributes["nom"].Value;
                Club.Divisio = int.Parse(club.Attributes["divisio"].Value);
                Club.id = int.Parse(club.Attributes["id"].Value);
                Entrenador EntrenadorObj = new Entrenador();
                XmlNode entrenadorNode = club.SelectSingleNode("entrenador");
                EntrenadorObj.Nom = entrenadorNode.SelectSingleNode("nom").InnerText;
                EntrenadorObj.Cognom = entrenadorNode.SelectSingleNode("cognom").InnerText;
                Club.Entrenador = EntrenadorObj;

                XmlNode capitanNode = club.SelectSingleNode("jugadors/jugador[@capita='True']");
                if (capitanNode != null)
                {
                    Jugador capitan = new Jugador();
                    capitan.Nom = capitanNode.SelectSingleNode("nom").InnerText;
                    capitan.Cognom = capitanNode.SelectSingleNode("cognom").InnerText;
                    capitan.Dorsal = int.Parse(capitanNode.SelectSingleNode("dorsal").InnerText);
                    Club.Capita = capitan;
                }

                XmlNodeList jugadorNodes = club.SelectNodes("jugadors/jugador");
                List<Jugador> jugadores = new List<Jugador>();
                foreach (XmlNode jugadorNode in jugadorNodes)
                {
                    Jugador jugador = new Jugador();
                    jugador.Nom = jugadorNode.SelectSingleNode("nom").InnerText;
                    jugador.Cognom = jugadorNode.SelectSingleNode("cognom").InnerText;
                    jugador.Dorsal = int.Parse(jugadorNode.SelectSingleNode("dorsal").InnerText);
                    jugadores.Add(jugador);
                }

                Club.Jugadors = jugadores;
                Clubs.Add(Club);
                DbConection.Connectar();
                DbConection.Disconnect();
            }
            return bres;
        }

        
    }

}
