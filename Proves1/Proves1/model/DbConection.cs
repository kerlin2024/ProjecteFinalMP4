using MySql.Data.MySqlClient;
using System.Data;

namespace Proves1.model
{
    public static class DbConection
    {
        private const string Server = "db4free.net";
        private const string Port = "3306";
        private const string Database = "projectefinal";
        private const string Username = "kerlyn_murillo";
        private const string Password = "kerlin11E";

        private const string ConnectionString = "Server=" + Server + ";Port=" + Port + ";Database=" + Database + ";Uid=" + Username + ";Pwd=" + Password + ";OldGuids=true";

        private static MySqlConnection? connection;

        public static bool Connectar()
        {
            connection = new MySqlConnection(ConnectionString);

            try
            {
                connection.Open();
                return true;
                Console.WriteLine("Conecció a la base de dades completada");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                return false;
            }
        }

        public static void Disconnect()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
                Console.WriteLine("Desconecció Completada");
            }
        }

        internal static void InsertClub(Club club)
        {
            try
            {
                using (connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    string Query = "Insert into Club (id, nom, divisio) Values (@id, @nom, @divisio);";

                    using (MySqlCommand cmd = new MySqlCommand(Query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", club.Id);
                        cmd.Parameters.AddWithValue("@nom", club.Nom);
                        cmd.Parameters.AddWithValue("@divisio", club.Divisio);

                        int RowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine("Registres insertats : " + RowsAffected);
                    }
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al Insertar un Club" + ex.Message);
            }

            try
            {
                using (connection = new MySqlConnection(ConnectionString))
                {

                    connection.Open();
                    string QueryEntrenador = "Insert into Entrenador (id, club_id, nom, cognom) Values (@id, @club_id, @nomEntrenador, @cognomEntrenador);";

                    using (MySqlCommand cmd = new MySqlCommand(QueryEntrenador, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", club.Entrenador.Id);
                        cmd.Parameters.AddWithValue("@club_id", club.Id);
                        cmd.Parameters.AddWithValue("@nomEntrenador", club.Entrenador.Nom);
                        cmd.Parameters.AddWithValue("@cognomEntrenador", club.Entrenador.Cognom);
                        int RowsAffected = cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al Insertar un Entrenador" + ex.Message);
            }

        }

        internal static void InsertJugadors(int idClub, Jugador jugadorNode)
        {
            try
            {
                using (connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    string Query = "Insert into Jugador (dorsal, club_id, nom, cognom) Values (@dorsal, @club_id, @nom, @cognom);";

                    using (MySqlCommand cmd = new MySqlCommand(Query, connection))
                    {
                        cmd.Parameters.AddWithValue("@dorsal", jugadorNode.Dorsal);
                        cmd.Parameters.AddWithValue("@club_id", idClub);
                        cmd.Parameters.AddWithValue("@nom", jugadorNode.Nom);
                        cmd.Parameters.AddWithValue("@cognom", jugadorNode.Cognom);
                        int RowsAffected = cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (MySqlException ex) {
                Console.WriteLine("Error al insertar Un jugador" + ex.Message);            
            }
        }
    }
}
