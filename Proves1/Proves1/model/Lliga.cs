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
    }

    public static bool carregarModel(string filepath)
    {
        bool bres = false;
                XmlDocument document = new XmlDocument();
                document.LoadXml(filepath);
                XmlNodeList ElementsLliga = document.SelectNodes("//club");
                
                foreach (XmlNode club in ElementsLliga)
                {
                    Club Club = new Club();
                    Club.Nom = club.Attributes["nom"].InnerText;
                    Club.Divisio = int.Parse(club.Attributes["nom"].Value);
                    Entrenador EntrenadorObj = new Entrenador();
                    EntrenadorObj.Nom = club.SelectSingleNode("entrenador/nom").InnerText;
                    EntrenadorObj.Cognom = club.SelectSingleNode("entrenador/cognom").InnerText;
                    Club.Entrenador = EntrenadorObj;

                    XmlNode capitanNode = clubNode.SelectSingleNode("jugadors/jugador[@capita='True']");
                    if (capitanNode != null)
                    {
                        Jugador capitan = new Jugador();
                        capitan.Nombre = capitanNode.SelectSingleNode("nom").InnerText;
                        capitan.Apellido = capitanNode.SelectSingleNode("cognom").InnerText;
                        capitan.Dorsal = int.Parse(capitanNode.SelectSingleNode("dorsal").InnerText);
                        club.Capitan = capitan;
                    }

                    XmlNodeList jugadorNodes = clubNode.SelectNodes("jugadors/jugador");
                    List<Jugador> jugadores = new List<Jugador>();
                    foreach (XmlNode jugadorNode in jugadorNodes)
                    {
                        Jugador jugador = new Jugador();
                        jugador.Nombre = jugadorNode.SelectSingleNode("nom").InnerText;
                        jugador.Apellido = jugadorNode.SelectSingleNode("cognom").InnerText;
                        jugador.Dorsal = int.Parse(jugadorNode.SelectSingleNode("dorsal").InnerText);
                        jugadores.Add(jugador);
                    }

                    Club.Jugadors = jugadores;
        }
        
        return bres;
    }

}
