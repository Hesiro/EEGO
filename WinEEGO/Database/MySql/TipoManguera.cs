using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Database.MySql
{
    class TipoManguera
    {
        private static TipoManguera instancia = null;
        private static object padlock = new object();   
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
                            _item.Emision = _dataReader.GetDecimal(2);
                        if (!_dataReader.IsDBNull(3))
                            _item.EmisionPermisible = _dataReader.GetDecimal(3);
                        if (!_dataReader.IsDBNull(4))
                            _item.EmisionSobrePermisible = _dataReader.GetDecimal(4);
                        _list.Add(_item);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister("MySql.TipoManguera.List: " + ex.Message);
            }
            return _list;
        }
        public bool Insert(Models.TipoManguera obj)
        {
            try
            {
                using (MySqlConnection Conex = Connection.Instancia.MiConexionMySql)
                {

                    MySqlCommand command = new MySqlCommand();
                    command.Connection = Conex;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "usp_insertTipoManguera";
                    command.Parameters.Add(new MySqlParameter("pId", obj.Id));
                    command.Parameters.Add(new MySqlParameter("pNombre", obj.Nombre));                    
                    command.Parameters.Add(new MySqlParameter("pEmision", obj.Emision));
                    command.Parameters.Add(new MySqlParameter("pEmisionPermisible", obj.EmisionPermisible));
                    command.Parameters.Add(new MySqlParameter("pEmisionSobrePermisible", obj.EmisionSobrePermisible));
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister("MySql.TipoManguera.Insert: " + ex.Message);
                return false;
            }
        }
        public bool Update(Models.TipoManguera obj)
        {
            try
            {
                using (MySqlConnection Conex = Connection.Instancia.MiConexionMySql)
                {

                    MySqlCommand command = new MySqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_updateTipoManguera"
                    };
                    command.Parameters.Add(new MySqlParameter("pID", obj.Id));                    
                    command.Parameters.Add(new MySqlParameter("pEmision", obj.Emision));
                    command.Parameters.Add(new MySqlParameter("pEmisionPermisible", obj.EmisionPermisible));
                    command.Parameters.Add(new MySqlParameter("pEmisionSobrePermisible", obj.EmisionSobrePermisible));
                    command.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister("MySql.TipoManguera.Update: " + ex.Message);
                return false;
            }
        }
        public bool Delete(Models.TipoManguera obj)
        {
            try
            {
                using (MySqlConnection Conex = Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand command = new MySqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_deleteTipoManguera"
                    };
                    command.Parameters.Add(new MySqlParameter("pId", obj.Id));
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister("MySql.TipoManguera.Delete: " + ex.Message);
                return false;
            }
        }
    }
}
