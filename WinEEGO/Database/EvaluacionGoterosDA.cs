using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinEEGO.Models;

namespace WinEEGO.Database
{
    public class EvaluacionGoterosDA
    {
        private static EvaluacionGoterosDA instancia = null;
        private static object padlock = new object();
        public static EvaluacionGoterosDA Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new EvaluacionGoterosDA();
                    }
                }
                return instancia;
            }
        }

        #region Maestro
        public List<EvaluacionGoteros> List(DateTime Desde, DateTime Hasta, Usuario user)
        {
            List<EvaluacionGoteros> list;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    list = MySql.EvaluacionGoteros.Instancia.List(Desde, Hasta, user);
                    break;
                case "MsSql":
                    list = MsSql.EvaluacionGoteros.Instancia.List(Desde, Hasta, user);
                    break;
                default:
                    list = new List<EvaluacionGoteros>();
                    break;
            }
            return list;
        }
        public int Insert(EvaluacionGoteros obj)
        {
            int Id;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    Id = MySql.EvaluacionGoteros.Instancia.Insert(obj);
                    break;
                case "MsSql":
                    Id = MsSql.EvaluacionGoteros.Instancia.Insert(obj);
                    break;
                default:
                    Id = 0;
                    break;
            }
            return Id;
        }
        public bool Update(EvaluacionGoteros obj)
        {
            bool state = false;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    state = MySql.EvaluacionGoteros.Instancia.Update(obj);
                    break;
                case "MsSql":
                    state = MsSql.EvaluacionGoteros.Instancia.Update(obj);
                    break;
                default:
                    state = false;
                    break;
            }
            return state;
        }
        public bool UpdateStatus(EvaluacionGoteros obj)
        {
            bool state = false;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    state = MySql.EvaluacionGoteros.Instancia.UpdateStatus(obj);
                    break;
                case "MsSql":
                    state = MsSql.EvaluacionGoteros.Instancia.UpdateStatus(obj);
                    break;
                default:
                    state = false;
                    break;
            }
            return state;
        }
        public bool UpdateResult(EvaluacionGoteros obj)
        {
            bool state = false;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    state = MySql.EvaluacionGoteros.Instancia.UpdateResult(obj);
                    break;
                case "MsSql":
                    state = MsSql.EvaluacionGoteros.Instancia.UpdateResult(obj);
                    break;
                default:
                    state = false;
                    break;
            }
            return state;
        }
        public bool Delete(EvaluacionGoteros obj)
        {
            bool state = false;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    state = MySql.EvaluacionGoteros.Instancia.Delete(obj);
                    break;
                case "MsSql":
                    state = MsSql.EvaluacionGoteros.Instancia.Delete(obj);
                    break;
                default:
                    state = false;
                    break;
            }
            return state;
        }
        public EvaluacionGoteros FindByID(EvaluacionGoteros obj)
        {
            EvaluacionGoteros _list;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    _list = MySql.EvaluacionGoteros.Instancia.FindByID(obj);
                    break;
                case "MsSql":
                    _list = MsSql.EvaluacionGoteros.Instancia.FindByID(obj);
                    break;
                default:
                    _list = new EvaluacionGoteros();
                    break;
            }
            return _list;
        }
        public List<EvaluacionGoteros> ListReporte(int Anio, string Valor, string Criterio)
        {
            List<EvaluacionGoteros> _list;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    _list = MySql.EvaluacionGoteros.Instancia.ListReporte(Anio, Valor, Criterio);
                    break;
                case "MsSql":
                    _list = MsSql.EvaluacionGoteros.Instancia.ListReporte(Anio, Valor, Criterio);
                    break;
                default:
                    _list = new List<EvaluacionGoteros>();
                    break;
            }
            return _list;
        }
        public List<EvaluacionGoteros> List(int Anio, string Area)
        {
            List<EvaluacionGoteros> _list;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    _list = MySql.EvaluacionGoteros.Instancia.List(Anio, Area);
                    break;
                case "MsSql":
                    _list = MsSql.EvaluacionGoteros.Instancia.List(Anio, Area);
                    break;
                default:
                    _list = new List<EvaluacionGoteros>();
                    break;
            }
            return _list;
        }
        public List<EvaluacionGoteros> List(int Anio, string Area, string Valvula)
        {
            List<EvaluacionGoteros> _list;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    _list = MySql.EvaluacionGoteros.Instancia.List(Anio, Area, Valvula);
                    break;
                case "MsSql":
                    _list = MsSql.EvaluacionGoteros.Instancia.List(Anio, Area, Valvula);
                    break;
                default:
                    _list = new List<EvaluacionGoteros>();
                    break;
            }
            return _list;
        }
        #endregion

        #region Detalle
        public List<DetalleEvaluacionGoteros> ListDetail(EvaluacionGoteros obj)
        {
            List<DetalleEvaluacionGoteros> _list;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    _list = MySql.EvaluacionGoteros.Instancia.ListDetail(obj);
                    break;
                case "MsSql":
                    _list = MsSql.EvaluacionGoteros.Instancia.ListDetail(obj);
                    break;
                default:
                    _list = new List<DetalleEvaluacionGoteros>();
                    break;
            }
            return _list;
        }
        public bool InsertDetail(List<DetalleEvaluacionGoteros> obj)
        {
            bool state;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    state = MySql.EvaluacionGoteros.Instancia.InsertDetail(obj);
                    break;
                case "MsSql":
                    state = MsSql.EvaluacionGoteros.Instancia.InsertDetail(obj);
                    break;
                default:
                    state = false;
                    break;
            }
            return state;
        }
        public bool UpdateDetail(List<DetalleEvaluacionGoteros> obj)
        {
            bool state;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    state = MySql.EvaluacionGoteros.Instancia.UpdateDetail(obj);
                    break;
                case "MsSql":
                    state = MsSql.EvaluacionGoteros.Instancia.UpdateDetail(obj);
                    break;
                default:
                    state = false;
                    break;
            }
            return state;
        }
        #endregion

        public List<EvaluacionGoteros> ListPendientes(DateTime Desde, DateTime Hasta, string Cultivo)
        {
            List<EvaluacionGoteros> list;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    list = MySql.EvaluacionGoteros.Instancia.ListPendientes(Desde, Hasta, Cultivo);
                    break;
                default:
                    list = null;
                    break;
            }
            return list;
        }
        public List<EvaluacionGoteros> ListParaActuar(DateTime Desde, DateTime Hasta, string Cultivo, Int16 nupCU, Int16 nupCv, Int16 nupCd)
        {
            List<EvaluacionGoteros> list;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    list = MySql.EvaluacionGoteros.Instancia.ListParaActuar(Desde, Hasta, Cultivo, nupCU, nupCv, nupCd);
                    break;
                default:
                    list = null;
                    break;
            }
            return list;
        }
    }
}
