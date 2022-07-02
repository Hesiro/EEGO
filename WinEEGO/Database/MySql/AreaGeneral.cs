using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Database.MySql
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
        public List<Models.AreaGeneral> List()
        {
            List<Models.AreaGeneral> list = new List<Models.AreaGeneral>();
            try
            {
                using (MySqlConnection Conex = MySql.Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand command = new MySqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_listAreaGeneral"
                    };

                    MySqlDataReader dataReader = command.ExecuteReader();
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
                Log.FailRegister("MySql.AreaGeneral.List: " + ex.Message);
            }
            return list;
        }
        public bool Insert(Models.AreaGeneral obj)
        {
            try
            {
                using (MySqlConnection Conex = Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand command = new MySqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_insertAreaGeneral"
                    };
                    command.Parameters.Add(new MySqlParameter("pCodigo", obj.Codigo));
                    command.Parameters.Add(new MySqlParameter("pArea", obj.Area));                    
                    command.Parameters.Add(new MySqlParameter("pHectarea", obj.Hectarea));
                    command.Parameters.Add(new MySqlParameter("pCultivo", obj.Cultivo));

                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister("MySql.AreaGeneral.Insert: " + ex.Message);
                return false;
            }
        }
        public bool Update(Models.AreaGeneral obj)
        {
            try
            {
                using (MySqlConnection Conex = Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand command = new MySqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_updateAreaGeneral"
                    };
                    command.Parameters.Add(new MySqlParameter("pCodigo", obj.Codigo));
                    command.Parameters.Add(new MySqlParameter("pArea", obj.Area));
                    command.Parameters.Add(new MySqlParameter("pHectarea", obj.Hectarea));
                    command.Parameters.Add(new MySqlParameter("pCultivo", obj.Cultivo));
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister("MySql.AreaGeneral.Update: " + ex.Message);
                return false;
            }
        }
        public bool Delete(Models.AreaGeneral obj)
        {
            try
            {
                using (MySqlConnection Conex = Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand command = new MySqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_deleteAreaGeneral"
                    };
                    command.Parameters.Add(new MySqlParameter("pCodigo", obj.Codigo));
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister("MySql.AreaGeneral.Delete: " + ex.Message);
                return false;
            }
        }
    }
}
