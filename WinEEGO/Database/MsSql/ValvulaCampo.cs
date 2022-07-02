using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Database.MsSql
{
    class ValvulaCampo
    {
        private static ValvulaCampo instancia = null;
        private static Object padlock = new object();
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
        static string referencia = "MsSql.ValvulaCampo.";
        public List<Models.ValvulaCampo> List(Models.AreaGeneral obj)
        {
            List<Models.ValvulaCampo> _list = new List<Models.ValvulaCampo>();
            try
            {
                using (SqlConnection connection = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand command = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_listValvulaCampo"
                    };
                    command.Parameters.Add(new SqlParameter("@pArea", obj.Codigo));

                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Models.ValvulaCampo _item = new Models.ValvulaCampo();
                        _item.Id = (dataReader.IsDBNull(0) ? 0 : dataReader.GetInt32(0));
                        _item.Nombre = (dataReader.IsDBNull(1) ? "" : dataReader.GetString(1));
                        if (!dataReader.IsDBNull(2))
                            _item.Hectarea = dataReader.GetDecimal(2);
                        if (!dataReader.IsDBNull(3))
                            _item.Orden = dataReader.GetInt32(3);

                        if (dataReader.IsDBNull(4))
                            _item.Estado = false;
                        else
                            if (dataReader.GetBoolean(4) == true)
                            _item.Estado = true;
                        else
                            _item.Estado = false;

                        _item.Id_Parent = obj.Codigo;

                        _list.Add(_item);
                    }
                }
        }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "List(Area): " + ex.Message);
            }
            return _list;
        }
        public bool Insert(Models.ValvulaCampo obj)
        {
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand command = new SqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_insertValvulaCampo"
                    };
                    command.Parameters.Add(new SqlParameter("@pID", obj.Id));
                    command.Parameters.Add(new SqlParameter("@pArea", obj.Id_Parent));
                    command.Parameters.Add(new SqlParameter("@pNombre", obj.Nombre));
                    command.Parameters.Add(new SqlParameter("@pHectarea", obj.Hectarea));
                    command.Parameters.Add(new SqlParameter("@pOrden", obj.Orden));
                    command.Parameters.Add(new SqlParameter("@pEstado", obj.Estado));

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
        public bool Update(Models.ValvulaCampo obj)
        {
            try
            {
                using (SqlConnection connection = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "usp_updateValvulaCampo";
                    command.Parameters.Add(new SqlParameter("@pId", obj.Id));
                    command.Parameters.Add(new SqlParameter("@pHectarea", obj.Hectarea));
                    command.Parameters.Add(new SqlParameter("@pOrden", obj.Orden));
                    command.Parameters.Add(new SqlParameter("@pEstado", obj.Estado));
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
        public bool Delete(Models.ValvulaCampo obj)
        {
            try
            {
                using (SqlConnection connection = Connection.Instancia.MiConexionMsSql)
                {

                    SqlCommand command = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_deleteValvulaCampo"
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
