using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppTachito.Database.MySql
{
    class ValvulaCampo
    {
        private static ValvulaCampo instancia = null;
        private static Object padlock = new object();
        static readonly string referencia = "MySql.ValvulaCampo.";
        public static ValvulaCampo Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new ValvulaCampo();
                    }
                }
                return instancia;
            }
        }
        public List<Models.ValvulaCampo> List(Models.AreaGeneral obj)
        {
            List<Models.ValvulaCampo> _list = new List<Models.ValvulaCampo>();
            try
            {
                using (MySqlConnection connection = MySql.Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "usp_listValvulaCampo";
                    command.Parameters.Add(new MySqlParameter("pArea", obj.Codigo));

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Models.ValvulaCampo _item = new Models.ValvulaCampo();
                        _item.Id = (dataReader.IsDBNull(0) ? 0 : dataReader.GetInt32(0));
                        _item.Nombre = (dataReader.IsDBNull(1) ? "" : dataReader.GetString(1));
                        //_item.Sector = (dataReader.IsDBNull(2) ? "" : dataReader.GetString(2));
                        if (!dataReader.IsDBNull(3))
                            _item.Hectarea = dataReader.GetDecimal(3);
                        if (!dataReader.IsDBNull(4))
                            _item.Orden = dataReader.GetInt32(4);

                        if (dataReader.IsDBNull(5))
                            _item.Estado = false;
                        else
                            if (dataReader.GetInt16(5) == 1)
                            _item.Estado = true;
                        else
                            _item.Estado = false;

                        if (!dataReader.IsDBNull(6))
                            _item.Ruta2 = dataReader.GetInt32(6);

                        _item.Id_Parent = obj.Codigo;

                        _list.Add(_item);
                    }
                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "List: " + ex.Message);
            }
            return _list;
        }
    }
}
