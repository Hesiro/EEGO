using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Database.MsSql
{
    class Usuario
    {
        private static Usuario instancia = null;
        private static object padlock = new object();
        public static Usuario Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new Usuario();
                    }
                }
                return instancia;
            }
        }
        static string referencia = "MsSql.Usuario.";
        public string Version()
        {
            string status = "";
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand dbComand = new SqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_VersionSW"
                    };

                    SqlDataReader dataReader = dbComand.ExecuteReader();

                    if (dataReader.HasRows)
                        while (dataReader.Read())
                        {
                            status = (dataReader.IsDBNull(0) ? "" : dataReader.GetString(0));
                        }
                    else
                        status = "";
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "Version: " + ex.Message);
                status = "";
            }
            return status;
        }
        public Models.Usuario Login(Models.Usuario obj)
        {
            Models.Usuario status = new Models.Usuario();
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand dbComand = new SqlCommand();
                    dbComand.Connection = Conex;
                    dbComand.CommandType = System.Data.CommandType.StoredProcedure;
                    dbComand.CommandText = "usp_checkUsuario";
                    dbComand.Parameters.AddWithValue("@pUsuario", obj.NombreUsuario);
                    dbComand.Parameters.AddWithValue("@pClave", obj.Password);                   

                    SqlDataReader dataReader = dbComand.ExecuteReader();

                    if (dataReader.HasRows)
                        while (dataReader.Read())
                        {
                            status.NombreUsuario = (dataReader.IsDBNull(0) ? "" : dataReader.GetString(0));
                            status.AccesoEGO = (dataReader.IsDBNull(1) ? Models.TipoUsuario.Ninguno : (Models.TipoUsuario)dataReader.GetInt16(1));
                            status.PerteneceA = new Models.Departamento();
                            status.PerteneceA.Id = (dataReader.IsDBNull(2) ? 0 : dataReader.GetInt32(2));
                            status.PerteneceA.NombreDepartamento = (dataReader.IsDBNull(3) ? "" : dataReader.GetString(3));
                        }
                    else
                        status = null;
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "Login: " + ex.Message);
                status = null;
            }
            return status;
        }
        public bool UpdatePass(Models.Usuario obj)
        {
            bool status = false;
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {

                    SqlCommand dbComand = new SqlCommand();
                    dbComand.Connection = Conex;
                    dbComand.CommandType = System.Data.CommandType.StoredProcedure;
                    dbComand.CommandText = "usp_updateUsuarioPass";
                    dbComand.Parameters.AddWithValue("@pUsuario", obj.NombreUsuario);
                    dbComand.Parameters.AddWithValue("@pClave", obj.Password);                   

                    dbComand.ExecuteNonQuery();

                    status = true;
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "UpdatePass: " + ex.Message);
                status = false;
            }
            return status;
        }
        public List<Models.Usuario> List()
        {
            List<Models.Usuario> lista = new List<Models.Usuario>();

            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand dbComand = new SqlCommand()
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_listUsuario"
                    };

                    SqlDataReader myReader = dbComand.ExecuteReader();

                    while (myReader.Read())
                    {
                        Models.Usuario oParametros = new Models.Usuario();
                        oParametros.NombreUsuario = (myReader.IsDBNull(0) ? "" : myReader.GetString(0));
                        oParametros.AccesoEGO = (myReader.IsDBNull(1) ? Models.TipoUsuario.Ninguno : (Models.TipoUsuario)myReader.GetInt16(1));
                        oParametros.PerteneceA = new Models.Departamento();
                        oParametros.PerteneceA.Id = (myReader.IsDBNull(2) ? 0 : myReader.GetInt32(2));
                        oParametros.PerteneceA.NombreDepartamento = (myReader.IsDBNull(3) ? "" : myReader.GetString(3));
                        oParametros.ApeNom = (myReader.IsDBNull(4) ? "" : myReader.GetString(4));
                        lista.Add(oParametros);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "List: " + ex.Message);
            }
            return lista;
        }
        public bool Insert(Models.Usuario obj)
        {
            bool status = false;
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {

                    SqlCommand dbComand = new SqlCommand();
                    dbComand.Connection = Conex;
                    dbComand.CommandType = System.Data.CommandType.StoredProcedure;
                    dbComand.CommandText = "usp_insertUsuario";
                    dbComand.Parameters.Add(new SqlParameter("@pUsuario", obj.NombreUsuario));
                    dbComand.Parameters.Add(new SqlParameter("@pClave", obj.Password));                    
                    dbComand.Parameters.Add(new SqlParameter("@pAccesoEGO", obj.AccesoEGO));
                    dbComand.Parameters.Add(new SqlParameter("@pPertenece", obj.PerteneceA.Id));
                    dbComand.Parameters.Add(new SqlParameter("@pApeNom", obj.ApeNom));

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
        public bool Update(Models.Usuario obj)
        {
            bool status = false;
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand dbComand = new SqlCommand();
                    dbComand.Connection = Conex;
                    dbComand.CommandType = System.Data.CommandType.StoredProcedure;
                    dbComand.CommandText = "usp_updateUsuario";
                    dbComand.Parameters.Add(new SqlParameter("@pUsuario", obj.NombreUsuario));
                    dbComand.Parameters.Add(new SqlParameter("@pAccesoEGO", obj.AccesoEGO));
                    dbComand.Parameters.Add(new SqlParameter("@pPertenece", obj.PerteneceA.Id));
                    dbComand.Parameters.Add(new SqlParameter("@pApeNom", obj.ApeNom));

                    dbComand.ExecuteNonQuery();

                    status = true;
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "Update: " + ex.Message);
                status = false;
            }
            return status;
        }
        public bool Delete(Models.Usuario obj)
        {
            bool status = false;
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand dbComand = new SqlCommand();
                    dbComand.Connection = Conex;
                    dbComand.CommandType = System.Data.CommandType.StoredProcedure;
                    dbComand.CommandText = "usp_deleteUsuario";
                    dbComand.Parameters.Add(new SqlParameter("@pUsuario", obj.NombreUsuario));

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
