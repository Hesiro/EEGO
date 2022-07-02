using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Database.MsSql
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
        static string referencia = "MsSql.TipoManguera.";
        public List<Models.TipoManguera> List()
        {
            List<Models.TipoManguera> _list = new List<Models.TipoManguera>();
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand command = new SqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_listTipoManguera"
                    };

                    SqlDataReader _dataReader = command.ExecuteReader();
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
                Log.FailRegister(referencia + "List: " + ex.Message);
            }
            return _list;
        }
        public bool Insert(Models.TipoManguera obj)
        {
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {

                    SqlCommand command = new SqlCommand();
                    command.Connection = Conex;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "usp_insertTipoManguera";
                    command.Parameters.Add(new SqlParameter("@pId", obj.Id));
                    command.Parameters.Add(new SqlParameter("@pNombre", obj.Nombre));
                    command.Parameters.Add(new SqlParameter("@pEmision", obj.Emision));
                    command.Parameters.Add(new SqlParameter("@pEmisionPermisible", obj.EmisionPermisible));
                    command.Parameters.Add(new SqlParameter("@pEmisionSobrePermisible", obj.EmisionSobrePermisible));
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
        public bool Update(Models.TipoManguera obj)
        {
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {

                    SqlCommand command = new SqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_updateTipoManguera"
                    };
                    command.Parameters.Add(new SqlParameter("@pID", obj.Id));
                    command.Parameters.Add(new SqlParameter("@pEmision", obj.Emision));
                    command.Parameters.Add(new SqlParameter("@pEmisionPermisible", obj.EmisionPermisible));
                    command.Parameters.Add(new SqlParameter("@pEmisionSobrePermisible", obj.EmisionSobrePermisible));
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
        public bool Delete(Models.TipoManguera obj)
        {
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand command = new SqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_deleteTipoManguera"
                    };
                    command.Parameters.Add(new SqlParameter("@pId", obj.Id));
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
