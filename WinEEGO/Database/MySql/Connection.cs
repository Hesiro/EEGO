using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Database.MySql
{
    class Connection
    {
        private static Connection instancia = null;
        private static Object padlock = new object();
        public static Connection Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new Connection();
                    }
                }
                return instancia;
            }
        }

        MySqlConnection conexionMySql = null;
        public MySqlConnection MiConexionMySql
        {
            get
            {
                if (conexionMySql == null)
                {
                    conexionMySql = new MySqlConnection
                    {
                        ConnectionString = Parameter.Instancia.StringConnection
                    };
                    conexionMySql.Open();
                    return conexionMySql;
                }
                else
                {
                    if (conexionMySql.State == System.Data.ConnectionState.Closed)
                    {
                        conexionMySql.Open();
                    }
                    return conexionMySql;
                }
            }
        }
        public bool EstadoConexion()
        {
            try
            {
                var a = MiConexionMySql;
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister("MySql.Connection.EstadoConexion: " + ex.Message);
                return false;
            }

        }
    }
}
