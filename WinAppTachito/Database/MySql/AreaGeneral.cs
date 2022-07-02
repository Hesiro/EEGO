using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppTachito.Database.MySql
{
    class AreaGeneral
    {
        private static AreaGeneral instancia = null;
        private static Object padlock = new object();
        static readonly string referencia = "MySql.AreaGeneral.";
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
                using (MySqlConnection Conex = Connection.Instancia.MiConexionMySql)
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
                        item.Lote = dataReader.IsDBNull(1) ? "" : dataReader.GetString(1);
                    item.Red = (dataReader.IsDBNull(2) ? "" : dataReader.GetString(2));
                    if (!dataReader.IsDBNull(3))
                            item.Hectarea = dataReader.GetDecimal(3);
                        item.Cultivo = (dataReader.IsDBNull(4) ? "" : dataReader.GetString(4));

                        list.Add(item);
                    }
                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "List: " + ex.Message);
            }
            return list;
        }
    }
}
