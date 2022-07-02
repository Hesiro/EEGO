using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Database.MsSql
{
    class AreaGeneral
    {
        private static AreaGeneral instancia = null;
        private static Object padlock = new object();
        public static AreaGeneral Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new AreaGeneral();
                    }
                }
                return instancia;
            }
        }
        static string referencia = "MsSql.AreaGeneral.";
        public List<Models.AreaGeneral> List()
        {
            List<Models.AreaGeneral> list = new List<Models.AreaGeneral>();
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand command = new SqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_listAreaGeneral"
                    };

                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Models.AreaGeneral item = new Models.AreaGeneral();
                        item.Codigo = dataReader.IsDBNull(0) ? "" : dataReader.GetString(0);
                        item.Area = (dataReader.IsDBNull(1) ? "" : dataReader.GetString(1));
                        if (!dataReader.IsDBNull(2))
                            item.Hectarea = dataReader.GetDecimal(2);
                        item.Cultivo = (dataReader.IsDBNull(3) ? "" : dataReader.GetString(3));

                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "List: " + ex.Message);
            }
            return list;
        }
        public bool Insert(Models.AreaGeneral obj)
        {
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand command = new SqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_insertAreaGeneral"
                    };
                    command.Parameters.Add(new SqlParameter("@pCodigo", obj.Codigo));
                    command.Parameters.Add(new SqlParameter("@pArea", obj.Area));
                    command.Parameters.Add(new SqlParameter("@pHectarea", obj.Hectarea));
                    command.Parameters.Add(new SqlParameter("@pCultivo", obj.Cultivo));

                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "Insert: " + ex.Message);
                return false;
            }
        }
        public bool Update(Models.AreaGeneral obj)
        {
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand command = new SqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_updateAreaGeneral"
                    };
                    command.Parameters.Add(new SqlParameter("@pCodigo", obj.Codigo));
                    command.Parameters.Add(new SqlParameter("@pArea", obj.Area));
                    command.Parameters.Add(new SqlParameter("@pHectarea", obj.Hectarea));
                    command.Parameters.Add(new SqlParameter("@pCultivo", obj.Cultivo));
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "Update: " + ex.Message);
                return false;
            }
        }
        public bool Delete(Models.AreaGeneral obj)
        {
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand command = new SqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_deleteAreaGeneral"
                    };
                    command.Parameters.Add(new SqlParameter("@pCodigo", obj.Codigo));
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "Delete: " + ex.Message);
                return false;
            }
        }
    }
}
