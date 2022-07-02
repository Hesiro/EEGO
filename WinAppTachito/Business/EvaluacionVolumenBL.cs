using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppTachito.Database;
using WinAppTachito.Models;

namespace WinAppTachito.Business
{
    public class EvaluacionVolumenBL
    {
        static EvaluacionVolumenBL instancia = null;
        static readonly object padlock = new object();
        public static EvaluacionVolumenBL Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new EvaluacionVolumenBL();
                    }
                }
                return instancia;
            }
        }
        public int Insert(EvaluacionVolumen obj)
        {
            return EvaluacionVolumenDA.Instancia.Insert(obj);
        }
        public Boolean UpdateStatus(EvaluacionVolumen Obj)
        {
            return EvaluacionVolumenDA.Instancia.UpdateStatus(Obj);
        }
        public bool Delete(EvaluacionVolumen obj)
        {
            return EvaluacionVolumenDA.Instancia.Delete(obj);
        }
        public List<EvaluacionVolumen> List(DateTime Desde, DateTime Hasta, Usuario user)
        {
            return EvaluacionVolumenDA.Instancia.List(Desde, Hasta, user);            
        }
        public List<EvaluacionVolumen> List(DateTime fecha, string area)
        {
            return EvaluacionVolumenDA.Instancia.List(fecha, area);
        }
        public bool InsertDetail(EvaluacionVolumen obj)
        {
            List<ValvulaCampo> valvula;
            List<ValvulaCampo> valvulaOrdenada;
            
                valvula = ValvulaCampoBL.Instancia.List(new AreaGeneral() { Codigo = obj.Lote });
                valvulaOrdenada = valvula.OrderBy(OR => OR.Ruta2).ToList();
            

            List<DetalleEvaluacionVolumen> detalle = new List<DetalleEvaluacionVolumen>();

            foreach (var item in valvulaOrdenada)
            {
                if (item.Estado.Equals(true))
                {
                    DetalleEvaluacionVolumen row = new DetalleEvaluacionVolumen
                    {
                        IdParent = obj.Id,
                        Valvula = item.Nombre,
                        Hectarea = item.Hectarea,
                        Emision = obj.Emision
                    };
                    detalle.Add(row);
                }
            }
            return EvaluacionVolumenDA.Instancia.InsertDetail(detalle);
        }        
        public List<DetalleEvaluacionVolumen> ListDetalle(EvaluacionVolumen evaluacion)
        {
            return EvaluacionVolumenDA.Instancia.ListDetalle(evaluacion);
        }
        public bool UpdateDetalle(List<DetalleEvaluacionVolumen> detalleEvaluacion)
        {            
            return EvaluacionVolumenDA.Instancia.UpdateDetalle(detalleEvaluacion);
        }
        public bool UpdateResult(EvaluacionVolumen objParent, List<DetalleEvaluacionVolumen> objDetail, bool Limpiar)
        {
            int nroValvulaDeficit = 0;
            int nroValvulaOptimo = 0;
            int nroValvulaExceso = 0;

            foreach (var item in objDetail)
            {
                if (item.Variacion.HasValue)
                {
                    if (item.Variacion >= -10 && item.Variacion <= 10)
                        nroValvulaOptimo++;

                    if (item.Variacion < -10)
                        nroValvulaDeficit++;

                    if (item.Variacion > 10)
                        nroValvulaExceso++;
                }

                if (Limpiar)
                    if (item.LitrosProg == null && item.LitrosReal == null)
                        EvaluacionVolumenDA.Instancia.DeleteDetail(item);

            }

            if (nroValvulaDeficit + nroValvulaOptimo + nroValvulaExceso > 0)
            {
                objParent.NroDeficit = nroValvulaDeficit;
                objParent.NroOptimo = nroValvulaOptimo;
                objParent.NroExceso = nroValvulaExceso;
            }
                                    
            return EvaluacionVolumenDA.Instancia.UpdateResult(objParent);            
        }

        #region Reportes
        public List<Models.Report.EvaluacionAcumulado> ListAcumulado()
        {
            List<Models.Report.EvaluacionAcumulado> list;
            
            list = EvaluacionVolumenDA.Instancia.ListAcumulado(DateTime.Today.AddDays(-30), DateTime.Today);
            
            foreach (var item in list)
            {
                item.Detalle = EvaluacionVolumenDA.Instancia.ListAcumuladoDetalle(item, DateTime.Today.AddDays(-30), DateTime.Today);
            }
            return (from a in list orderby a.FallasSucesivas descending, 
                    a.FallasAcumuladas descending, 
                    a.AlertasSucesivas descending, 
                    a.AlertasAcumuladas descending 
                    select a).ToList();
        }
        public List<Models.Report.ResumenAnio> ListResumenAnio(int anio)
        {
            return EvaluacionVolumenDA.Instancia.ListResumenAnio(anio);
        }
        #endregion
    }
}
