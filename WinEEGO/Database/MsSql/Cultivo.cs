using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Database.MsSql
{
    class Cultivo
    {
        private static Cultivo instancia = null;
        private static object padlock = new object();
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
        static string referencia = "MsSql.Cultivo.";
        public List<Models.Cultivo> List()
        {
            List<Models.Cultivo> lista = new List<Models.Cultivo>();

            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand dbComand = new SqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_listCultivo"
                    };

                    SqlDataReader myReader = dbComand.ExecuteReader();

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
                Log.FailRegister(referencia + ".List: " + ex.Message);
            }
            return lista;
        }
        public bool Insert(Models.Cultivo obj)
        {
            bool status = false;
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {

                    SqlCommand dbComand = new SqlCommand();
                    dbComand.Connection = Conex;
                    dbComand.CommandType = System.Data.CommandType.StoredProcedure;
                    dbComand.CommandText = "usp_insertCultivo";
                    dbComand.Parameters.Add(new SqlParameter("@pNombreCultivo", obj.NombreCultivo));


                    dbComand.ExecuteNonQuery();
                    status = true;
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "Insert: " + ex.Message);
                status = false;
            }
            return status;
        }
        public bool Delete(Models.Cultivo obj)
        {
            bool status = false;
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand dbComand = new SqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_deleteCultivo"
                    };
                    dbComand.Parameters.Add(new SqlParameter("@pNombreCultivo", obj.NombreCultivo));

                    dbComand.ExecuteNonQuery();

                    status = true;
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "Delete: " + ex.Message);
                status = false;
            }
            return status;
        }
    }
}
