using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppTachito.Database.MySql
{
    class TipoManguera
    {
        private static TipoManguera instancia = null;
        private static object padlock = new object();
        static readonly string referencia = "MySql.TipoManguera.";
        public static TipoManguera Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new TipoManguera();
                    }
                }
                return instancia;
            }
        }
        public List<Models.TipoManguera> List()
        {
            List<Models.TipoManguera> _list = new List<Models.TipoManguera>();
            try
            {
                using (MySqlConnection Conex = Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand command = new MySqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_listTipoManguera"
                    };

                    MySqlDataReader _dataReader = command.ExecuteReader();
                    while (_dataReader.Read())
                    {
                        Models.TipoManguera _item = new Models.TipoManguera();
                        _item.Id = (_dataReader.IsDBNull(0) ? 0 : _dataReader.GetInt32(0));
                        _item.Nombre = (_dataReader.IsDBNull(1) ? "" : _dataReader.GetString(1));
                        if (!_dataReader.IsDBNull(2))
                            _item.Distancia = _dataReader.GetDecimal(2);
                        if (!_dataReader.IsDBNull(3))
                            _item.Emision = _dataReader.GetDecimal(3);
                        if (!_dataReader.IsDBNull(4))
                            _item.EmisionPermisible = _dataReader.GetDecimal(4);
                        if (!_dataReader.IsDBNull(5))
                            _item.EmisionSobrePermisible = _dataReader.GetDecimal(5);
                        _list.Add(_item);
                    }
                    _dataReader.Close();
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
