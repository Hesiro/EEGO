using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppTachito.Database.MySql
{
    class Usuario
    {
        static Usuario instancia = null;
        static readonly object padlock = new object();
        static readonly string referencia = "MySql.Usuario.";
        public static Usuario Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new Usuario();
                    }
                }
                return instancia;
            }
        }
        public Models.Usuario Login(Models.Usuario obj)
        {
            Models.Usuario status = new Models.Usuario();
            try
            {
                using (MySqlConnection Conex = Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand dbComand = new MySqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_checkUsuario"                        
                    };
                    dbComand.Parameters.Add(new MySqlParameter("pUsuario", obj.NombreUsuario));
                    dbComand.Parameters.Add(new MySqlParameter("pClave", obj.Password));

                    MySqlDataReader dataReader = dbComand.ExecuteReader();

                    if (dataReader.HasRows)
                        while (dataReader.Read())
                        {
                            status.NombreUsuario = (dataReader.IsDBNull(0) ? "" : dataReader.GetString(0));
                            status.AccesoEGO = (dataReader.IsDBNull(2) ? Models.TipoUsuario.Ninguno : (Models.TipoUsuario)dataReader.GetInt32(2));
                            status.PerteneceA = new Models.Departamento
                            {
                                Id = (dataReader.IsDBNull(3) ? 0 : dataReader.GetInt32(3)),
                                NombreDepartamento = (dataReader.IsDBNull(4) ? "" : dataReader.GetString(4))
                            };
                        }
                    else
                        status = null;
                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "Login: " + ex.Message);
                status = null;
            }
            return status;
        }
    }
}
