using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppTachito.Database.MySql
{
    class EvaluacionVolumen
    {
        static EvaluacionVolumen instancia = null;
        static readonly object padlock = new object();
        static readonly string referencia = "MySql.EvaluacionVolumen.";
        public static EvaluacionVolumen Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new EvaluacionVolumen();
                    }
                }
                return instancia;
            }
        }
        public int Insert(Models.EvaluacionVolumen obj)
        {
            int CodigoGenerado = 0;
            try
            {
                using (MySqlConnection Conex = Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand command = new MySqlCommand();

                    command.Connection = Conex;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "usp_InsertEvaluacionI";
                    command.Parameters.Add(new MySqlParameter("pID", obj.Id));
                    command.Parameters.Add(new MySqlParameter("pFecha", obj.Fecha));
                    command.Parameters.Add(new MySqlParameter("pArea", obj.Lote));
                    command.Parameters.Add(new MySqlParameter("pHectarea", obj.Hectarea));
                    command.Parameters.Add(new MySqlParameter("pCultivo", obj.Cultivo));
                    command.Parameters.Add(new MySqlParameter("pUsuario", obj.Usuario.NombreUsuario));
                    command.Parameters.Add(new MySqlParameter("pEstado", obj.Status));
                    command.Parameters.Add(new MySqlParameter("pNombreManguera", obj.NombreManguera));
                    command.Parameters.Add(new MySqlParameter("pDistancia", obj.Distancia));
                    command.Parameters.Add(new MySqlParameter("pEmision", obj.Emision));
                    command.Parameters.Add(new MySqlParameter("pTipoEvaluacion", obj.TipoEvaluacion));

                    using (MySqlDataReader dataReader = command.ExecuteReader())
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
                Log.FailRegister(referencia + "Insert: " + ex.Message);
            }
            return CodigoGenerado;
        }
        public bool UpdateStatus(Models.EvaluacionVolumen obj)
        {
            try
            {
                using (MySqlConnection Conex = Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = Conex;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "UPDATE gEvaluacionI SET " +
                        "Estado = '" + obj.Status + "', " +
                        "Fecha = '" + obj.Fecha.Year + "/"+ obj.Fecha.Month +"/" + obj.Fecha.Day + "' " +
                        "WHERE ID = " + obj.Id + ";";
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "UpdateStatus: " + ex.Message);
                return false;
            }
        }
        public bool Delete(Models.EvaluacionVolumen obj)
        {
            try
            {
                using (MySqlConnection Conex = MySql.Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = Conex;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "usp_deleteEvaluacionI";
                    command.Parameters.Add(new MySqlParameter("pID", obj.Id));
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
        public List<Models.EvaluacionVolumen> List(DateTime Desde, DateTime Hasta, Models.Usuario user)
        {
            List<Models.EvaluacionVolumen> list = new List<Models.EvaluacionVolumen>();
            try
            {
                using (MySqlConnection Conex = MySql.Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand command = new MySqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_listEvaluacionI"
                    };
                    command.Parameters.Add(new MySqlParameter("pDesde", Desde));
                    command.Parameters.Add(new MySqlParameter("pHasta", Hasta));
                    command.Parameters.Add(new MySqlParameter("pDepartamento", user.PerteneceA.Id));

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Models.EvaluacionVolumen item = new Models.EvaluacionVolumen
                        {
                            Id = (dataReader.IsDBNull(0) ? 0 : dataReader.GetInt32(0)),
                            Fecha = (dataReader.IsDBNull(1) ? DateTime.Today : dataReader.GetDateTime(1)),
                            Lote = (dataReader.IsDBNull(2) ? "" : dataReader.GetString(2))
                        };
                        if (!dataReader.IsDBNull(3))
                            item.Hectarea = dataReader.GetDecimal(3);
                        item.Cultivo = (dataReader.IsDBNull(4) ? "" : dataReader.GetString(4));
                        item.Usuario = new Models.Usuario
                        {
                            NombreUsuario = (dataReader.IsDBNull(5) ? "" : dataReader.GetString(5))
                        };
                        item.Status = (dataReader.IsDBNull(6) ? "" : dataReader.GetString(6));
                        item.NombreManguera = (dataReader.IsDBNull(7) ? "" : dataReader.GetString(7));
                        item.Distancia = (dataReader.IsDBNull(8) ? 0 : dataReader.GetDecimal(8));
                        item.Emision = (dataReader.IsDBNull(9) ? 0 : dataReader.GetDecimal(9));
                        item.TipoEvaluacion = (dataReader.IsDBNull(10) ? "" : dataReader.GetString(10));
                        if (!dataReader.IsDBNull(11))
                            item.NroDeficit = dataReader.GetInt32(11);
                        if (!dataReader.IsDBNull(12))
                            item.NroOptimo = dataReader.GetInt32(12);
                        if (!dataReader.IsDBNull(13))
                            item.NroExceso = dataReader.GetInt32(13);

                        //item.CalcularPorcentajeValvulas();
                        list.Add(item);
                    }
                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "List(To, From, Own): " + ex.Message);
            }
            return list;
        }
        public List<Models.EvaluacionVolumen> List(DateTime fechaRegistro, string area)
        {
            List<Models.EvaluacionVolumen> miLista = new List<Models.EvaluacionVolumen>();
            try
            {
                using (MySqlConnection Conex = Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand command = new MySqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.Text,
                        CommandText = "SELECT Id, Fecha, Area FROM gEvaluacionI " +
                        "WHERE Estado <> 'Terminado' " +
                        " AND DATE(Fecha) = '" + fechaRegistro.Year.ToString() + "/" + fechaRegistro.Month.ToString() + "/" + fechaRegistro.Day.ToString() + "'" +
                        " AND Area = '" + area + "';"
                    };
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Models.EvaluacionVolumen item = new Models.EvaluacionVolumen
                        {
                            Id = dataReader.IsDBNull(0) ? 0 : dataReader.GetInt32(0),
                            Fecha = dataReader.IsDBNull(1) ? DateTime.Today : dataReader.GetDateTime(1),
                            Lote = dataReader.IsDBNull(2) ? "" : dataReader.GetString(2)
                        };
                        miLista.Add(item);
                    }
                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + ex.Message);
            }
            return miLista;
        }
        public bool InsertDetail(List<Models.DetalleEvaluacionVolumen> obj)
        {
            try
            {                
                using (MySqlConnection Conex = Connection.Instancia.MiConexionMySql)
                {
                    try
                    {                        
                        foreach (var item in obj)
                        {
                            MySqlCommand command = new MySqlCommand();
                            command.Connection = Conex;
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            command.CommandText = "usp_insertDetalleEvaluacionI";
                            command.Parameters.Add(new MySqlParameter("pIDParent", item.IdParent));
                            command.Parameters.Add(new MySqlParameter("pValvula", item.Valvula));
                            command.Parameters.Add(new MySqlParameter("pHectarea", item.Hectarea));
                            command.Parameters.Add(new MySqlParameter("pEmision", item.Emision));

                            command.ExecuteNonQuery();
                        }                        
                    }
                    catch (Exception ex)
                    {
                        Log.FailRegister(referencia + "InsertDetail.1: " + ex.Message);                        
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "InsertDetail.2: " + ex.Message);
                return false;
            }
        }
        public List<Models.DetalleEvaluacionVolumen> ListDetalle(Models.EvaluacionVolumen obj)
        {
            List<Models.DetalleEvaluacionVolumen> miLista = new List<Models.DetalleEvaluacionVolumen>();
            try
            {
                using (MySqlConnection Conex = Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand command = new MySqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "usp_listDetalleEvaluacionI2"
                    };
                    command.Parameters.Add(new MySqlParameter("pParentID", obj.Id));

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Models.DetalleEvaluacionVolumen _item = new Models.DetalleEvaluacionVolumen
                        {
                            Id = dataReader.IsDBNull(0) ? 0 : dataReader.GetInt32(0),
                            IdParent = dataReader.IsDBNull(1) ? 0 : dataReader.GetInt32(1),
                            Valvula = dataReader.IsDBNull(2) ? "" : dataReader.GetString(2)
                        };
                        if (!dataReader.IsDBNull(3))
                        {
                            _item.Hectarea = dataReader.GetDecimal(3);
                        }
                        _item.NumeroPulsos = dataReader.IsDBNull(4) ? 0 : dataReader.GetInt32(4);
                        _item.TiempoPulso = dataReader.IsDBNull(5) ? 0 : dataReader.GetInt32(5);
                        _item.Emision = dataReader.IsDBNull(6) ? 0 : dataReader.GetDecimal(6);

                        if (!dataReader.IsDBNull(7))
                        {
                            _item.Medida01 = dataReader.GetDecimal(7);
                        }
                        if (!dataReader.IsDBNull(8))
                        {
                            _item.Medida02 = dataReader.GetDecimal(8);
                        }
                        _item.NumeroPulsosProg = dataReader.IsDBNull(9) ? 0 : dataReader.GetInt32(9);
                        _item.Nota = dataReader.IsDBNull(10) ? "" : dataReader.GetString(10);
                        _item.Incluir = dataReader.IsDBNull(11) ? false : dataReader.GetBoolean(11);

                        miLista.Add(_item);
                    }
                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + ex.Message);
            }
            return miLista;
        }
        public bool UpdateDetalle(List<Models.DetalleEvaluacionVolumen> obj)
        {
            try
            {
                MySqlTransaction _transaction = null;
                using (MySqlConnection Conex = Connection.Instancia.MiConexionMySql)
                {
                    try
                    {
                        _transaction = Conex.BeginTransaction();
                        foreach (var item in obj)
                        {
                            MySqlCommand command = new MySqlCommand
                            {
                                Connection = Conex,
                                CommandType = System.Data.CommandType.StoredProcedure,
                                CommandText = "usp_updateDetalleEvaluacionI2"
                            };
                            command.Parameters.Add(new MySqlParameter("pID", item.Id));
                            command.Parameters.Add(new MySqlParameter("pPulsos", item.NumeroPulsos));
                            command.Parameters.Add(new MySqlParameter("pTiempo", item.TiempoPulso));
                            command.Parameters.Add(new MySqlParameter("pmi01", item.TotalMedida));
                            command.Parameters.Add(new MySqlParameter("pMedida01", item.Medida01));
                            command.Parameters.Add(new MySqlParameter("pMedida02", item.Medida02));
                            command.Parameters.Add(new MySqlParameter("pIncluir", item.Incluir));
                            command.Parameters.Add(new MySqlParameter("pProg", item.LitrosProg));
                            command.Parameters.Add(new MySqlParameter("pReal", item.LitrosReal));
                            command.Parameters.Add(new MySqlParameter("pVar", item.Variacion));
                            command.Parameters.Add(new MySqlParameter("pPulsosProg", item.NumeroPulsosProg));
                            command.Parameters.Add(new MySqlParameter("pNota", item.Nota));

                            command.ExecuteNonQuery();
                        }
                        _transaction.Commit();
                    }
                    catch (Exception)
                    {
                        _transaction.Rollback();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteDetail(Models.DetalleEvaluacionVolumen obj)
        {
            try
            {
                using (MySqlConnection Conex = Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = Conex;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "DELETE FROM gDetalleEvaluacionI WHERE ID = " + obj.Id + ";";
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia+ ex.Message);
                return false;
            }
        }
        public bool UpdateResult(Models.EvaluacionVolumen obj)
        {
            try
            {
                using (MySqlConnection Conex = MySql.Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = Conex;
                    command.CommandType = System.Data.CommandType.StoredProcedure;                    
                    command.CommandText = "usp_updateEvaluacionI";
                    command.Parameters.Add(new MySqlParameter("pID", obj.Id));                    
                    command.Parameters.Add(new MySqlParameter("pEstado", obj.Status));                    
                    command.Parameters.Add(new MySqlParameter("pNroDeficit", obj.NroDeficit));
                    command.Parameters.Add(new MySqlParameter("pNroOptimo", obj.NroOptimo));
                    command.Parameters.Add(new MySqlParameter("pNroExceso", obj.NroExceso));
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + ex.Message);
                return false;
            }
        }

        #region Reportes
        public List<Models.Report.EvaluacionAcumulado> ListAcumulado(DateTime Desde, DateTime Hasta)
        {
            List<Models.Report.EvaluacionAcumulado> list = new List<Models.Report.EvaluacionAcumulado>();
            try
            {
                using (MySqlConnection Conex = MySql.Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand command = new MySqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.Text,
                        CommandText = "SELECT DISTINCT Cultivo, Area, Valvula " +
                        "FROM gEvaluacionI INNER JOIN gDetalleEvaluacionI " +
                        "ON gEvaluacionI.Id = gDetalleEvaluacionI.EvaluacionI " +
                        "WHERE DATE(Fecha) >= '" + Desde.Year.ToString() + "/" + Desde.Month.ToString() + "/" + Desde.Day.ToString() + "' " +
                        "AND DATE(Fecha) <= '" + Hasta.Year.ToString() + "/" + Hasta.Month.ToString() + "/" + Hasta.Day.ToString() + "' " +
                        "AND Estado = 'Terminado' " +
                        "ORDER BY Cultivo, Area, Valvula;"
                };                    

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Models.Report.EvaluacionAcumulado item = new Models.Report.EvaluacionAcumulado
                        {
                            Cultivo = (dataReader.IsDBNull(0) ? "" : dataReader.GetString(0)),
                            Lote = (dataReader.IsDBNull(1) ? "" : dataReader.GetString(1)),
                            Valvula = (dataReader.IsDBNull(2) ? "" : dataReader.GetString(2))
                        };
                        
                        list.Add(item);
                    }
                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "ListAcumulado(To, From): " + ex.Message);
            }
            return list;
        }

        public List<Models.Report.DetalleEvaluacionCorta> ListAcumuladoDetalle(Models.Report.EvaluacionAcumulado Paty, DateTime Desde, DateTime Hasta)
        {
            List<Models.Report.DetalleEvaluacionCorta> list = new List<Models.Report.DetalleEvaluacionCorta>();
            try
            {
                using (MySqlConnection Conex = MySql.Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand command = new MySqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.Text,
                        CommandText = "SELECT gDetalleEvaluacionI.Id, DATE(Fecha), LProg, LReal, Incluir, Nota " +
                        "FROM gEvaluacionI INNER JOIN gDetalleEvaluacionI " +
                        "ON gEvaluacionI.Id = gDetalleEvaluacionI.EvaluacionI " +
                        "WHERE DATE(Fecha) >= '" + Desde.Year.ToString() + "/" + Desde.Month.ToString() + "/" + Desde.Day.ToString() + "' " +
                        "AND DATE(Fecha) <= '" + Hasta.Year.ToString() + "/" + Hasta.Month.ToString() + "/" + Hasta.Day.ToString() + "' " +
                        "AND Area ='" + Paty.Lote + "' AND Valvula ='" + Paty.Valvula + "' AND Estado ='Terminado';"
                    };

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Models.Report.DetalleEvaluacionCorta item = new Models.Report.DetalleEvaluacionCorta
                        {
                            Id = (dataReader.IsDBNull(0) ? 0 : dataReader.GetInt32(0)),
                            Fecha = dataReader.IsDBNull(1) ? DateTime.Today : dataReader.GetDateTime(1),
                            Nota = dataReader.IsDBNull(5) ? "" : dataReader.GetString(5),
                            Incluir = dataReader.IsDBNull(4) ? false : dataReader.GetBoolean(4)
                        };
                        if (!dataReader.IsDBNull(2))
                        {
                            item.LitrosProg = dataReader.GetDecimal(2);
                        }
                        if (!dataReader.IsDBNull(3))
                        {
                            item.LitrosReal = dataReader.GetDecimal(3);
                        }

                        list.Add(item);
                    }
                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "ListAcumuladoDetalle(Paty, To, From): " + ex.Message);
            }
            return list;
        }
        public List<Models.Report.ResumenAnio> ListResumenAnio(int anio)
        {
            List<Models.Report.ResumenAnio> list = new List<Models.Report.ResumenAnio>();
            try
            {
                using (MySqlConnection Conex = MySql.Connection.Instancia.MiConexionMySql)
                {
                    MySqlCommand command = new MySqlCommand
                    {
                        Connection = Conex,
                        CommandType = System.Data.CommandType.Text,
                        CommandText = "SELECT T1.Cultivo, T1.Anio, T1.Mes, TotalVB, TotalVM FROM ( " +
                        "SELECT Cultivo, YEAR(FECHA) AS Anio, MONTH(Fecha) as Mes, COUNT(Valvula) as TotalVM  " +
                        "FROM gevaluacioni inner join gdetalleevaluacioni on gevaluacioni.id = gdetalleevaluacioni.EvaluacionI " +
                        "WHERE YEAR(FECHA) = " + anio.ToString() + " AND Estado = 'Terminado' AND Incluir = true AND Variacion IS NOT NULL AND ABS(Variacion) > 10 " +
                        "GROUP BY Cultivo, Anio, Mes " +
                        ") AS T1 INNER JOIN ( " +
                        "SELECT Cultivo, YEAR(FECHA) AS Anio, MONTH(Fecha) as Mes, COUNT(Valvula) as TotalVB " +
                        "FROM gevaluacioni inner join gdetalleevaluacioni on gevaluacioni.id = gdetalleevaluacioni.EvaluacionI " +
                        "WHERE YEAR(FECHA) = " + anio.ToString() + " AND Estado = 'Terminado' AND Incluir = true AND Variacion IS NOT NULL AND ABS(Variacion) <= 10 " +
                        "GROUP BY Cultivo, Anio, Mes " +
                        ") AS T2 ON T1.Cultivo = T2.Cultivo AND T1.Anio = T2.Anio AND T1.Mes = T2.Mes "+
                        "ORDER BY T1.Cultivo, T1.Anio, T1.Mes;"
                    };

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Models.Report.ResumenAnio item = new Models.Report.ResumenAnio
                        {
                            Cultivo = (dataReader.IsDBNull(0) ? "" : dataReader.GetString(0)),
                            Anio = dataReader.IsDBNull(1) ? DateTime.Today.Year : dataReader.GetInt32(1),
                            Mes = dataReader.IsDBNull(2) ? 0 : dataReader.GetInt32(2),
                            TotalVB = dataReader.IsDBNull(3) ? 0 : dataReader.GetInt32(3),
                            TotalVM = dataReader.IsDBNull(4) ? 0 : dataReader.GetInt32(4),
                        };
                        
                        list.Add(item);
                    }
                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(referencia + "ListResumenAnio(Año): " + ex.Message);
            }
            return list;
        }
        #endregion
    }
}
