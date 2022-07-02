using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Database.MsSql
{
    class Connection
    {
        private static Connection instancia = null;
        private static object padlock = new object();
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

        SqlConnection conexionMsSql;

        public SqlConnection MiConexionMsSql
        {
            get {
                if (conexionMsSql == null)
                {
                    conexionMsSql = new SqlConnection
                    {
                        ConnectionString = Parameter.Instancia.StringConnection
                    };
                    conexionMsSql.Open();
                    return conexionMsSql;
                }
                else
                {
                    if (conexionMsSql.State == System.Data.ConnectionState.Closed)
                    {
                        conexionMsSql.ConnectionString = Parameter.Instancia.StringConnection;
                        conexionMsSql.Open();
                    }
                    return conexionMsSql;
                }
            }
        }
        public bool EstadoConexion()
        {
            try
            {
                var a = MiConexionMsSql;
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister("MsSql.Connection.EstadoConexion: " + ex.Message);
                return false;
            }

        }
    }
}
