using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Database.MySql
{
    class Departamento
    {
        private static Departamento instancia = null;
        private static Object padlock = new object();
        public static Departamento Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new Departamento();
                    }
                }
                return instancia;
            }
        }
        public List<Models.Departamento> List()
        {
            List<Models.Departamento> lista = new List<Models.Departamento>();

            try
            {
                using (MySqlConnection Conex = Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand dbComand = new MySqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_Departamento"
                    };

                    MySqlDataReader myReader = dbComand.ExecuteReader();

                    while (myReader.Read())
                    {
                        Models.Departamento oParametros = new Models.Departamento
                        {
                            Id = (myReader.IsDBNull(0) ? 0 : myReader.GetInt32(0)),
                            Codigo = (myReader.IsDBNull(1) ? "" : myReader.GetString(1)),
                            NombreDepartamento = (myReader.IsDBNull(2) ? "" : myReader.GetString(2))
                        };
                        lista.Add(oParametros);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister("MySql.Departamento.List: " + ex.Message);
            }
            return lista;
        }
    }
}
