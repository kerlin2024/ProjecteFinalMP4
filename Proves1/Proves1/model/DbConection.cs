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
    }
}
