using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Database.MySql
{
    class Cultivo
    {
        private static Cultivo instancia = null;
        private static Object padlock = new object();
        public static Cultivo Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new Cultivo();
                    }
                }
                return instancia;
            }
        }
        public List<Models.Cultivo> List()
        {
            List<Models.Cultivo> lista = new List<Models.Cultivo>();

            try
            {
                using (MySqlConnection Conex = Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand dbComand = new MySqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_listCultivo"
                    };

                    MySqlDataReader myReader = dbComand.ExecuteReader();

                    while (myReader.Read())
                    {
                        Models.Cultivo oParametros = new Models.Cultivo
                        {
                            NombreCultivo = (myReader.IsDBNull(0) ? "" : myReader.GetString(0))
                        };
                        lista.Add(oParametros);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister("MySql.Cultivo.List: " + ex.Message);
            }
            return lista;
        }
        public bool Insert(Models.Cultivo obj)
        {
            bool status = false;
            try
            {
                using (MySqlConnection Conex = Connection.Instancia.MiConexionMySql)
                {

                    MySqlCommand dbComand = new MySqlCommand();
                    dbComand.Connection = Conex;
                    dbComand.CommandType = System.Data.CommandType.StoredProcedure;
                    dbComand.CommandText = "usp_insertCultivo";
                    dbComand.Parameters.Add(new MySqlParameter("pNombreCultivo", obj.NombreCultivo));
                    

                    dbComand.ExecuteNonQuery();
                    status = true;
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister("MySql.Cultivo.Insert: " + ex.Message);
                status = false;
            }
            return status;
        }
        public bool Delete(Models.Cultivo obj)
        {
            bool status = false;
            try
            {
                using (MySqlConnection Conex = Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand dbComand = new MySqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_deleteCultivo"
                    };
                    dbComand.Parameters.Add(new MySqlParameter("pNombreCultivo", obj.NombreCultivo));

                    dbComand.ExecuteNonQuery();

                    status = true;
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister("MySql.Cultivo.Delete: " + ex.Message);
                status = false;
            }
            return status;
        }
    }
}
