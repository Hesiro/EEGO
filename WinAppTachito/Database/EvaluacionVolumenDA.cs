using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppTachito.Models;

namespace WinAppTachito.Database
{
    public class EvaluacionVolumenDA
    {
        static EvaluacionVolumenDA instancia = null;
        static readonly object padlock = new object();
        public static EvaluacionVolumenDA Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new EvaluacionVolumenDA();
                    }
                }
                return instancia;
            }
        }
        public int Insert(EvaluacionVolumen obj)
        {
            int Id;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    Id = MySql.EvaluacionVolumen.Instancia.Insert(obj);
                    break;                
                default:
                    Id = 0;
                    break;
            }
            return Id;
        }
        public bool UpdateStatus(EvaluacionVolumen obj)
        {
            bool state;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    state = MySql.EvaluacionVolumen.Instancia.UpdateStatus(obj);
                    break;
                default:
                    state = false;
                    break;
            }
            return state;
        }
        public bool Delete(EvaluacionVolumen obj)
        {
            bool state;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    state = MySql.EvaluacionVolumen.Instancia.Delete(obj);
                    break;
                default:
                    state = false;
                    break;
            }
            return state;
        }
        public List<EvaluacionVolumen> List(DateTime Desde, DateTime Hasta,Usuario user)
        {
            List<EvaluacionVolumen> list;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    list = MySql.EvaluacionVolumen.Instancia.List(Desde, Hasta, user);
                    break;
                default:  
                    list = new List<EvaluacionVolumen>();
                    break;
            }
            return list;
        }
        public List<EvaluacionVolumen> List(DateTime fecha, string area)
        {
            List<EvaluacionVolumen> list;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    list = MySql.EvaluacionVolumen.Instancia.List(fecha, area);
                    break;
                default:
                    list = new List<EvaluacionVolumen>();
                    break;
            }
            return list;
        }
        public bool InsertDetail(List<DetalleEvaluacionVolumen> obj)
        {
            bool state;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    state = MySql.EvaluacionVolumen.Instancia.InsertDetail(obj);
                    break;
                default:
                    state = false;
                    break;
            }
            return state;
        }
        public bool UpdateDetalle(List<DetalleEvaluacionVolumen> detalleEvaluacion)
        {
            bool status;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    status = MySql.EvaluacionVolumen.Instancia.UpdateDetalle(detalleEvaluacion);
                    break;
                default:
                    status = false;
                    break;
            }
            return status;
        }
        public bool DeleteDetail(DetalleEvaluacionVolumen obj)
        {
            bool state;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    state = MySql.EvaluacionVolumen.Instancia.DeleteDetail(obj);
                    break;
                default:
                    state = false;
                    break;
            }
            return state;
        }
        public bool UpdateResult(EvaluacionVolumen obj)
        {
            bool state;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    state = MySql.EvaluacionVolumen.Instancia.UpdateResult(obj);
                    break;
                default:
                    state = false;
                    break;
            }
            return state;
        }
        public List<DetalleEvaluacionVolumen> ListDetalle(EvaluacionVolumen evaluacion)
        {
            List<DetalleEvaluacionVolumen> list;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    list = MySql.EvaluacionVolumen.Instancia.ListDetalle(evaluacion);
                    break;
                default:
                    list = new List<DetalleEvaluacionVolumen>();
                    break;
            }
            return list;
        }
        #region Reportes
        public List<Models.Report.EvaluacionAcumulado> ListAcumulado(DateTime Desde, DateTime Hasta)
        {
            List<Models.Report.EvaluacionAcumulado> list;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    list = MySql.EvaluacionVolumen.Instancia.ListAcumulado(Desde, Hasta);
                    break;
                default:
                    list = new List<Models.Report.EvaluacionAcumulado>();
                    break;
            }
            return list;
        }
        public List<Models.Report.DetalleEvaluacionCorta> ListAcumuladoDetalle(Models.Report.EvaluacionAcumulado Paty, DateTime Desde, DateTime Hasta)
        {
            List<Models.Report.DetalleEvaluacionCorta> list;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    list = MySql.EvaluacionVolumen.Instancia.ListAcumuladoDetalle(Paty, Desde, Hasta);
                    break;
                default:
                    list = new List<Models.Report.DetalleEvaluacionCorta>();
                    break;
            }
            return list;
        }
        public List<Models.Report.ResumenAnio> ListResumenAnio(int anio)
        {
            List<Models.Report.ResumenAnio> list;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    list = MySql.EvaluacionVolumen.Instancia.ListResumenAnio(anio);
                    break;
                default:
                    list = new List<Models.Report.ResumenAnio>();
                    break;
            }
            return list;
        }
        #endregion
    }
}
