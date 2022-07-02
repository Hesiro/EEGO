using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Database.MsSql
{
    class EvaluacionGoteros
    {
        private static EvaluacionGoteros instancia = null;
        private static object padlock = new object();
        public static EvaluacionGoteros Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new EvaluacionGoteros();
                    }
                }
                return instancia;
            }
        }
        static string referencia = "MsSql.EvaluacionGoteros.";
        #region Maestro
        public List<Models.EvaluacionGoteros> List(DateTime Desde, DateTime Hasta, Models.Usuario user)
        {
            List<Models.EvaluacionGoteros> _list = new List<Models.EvaluacionGoteros>();
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = Conex;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "usp_listEvaluacion";
                    command.Parameters.Add(new SqlParameter("@pDesde", Desde));
                    command.Parameters.Add(new SqlParameter("@pHasta", Hasta));
                    command.Parameters.Add(new SqlParameter("@pDepartamento", user.PerteneceA.Id));

                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Models.EvaluacionGoteros item = new Models.EvaluacionGoteros();
                        item.Id = (dataReader.IsDBNull(0) ? 0 : dataReader.GetInt32(0));
                        item.Fecha = (dataReader.IsDBNull(1) ? DateTime.Today : dataReader.GetDateTime(1));
                        item.Area = (dataReader.IsDBNull(2) ? "" : dataReader.GetString(2));
                        if (!dataReader.IsDBNull(3))
                            item.Hectarea = dataReader.GetDecimal(3);
                        item.Cultivo = (dataReader.IsDBNull(4) ? "" : dataReader.GetString(4));
                        if (!dataReader.IsDBNull(5))
                            item.CoeficienteUniformidad = dataReader.GetDecimal(5);
                        if (!dataReader.IsDBNull(6))
                            item.CoeficienteVariacion = dataReader.GetDecimal(6);
                        if (!dataReader.IsDBNull(7))
                            item.CoeficienteDesviacion = dataReader.GetDecimal(7);
                        item.NumeroMuestras = (dataReader.IsDBNull(8) ? 0 : dataReader.GetInt32(8));
                        item.NumeroPresiones = (dataReader.IsDBNull(9) ? 0 : dataReader.GetInt32(9));
                        item.Usuario = new Models.Usuario();
                        item.Usuario.NombreUsuario = (dataReader.IsDBNull(10) ? "" : dataReader.GetString(10));
                        item.Status = (dataReader.IsDBNull(11) ? "" : dataReader.GetString(11));
                        item.NombreManguera = (dataReader.IsDBNull(12) ? "" : dataReader.GetString(12));                        
                        item.Emision = (dataReader.IsDBNull(13) ? 0 : dataReader.GetDecimal(13));
                        if (!dataReader.IsDBNull(14))
                            item.EmisionPermisible = dataReader.GetDecimal(14);
                        if (!dataReader.IsDBNull(15))
                            item.EmisionSobrePermisible = dataReader.GetDecimal(15);
                        if (!dataReader.IsDBNull(16))
                            item.AreaAfectada = dataReader.GetDecimal(16);
                        if (!dataReader.IsDBNull(17))
                            item.AreaRegular = dataReader.GetDecimal(17);
                        if (!dataReader.IsDBNull(18))
                            item.AreaBueno = dataReader.GetDecimal(18);
                        if (!dataReader.IsDBNull(19))
                            item.NroAfectado = dataReader.GetInt32(19);
                        if (!dataReader.IsDBNull(20))
                            item.NroRegular = dataReader.GetInt32(20);
                        if (!dataReader.IsDBNull(21))
                            item.NroBueno = dataReader.GetInt32(21);

                        item.CalcularPorcentajeHa();//Actualiza los porcentajes
                        _list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister("MySql.EvaluacionGoteros.List(To, From, Own): " + ex.Message);
            }
            return _list;
        }
        public int Insert(Models.EvaluacionGoteros obj)
        {
            int CodigoGenerado = 0;
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand command = new SqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_InsertEvaluacion"
                    };
                    command.Parameters.Add(new SqlParameter("@pId", obj.Id));
                    command.Parameters.Add(new SqlParameter("@pFecha", obj.Fecha));
                    command.Parameters.Add(new SqlParameter("@pArea", obj.Area));
                    command.Parameters.Add(new SqlParameter("@pHectarea", obj.Hectarea));
                    command.Parameters.Add(new SqlParameter("@pCultivo", obj.Cultivo));
                    command.Parameters.Add(new SqlParameter("@pCu", obj.CoeficienteUniformidad));
                    command.Parameters.Add(new SqlParameter("@pCd", obj.CoeficienteDesviacion));
                    command.Parameters.Add(new SqlParameter("@pCv", obj.CoeficienteVariacion));
                    command.Parameters.Add(new SqlParameter("@pNroMuestras", obj.NumeroMuestras));
                    command.Parameters.Add(new SqlParameter("@pNroPresiones", obj.NumeroPresiones));
                    command.Parameters.Add(new SqlParameter("@pUsuario", obj.Usuario.NombreUsuario));
                    command.Parameters.Add(new SqlParameter("@pEstado", obj.Status));
                    command.Parameters.Add(new SqlParameter("@pNombreManguera", obj.NombreManguera));
                    command.Parameters.Add(new SqlParameter("@pEmision", obj.Emision));
                    command.Parameters.Add(new SqlParameter("@pEmisionPermisible", obj.EmisionPermisible));
                    command.Parameters.Add(new SqlParameter("@pEmisionSobrePermisible", obj.EmisionSobrePermisible));

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            CodigoGenerado = Convert.ToInt32(dataReader[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "Insert(): " + ex.Message);
            }
            return CodigoGenerado;
        }
        public bool Update(Models.EvaluacionGoteros obj)
        {
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand command = new SqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_updateEvaluacionOri"
                    };
                    command.Parameters.Add(new SqlParameter("@pId", obj.Id));
                    command.Parameters.Add(new SqlParameter("@pFecha", obj.Fecha));
                    command.Parameters.Add(new SqlParameter("@pCu", obj.CoeficienteUniformidad));
                    command.Parameters.Add(new SqlParameter("@pCd", obj.CoeficienteDesviacion));
                    command.Parameters.Add(new SqlParameter("@pCv", obj.CoeficienteVariacion));
                    command.Parameters.Add(new SqlParameter("@pNombreManguera", obj.NombreManguera));
                    command.Parameters.Add(new SqlParameter("@pEmision", obj.Emision));
                    command.Parameters.Add(new SqlParameter("@pEmisionPermisible", obj.EmisionPermisible));
                    command.Parameters.Add(new SqlParameter("@pEmisionSobrePermisible", obj.EmisionSobrePermisible));

                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "Update(): " + ex.Message);
                return false;
            }
        }
        public bool UpdateStatus(Models.EvaluacionGoteros obj)
        {
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand command = new SqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_updateEvaluacionEstado"
                    };
                    command.Parameters.Add(new SqlParameter("@pId", obj.Id));
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "UpdateStatus(): " + ex.Message);
                return false;
            }
        }
        public bool UpdateResult(Models.EvaluacionGoteros obj)
        {
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand command = new SqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_updateEvaluacion"
                    };
                    command.Parameters.Add(new SqlParameter("@pId", obj.Id));
                    command.Parameters.Add(new SqlParameter("@pCu", obj.CoeficienteUniformidad));
                    command.Parameters.Add(new SqlParameter("@pCv", obj.CoeficienteVariacion));
                    command.Parameters.Add(new SqlParameter("@pCd", obj.CoeficienteDesviacion));
                    command.Parameters.Add(new SqlParameter("@pEstado", obj.Status));
                    command.Parameters.Add(new SqlParameter("@pQMedio", obj.CaudalMedio));
                    command.Parameters.Add(new SqlParameter("@pQMedio25", obj.CaudalMedio25));
                    command.Parameters.Add(new SqlParameter("@pDesv", obj.DesviacionS));
                    command.Parameters.Add(new SqlParameter("@pGDP", obj.GoterosDebajoPermisible));
                    command.Parameters.Add(new SqlParameter("@pGP", obj.GoterosPermisible));
                    command.Parameters.Add(new SqlParameter("@pGSP", obj.GoterosSobrePermisible));
                    command.Parameters.Add(new SqlParameter("@pHectareaMal", obj.AreaAfectada));
                    command.Parameters.Add(new SqlParameter("@pHectareaReg", obj.AreaRegular));
                    command.Parameters.Add(new SqlParameter("@pHectareaBue", obj.AreaBueno));
                    command.Parameters.Add(new SqlParameter("@pNroValvulaMal", obj.NroAfectado));
                    command.Parameters.Add(new SqlParameter("@pNroValvulaReg", obj.NroRegular));
                    command.Parameters.Add(new SqlParameter("@pNroValvulaBue", obj.NroBueno));
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "UpdateResult(): " + ex.Message);
                return false;
            }
        }
        public bool Delete(Models.EvaluacionGoteros obj)
        {
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand command = new SqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_deleteEvaluacion"
                    };
                    command.Parameters.Add(new SqlParameter("@pId", obj.Id));
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "Delete(): " + ex.Message);
                return false;
            }
        }
        public Models.EvaluacionGoteros FindByID(Models.EvaluacionGoteros obj)
        {
            Models.EvaluacionGoteros item = new Models.EvaluacionGoteros();
            try
            {
                using (SqlConnection connection = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "usp_findEvaluacionByID";
                    command.Parameters.Add(new SqlParameter("@pId", obj.Id));

                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        item.Id = (dataReader.IsDBNull(0) ? 0 : dataReader.GetInt32(0));
                        item.Fecha = (dataReader.IsDBNull(1) ? DateTime.Today : dataReader.GetDateTime(1));
                        item.Area = (dataReader.IsDBNull(2) ? "" : dataReader.GetString(2));
                        if (!dataReader.IsDBNull(3))
                            item.Hectarea = dataReader.GetDecimal(3);
                        item.Cultivo = (dataReader.IsDBNull(4) ? "" : dataReader.GetString(4));
                        if (!dataReader.IsDBNull(5))
                            item.CoeficienteUniformidad = dataReader.GetDecimal(5);
                        if (!dataReader.IsDBNull(6))
                            item.CoeficienteVariacion = dataReader.GetDecimal(6);
                        if (!dataReader.IsDBNull(7))
                            item.CoeficienteDesviacion = dataReader.GetDecimal(7);
                        item.NumeroMuestras = (dataReader.IsDBNull(8) ? 0 : dataReader.GetInt32(8));
                        item.NumeroPresiones = (dataReader.IsDBNull(9) ? 0 : dataReader.GetInt32(9));
                        item.Usuario = new Models.Usuario();
                        item.Usuario.NombreUsuario = (dataReader.IsDBNull(10) ? "" : dataReader.GetString(10));
                        item.Status = (dataReader.IsDBNull(11) ? "" : dataReader.GetString(11));
                        item.NombreManguera = (dataReader.IsDBNull(12) ? "" : dataReader.GetString(12));
                        item.Emision = (dataReader.IsDBNull(13) ? 0 : dataReader.GetDecimal(13));
                        if (!dataReader.IsDBNull(14))
                            item.EmisionPermisible = dataReader.GetDecimal(14);
                        if (!dataReader.IsDBNull(15))
                            item.EmisionSobrePermisible = dataReader.GetDecimal(15);
                        if (!dataReader.IsDBNull(16))
                            item.CaudalMedio = dataReader.GetDecimal(16);
                        if (!dataReader.IsDBNull(17))
                            item.CaudalMedio25 = dataReader.GetDecimal(17);
                        if (!dataReader.IsDBNull(18))
                            item.DesviacionS = dataReader.GetDecimal(18);
                        if (!dataReader.IsDBNull(19))
                            item.GoterosDebajoPermisible = dataReader.GetInt32(19);
                        if (!dataReader.IsDBNull(20))
                            item.GoterosPermisible = dataReader.GetInt32(20);
                        if (!dataReader.IsDBNull(21))
                            item.GoterosSobrePermisible = dataReader.GetInt32(21);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "FindByID(): " + ex.Message);
            }
            return item;
        }
        public List<Models.EvaluacionGoteros> ListReporte(int Anio, string Valor, string Criterio)
        {
            List<Models.EvaluacionGoteros> _list = new List<Models.EvaluacionGoteros>();
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = Conex;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "usp_listEvaluacionAnioCultivo";
                    command.Parameters.Add(new SqlParameter("@pAnio", Anio));
                    command.Parameters.Add(new SqlParameter("@pCultivo", Valor));

                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Models.EvaluacionGoteros item = new Models.EvaluacionGoteros();
                        item.Id = (dataReader.IsDBNull(0) ? 0 : dataReader.GetInt32(0));
                        item.Fecha = (dataReader.IsDBNull(1) ? DateTime.Today : dataReader.GetDateTime(1));
                        item.Area = (dataReader.IsDBNull(2) ? "" : dataReader.GetString(2));
                        if (!dataReader.IsDBNull(3))
                            item.CoeficienteUniformidad = dataReader.GetDecimal(3);
                        if (!dataReader.IsDBNull(4))
                            item.CoeficienteVariacion = dataReader.GetDecimal(4);
                        if (!dataReader.IsDBNull(5))
                            item.CoeficienteDesviacion = dataReader.GetDecimal(5);

                        item.Usuario = new Models.Usuario();
                        if (!dataReader.IsDBNull(6))
                            item.Usuario.NombreUsuario = dataReader.GetString(6);                        

                        item.Usuario.PerteneceA = new Models.Departamento();
                        if (!dataReader.IsDBNull(7))
                            item.Usuario.PerteneceA.Codigo = dataReader.GetString(7);
                        if (!dataReader.IsDBNull(8))
                            item.Usuario.PerteneceA.NombreDepartamento = dataReader.GetString(8);

                        item.NumeroMuestras = (dataReader.IsDBNull(9) ? 0 : dataReader.GetInt16(9));

                        if (!dataReader.IsDBNull(10))
                            item.AreaAfectada = dataReader.GetDecimal(10);
                        if (!dataReader.IsDBNull(11))
                            item.AreaRegular = dataReader.GetDecimal(11);
                        if (!dataReader.IsDBNull(12))
                            item.AreaBueno = dataReader.GetDecimal(12);
                        if (!dataReader.IsDBNull(13))
                            item.Hectarea = dataReader.GetDecimal(13);

                        item.Emision = (dataReader.IsDBNull(14) ? 0 : dataReader.GetDecimal(14));                        
                        item.EmisionPermisible = (dataReader.IsDBNull(15) ? 0 : dataReader.GetDecimal(15));
                        item.EmisionSobrePermisible = (dataReader.IsDBNull(16) ? 0 : dataReader.GetDecimal(16));
                        item.NumeroPresiones = (dataReader.IsDBNull(17) ? 0 : dataReader.GetInt16(17));

                        item.CalcularPorcentajeHa();//Actualiza los porcentajes

                        _list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "ListReporte(campania, valor, criterio): " + ex.Message);
            }
            return _list;
        }
        public List<Models.EvaluacionGoteros> List(int Anio, string Area)
        {
            List<Models.EvaluacionGoteros> _list = new List<Models.EvaluacionGoteros>();
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand command = new SqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_listEvaluacionAnioArea"
                    };
                    command.Parameters.Add(new SqlParameter("@pDesde", DateTime.ParseExact("01/01/" + Anio.ToString(), "dd/MM/yyyy", null)));
                    command.Parameters.Add(new SqlParameter("@pHasta", DateTime.ParseExact("01/01/" + (Anio + 1).ToString(), "dd/MM/yyyy", null)));
                    command.Parameters.Add(new SqlParameter("@pArea", Area));

                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Models.EvaluacionGoteros item = new Models.EvaluacionGoteros();
                        item.Id = (dataReader.IsDBNull(0) ? 0 : dataReader.GetInt32(0));
                        item.Fecha = (dataReader.IsDBNull(1) ? DateTime.Today : dataReader.GetDateTime(1));
                        item.Area = (dataReader.IsDBNull(2) ? "" : dataReader.GetString(2));
                        if (!dataReader.IsDBNull(3))
                            item.Hectarea = dataReader.GetDecimal(3);
                        item.Cultivo = (dataReader.IsDBNull(4) ? "" : dataReader.GetString(4));
                        if (!dataReader.IsDBNull(5))
                            item.CoeficienteUniformidad = dataReader.GetDecimal(5);
                        if (!dataReader.IsDBNull(6))
                            item.CoeficienteVariacion = dataReader.GetDecimal(6);
                        if (!dataReader.IsDBNull(7))
                            item.CoeficienteDesviacion = dataReader.GetDecimal(7);
                        item.NumeroMuestras = (dataReader.IsDBNull(8) ? 0 : dataReader.GetInt32(8));
                        item.NumeroPresiones = (dataReader.IsDBNull(9) ? 0 : dataReader.GetInt32(9));
                        item.Usuario = new Models.Usuario();
                        item.Usuario.NombreUsuario = (dataReader.IsDBNull(10) ? "" : dataReader.GetString(10));
                        item.Usuario.PerteneceA = new Models.Departamento();
                        item.Usuario.PerteneceA.Id = (dataReader.IsDBNull(11) ? 0 : dataReader.GetInt32(11));
                        item.Usuario.PerteneceA.NombreDepartamento = (dataReader.IsDBNull(12) ? "" : dataReader.GetString(12));
                        item.Status = (dataReader.IsDBNull(13) ? "" : dataReader.GetString(13));
                        item.NombreManguera = (dataReader.IsDBNull(14) ? "" : dataReader.GetString(14));                        
                        item.Emision = (dataReader.IsDBNull(15) ? 0 : dataReader.GetDecimal(15));
                        if (!dataReader.IsDBNull(16))
                            item.EmisionPermisible = dataReader.GetDecimal(16);
                        if (!dataReader.IsDBNull(17))
                            item.EmisionSobrePermisible = dataReader.GetDecimal(17);

                        _list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "List(Camp, Area): " + ex.Message);
            }
            return _list;
        }
        public List<Models.EvaluacionGoteros> List(int Anio, string Area, string Valvula)
        {
            List<Models.EvaluacionGoteros> _list = new List<Models.EvaluacionGoteros>();
            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand command = new SqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_listEvaluacionAnioValvula"
                    };
                    command.Parameters.Add(new SqlParameter("@pDesde", DateTime.ParseExact("01/01/" + Anio.ToString(), "dd/MM/yyyy", null)));
                    command.Parameters.Add(new SqlParameter("@pHasta", DateTime.ParseExact("01/01/" + (Anio + 1).ToString(), "dd/MM/yyyy", null)));
                    command.Parameters.Add(new SqlParameter("@pArea", Area));
                    command.Parameters.Add(new SqlParameter("@pValvula", Valvula));

                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Models.EvaluacionGoteros item = new Models.EvaluacionGoteros();
                        item.Id = (dataReader.IsDBNull(0) ? 0 : dataReader.GetInt32(0));
                        item.Fecha = (dataReader.IsDBNull(1) ? DateTime.Today : dataReader.GetDateTime(1));
                        item.Area = (dataReader.IsDBNull(2) ? "" : dataReader.GetString(2));
                        if (!dataReader.IsDBNull(3))
                            item.Hectarea = dataReader.GetDecimal(3);
                        item.Cultivo = (dataReader.IsDBNull(4) ? "" : dataReader.GetString(4));
                        if (!dataReader.IsDBNull(5))
                            item.CoeficienteUniformidad = dataReader.GetDecimal(5);
                        if (!dataReader.IsDBNull(6))
                            item.CoeficienteVariacion = dataReader.GetDecimal(6);
                        if (!dataReader.IsDBNull(7))
                            item.CoeficienteDesviacion = dataReader.GetDecimal(7);
                        item.Usuario = new Models.Usuario();
                        item.Usuario.NombreUsuario = (dataReader.IsDBNull(8) ? "" : dataReader.GetString(8));
                        item.Usuario.PerteneceA = new Models.Departamento();
                        item.Usuario.PerteneceA.Id = (dataReader.IsDBNull(9) ? 0 : dataReader.GetInt32(9));
                        item.Usuario.PerteneceA.NombreDepartamento = (dataReader.IsDBNull(10) ? "" : dataReader.GetString(10));
                        item.Status = (dataReader.IsDBNull(11) ? "" : dataReader.GetString(11));
                        item.NombreManguera = (dataReader.IsDBNull(12) ? "" : dataReader.GetString(12));

                        item.Emision = (dataReader.IsDBNull(13) ? 0 : dataReader.GetDecimal(13));
                        if (!dataReader.IsDBNull(14))
                            item.EmisionPermisible = dataReader.GetDecimal(14);
                        if (!dataReader.IsDBNull(15))
                            item.EmisionSobrePermisible = dataReader.GetDecimal(15);
                        item.NumeroMuestras = (dataReader.IsDBNull(16) ? 0 : dataReader.GetInt32(16));
                        item.NumeroPresiones = (dataReader.IsDBNull(17) ? 0 : dataReader.GetInt32(17));

                        _list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "List(Camp, Area, Valv): " + ex.Message);
            }
            return _list;
        }
        #endregion

        #region Detalle
        public List<Models.DetalleEvaluacionGoteros> ListDetail(Models.EvaluacionGoteros obj)
        {
            List<Models.DetalleEvaluacionGoteros> _list = new List<Models.DetalleEvaluacionGoteros>();

            try
            {
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    SqlCommand command = new SqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_listDetalleEvaluacion"
                    };
                    command.Parameters.Add(new SqlParameter("@pParentId", obj.Id));

                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Models.DetalleEvaluacionGoteros _item = new Models.DetalleEvaluacionGoteros();
                        _item.Id = (dataReader.IsDBNull(0) ? 0 : dataReader.GetInt32(0));
                        _item.IdParent = (dataReader.IsDBNull(1) ? 0 : dataReader.GetInt32(1));
                        _item.Valvula = (dataReader.IsDBNull(2) ? "" : dataReader.GetString(2));
                        if (!dataReader.IsDBNull(3))
                            _item.Hectarea = dataReader.GetDecimal(3);
                        if (!dataReader.IsDBNull(4))
                            _item.Muestra01 = dataReader.GetDecimal(4);
                        if (!dataReader.IsDBNull(5))
                            _item.Muestra02 = dataReader.GetDecimal(5);
                        if (!dataReader.IsDBNull(6))
                            _item.Muestra03 = dataReader.GetDecimal(6);
                        if (!dataReader.IsDBNull(7))
                            _item.Muestra04 = dataReader.GetDecimal(7);
                        if (!dataReader.IsDBNull(8))
                            _item.Muestra05 = dataReader.GetDecimal(8);
                        if (!dataReader.IsDBNull(9))
                            _item.Muestra06 = dataReader.GetDecimal(9);
                        if (!dataReader.IsDBNull(10))
                            _item.Muestra07 = dataReader.GetDecimal(10);
                        if (!dataReader.IsDBNull(11))
                            _item.Muestra08 = dataReader.GetDecimal(11);
                        if (!dataReader.IsDBNull(12))
                            _item.Muestra09 = dataReader.GetDecimal(12);
                        if (!dataReader.IsDBNull(13))
                            _item.Muestra10 = dataReader.GetDecimal(13);
                        if (!dataReader.IsDBNull(14))
                            _item.Muestra11 = dataReader.GetDecimal(14);
                        if (!dataReader.IsDBNull(15))
                            _item.Muestra12 = dataReader.GetDecimal(15);
                        if (!dataReader.IsDBNull(16))
                            _item.Muestra13 = dataReader.GetDecimal(16);
                        if (!dataReader.IsDBNull(17))
                            _item.Muestra14 = dataReader.GetDecimal(17);
                        if (!dataReader.IsDBNull(18))
                            _item.Muestra15 = dataReader.GetDecimal(18);
                        if (!dataReader.IsDBNull(19))
                            _item.Muestra16 = dataReader.GetDecimal(19);
                        if (!dataReader.IsDBNull(20))
                            _item.Muestra17 = dataReader.GetDecimal(20);
                        if (!dataReader.IsDBNull(21))
                            _item.Muestra18 = dataReader.GetDecimal(21);
                        if (!dataReader.IsDBNull(22))
                            _item.Muestra19 = dataReader.GetDecimal(22);
                        if (!dataReader.IsDBNull(23))
                            _item.Muestra20 = dataReader.GetDecimal(23);
                        if (!dataReader.IsDBNull(24))
                            _item.Muestra21 = dataReader.GetDecimal(24);
                        if (!dataReader.IsDBNull(25))
                            _item.Muestra22 = dataReader.GetDecimal(25);
                        if (!dataReader.IsDBNull(26))
                            _item.Muestra23 = dataReader.GetDecimal(26);
                        if (!dataReader.IsDBNull(27))
                            _item.Muestra24 = dataReader.GetDecimal(27);
                        if (!dataReader.IsDBNull(28))
                            _item.Muestra25 = dataReader.GetDecimal(28);
                        if (!dataReader.IsDBNull(29))
                            _item.Muestra26 = dataReader.GetDecimal(29);
                        if (!dataReader.IsDBNull(30))
                            _item.Muestra27 = dataReader.GetDecimal(30);
                        if (!dataReader.IsDBNull(31))
                            _item.Muestra28 = dataReader.GetDecimal(31);
                        if (!dataReader.IsDBNull(32))
                            _item.Muestra29 = dataReader.GetDecimal(32);
                        if (!dataReader.IsDBNull(33))
                            _item.Muestra30 = dataReader.GetDecimal(33);
                        if (!dataReader.IsDBNull(34))
                            _item.Muestra31 = dataReader.GetDecimal(34);
                        if (!dataReader.IsDBNull(35))
                            _item.Muestra32 = dataReader.GetDecimal(35);
                        if (!dataReader.IsDBNull(36))
                            _item.Muestra33 = dataReader.GetDecimal(36);
                        if (!dataReader.IsDBNull(37))
                            _item.Muestra34 = dataReader.GetDecimal(37);
                        if (!dataReader.IsDBNull(38))
                            _item.Muestra35 = dataReader.GetDecimal(38);
                        if (!dataReader.IsDBNull(39))
                            _item.Muestra36 = dataReader.GetDecimal(39);

                        if (!dataReader.IsDBNull(40))
                            _item.Presion01 = dataReader.GetDecimal(40);
                        if (!dataReader.IsDBNull(41))
                            _item.Presion02 = dataReader.GetDecimal(41);
                        if (!dataReader.IsDBNull(42))
                            _item.Presion03 = dataReader.GetDecimal(42);
                        if (!dataReader.IsDBNull(43))
                            _item.Presion04 = dataReader.GetDecimal(43);
                        if (!dataReader.IsDBNull(44))
                            _item.Presion05 = dataReader.GetDecimal(44);
                        if (!dataReader.IsDBNull(45))
                            _item.Presion06 = dataReader.GetDecimal(45);
                        if (!dataReader.IsDBNull(46))
                            _item.Presion07 = dataReader.GetDecimal(46);
                        if (!dataReader.IsDBNull(47))
                            _item.Presion08 = dataReader.GetDecimal(47);
                        if (!dataReader.IsDBNull(48))
                            _item.Presion09 = dataReader.GetDecimal(48);
                        if (!dataReader.IsDBNull(49))
                            _item.Presion10 = dataReader.GetDecimal(49);
                        if (!dataReader.IsDBNull(50))
                            _item.Presion11 = dataReader.GetDecimal(50);
                        if (!dataReader.IsDBNull(51))
                            _item.Presion12 = dataReader.GetDecimal(51);
                        if (!dataReader.IsDBNull(52))
                            _item.Presion13 = dataReader.GetDecimal(52);
                        if (!dataReader.IsDBNull(53))
                            _item.Presion14 = dataReader.GetDecimal(53);
                        if (!dataReader.IsDBNull(54))
                            _item.Presion15 = dataReader.GetDecimal(54);
                        if (!dataReader.IsDBNull(55))
                            _item.Presion16 = dataReader.GetDecimal(55);                                                

                        _item.Qnominal = obj.Emision;
                        _item.RefreshCoeficientes();
                        _item.RefreshCUPresion();

                        _list.Add(_item);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "ListDetail(): " + ex.Message);
            }
            return _list;
        }
        public bool InsertDetail(List<Models.DetalleEvaluacionGoteros> obj)
        {
            try
            {
                //SqlTransaction _transaction = null;
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    try
                    {
                        //_transaction = Conex.BeginTransaction();
                        foreach (var item in obj)
                        {
                            SqlCommand command = new SqlCommand();
                            command.Connection = Conex;
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            command.CommandText = "usp_insertDetalleEvaluacion";
                            command.Parameters.Add(new SqlParameter("@pIdParent", item.IdParent));
                            command.Parameters.Add(new SqlParameter("@pValvula", item.Valvula));
                            command.Parameters.Add(new SqlParameter("@pHectarea", item.Hectarea));

                            command.ExecuteNonQuery();
                        }
                        //_transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Log.FailRegister(referencia + "InsertDetail.1(): " + ex.Message);
                        //_transaction.Rollback();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "InsertDetail.2(): " + ex.Message);
                return false;
            }
        }
        public bool UpdateDetail(List<Models.DetalleEvaluacionGoteros> obj)
        {
            try
            {
                //SqlTransaction _transaction = null;
                using (SqlConnection Conex = Connection.Instancia.MiConexionMsSql)
                {
                    try
                    {
                        //_transaction = Conex.BeginTransaction();
                        foreach (var item in obj)
                        {
                            SqlCommand command = new SqlCommand();
                            command.Connection = Conex;
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            command.CommandText = "usp_updateDetalleEvaluacion";
                            command.Parameters.Add(new SqlParameter("@pId", item.Id));
                            command.Parameters.Add(new SqlParameter("@pCu", item.CoeficienteUniformidad));
                            command.Parameters.Add(new SqlParameter("@pCv", item.CoeficienteVariacion));
                            command.Parameters.Add(new SqlParameter("@pCd", item.CoeficienteDesviacion));
                            command.Parameters.Add(new SqlParameter("@pmu01", item.Muestra01));
                            command.Parameters.Add(new SqlParameter("@pmu02", item.Muestra02));
                            command.Parameters.Add(new SqlParameter("@pmu03", item.Muestra03));
                            command.Parameters.Add(new SqlParameter("@pmu04", item.Muestra04));
                            command.Parameters.Add(new SqlParameter("@pmu05", item.Muestra05));
                            command.Parameters.Add(new SqlParameter("@pmu06", item.Muestra06));
                            command.Parameters.Add(new SqlParameter("@pmu07", item.Muestra07));
                            command.Parameters.Add(new SqlParameter("@pmu08", item.Muestra08));
                            command.Parameters.Add(new SqlParameter("@pmu09", item.Muestra09));
                            command.Parameters.Add(new SqlParameter("@pmu10", item.Muestra10));
                            command.Parameters.Add(new SqlParameter("@pmu11", item.Muestra11));
                            command.Parameters.Add(new SqlParameter("@pmu12", item.Muestra12));
                            command.Parameters.Add(new SqlParameter("@pmu13", item.Muestra13));
                            command.Parameters.Add(new SqlParameter("@pmu14", item.Muestra14));
                            command.Parameters.Add(new SqlParameter("@pmu15", item.Muestra15));
                            command.Parameters.Add(new SqlParameter("@pmu16", item.Muestra16));
                            command.Parameters.Add(new SqlParameter("@pmu17", item.Muestra17));
                            command.Parameters.Add(new SqlParameter("@pmu18", item.Muestra18));
                            command.Parameters.Add(new SqlParameter("@pmu19", item.Muestra19));
                            command.Parameters.Add(new SqlParameter("@pmu20", item.Muestra20));
                            command.Parameters.Add(new SqlParameter("@pmu21", item.Muestra21));
                            command.Parameters.Add(new SqlParameter("@pmu22", item.Muestra22));
                            command.Parameters.Add(new SqlParameter("@pmu23", item.Muestra23));
                            command.Parameters.Add(new SqlParameter("@pmu24", item.Muestra24));
                            command.Parameters.Add(new SqlParameter("@pmu25", item.Muestra25));
                            command.Parameters.Add(new SqlParameter("@pmu26", item.Muestra26));
                            command.Parameters.Add(new SqlParameter("@pmu27", item.Muestra27));
                            command.Parameters.Add(new SqlParameter("@pmu28", item.Muestra28));
                            command.Parameters.Add(new SqlParameter("@pmu29", item.Muestra29));
                            command.Parameters.Add(new SqlParameter("@pmu30", item.Muestra30));
                            command.Parameters.Add(new SqlParameter("@pmu31", item.Muestra31));
                            command.Parameters.Add(new SqlParameter("@pmu32", item.Muestra32));
                            command.Parameters.Add(new SqlParameter("@pmu33", item.Muestra33));
                            command.Parameters.Add(new SqlParameter("@pmu34", item.Muestra34));
                            command.Parameters.Add(new SqlParameter("@pmu35", item.Muestra35));
                            command.Parameters.Add(new SqlParameter("@pmu36", item.Muestra36));

                            command.Parameters.Add(new SqlParameter("@pprCu", item.CoeficienteUniformidadPresion));

                            command.Parameters.Add(new SqlParameter("@ppr01", item.Presion01));
                            command.Parameters.Add(new SqlParameter("@ppr02", item.Presion02));
                            command.Parameters.Add(new SqlParameter("@ppr03", item.Presion03));
                            command.Parameters.Add(new SqlParameter("@ppr04", item.Presion04));
                            command.Parameters.Add(new SqlParameter("@ppr05", item.Presion05));
                            command.Parameters.Add(new SqlParameter("@ppr06", item.Presion06));
                            command.Parameters.Add(new SqlParameter("@ppr07", item.Presion07));
                            command.Parameters.Add(new SqlParameter("@ppr08", item.Presion08));
                            command.Parameters.Add(new SqlParameter("@ppr09", item.Presion09));
                            command.Parameters.Add(new SqlParameter("@ppr10", item.Presion10));
                            command.Parameters.Add(new SqlParameter("@ppr11", item.Presion11));
                            command.Parameters.Add(new SqlParameter("@ppr12", item.Presion12));
                            command.Parameters.Add(new SqlParameter("@ppr13", item.Presion13));
                            command.Parameters.Add(new SqlParameter("@ppr14", item.Presion14));
                            command.Parameters.Add(new SqlParameter("@ppr15", item.Presion15));
                            command.Parameters.Add(new SqlParameter("@ppr16", item.Presion16));
                            command.ExecuteNonQuery();
                        }
                        //_transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Log.FailRegister(referencia + "UpdateDetail.1(): " + ex.Message);
                        //_transaction.Rollback();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "UpdateDetail.2(): " + ex.Message);
                return false;
            }
        }
        #endregion
    }
}
