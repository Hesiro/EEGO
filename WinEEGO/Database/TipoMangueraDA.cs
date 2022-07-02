using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinEEGO.Models;

namespace WinEEGO.Database
{
    public class TipoMangueraDA
    {
        private static TipoMangueraDA instancia = null;
        private static object padlock = new object();
        public static TipoMangueraDA Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new TipoMangueraDA();
                    }
                }
                return instancia;
            }
        }
        public List<TipoManguera> List()
        {
            List<TipoManguera> _list;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    _list = MySql.TipoManguera.Instancia.List();
                    break;
                case "MsSql":
                    _list = MsSql.TipoManguera.Instancia.List();
                    break;
                default:
                    _list = null;
                    break;
            }
            return _list;
        }
        public bool Insert(TipoManguera obj)
        {
            bool state = false;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    state = MySql.TipoManguera.Instancia.Insert(obj);
                    break;
                case "MsSql":
                    state = MsSql.TipoManguera.Instancia.Insert(obj);
                    break;
                default:
                    state = false;
                    break;
            }
            return state;
        }

        public bool Update(TipoManguera obj)
        {
            bool state = false;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    state = MySql.TipoManguera.Instancia.Update(obj);
                    break;
                case "MsSql":
                    state = MsSql.TipoManguera.Instancia.Update(obj);
                    break;
                default:
                    state = false;
                    break;
            }
            return state;
        }

        public bool Delete(TipoManguera obj)
        {
            bool state = false;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    state = MySql.TipoManguera.Instancia.Delete(obj);
                    break;
                case "MsSql":
                    state = MsSql.TipoManguera.Instancia.Delete(obj);
                    break;
                default:
                    state = false;
                    break;
            }
            return state;
        }
    }
}
