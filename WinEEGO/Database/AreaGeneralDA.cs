using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinEEGO.Models;

namespace WinEEGO.Database
{
    public class AreaGeneralDA
    {
        private static AreaGeneralDA instancia = null;
        private static object padlock = new object();
        public static AreaGeneralDA Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new AreaGeneralDA();
                    }
                }
                return instancia;
            }
        }
        public bool Insert(AreaGeneral obj)
        {
            bool state;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    state = MySql.AreaGeneral.Instancia.Insert(obj);
                    break;
                case "MsSql":
                    state = MsSql.AreaGeneral.Instancia.Insert(obj);
                    break;
                default:
                    state = false;
                    break;
            }
            return state;
        }

        public bool Update(AreaGeneral obj)
        {
            bool state = false;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    state = MySql.AreaGeneral.Instancia.Update(obj);
                    break;
                case "MsSql":
                    state = MsSql.AreaGeneral.Instancia.Update(obj);
                    break;
                default:
                    state = false;
                    break;
            }
            return state;
        }

        public bool Delete(AreaGeneral obj)
        {
            bool state = false;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    state = MySql.AreaGeneral.Instancia.Delete(obj);
                    break;
                case "MsSql":
                    state = MsSql.AreaGeneral.Instancia.Delete(obj);
                    break;
                default:
                    state = false;
                    break;
            }
            return state;
        }

        public List<AreaGeneral> List()
        {
            List<AreaGeneral> _list;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    _list = MySql.AreaGeneral.Instancia.List();
                    break;
                case "MsSql":
                    _list = MsSql.AreaGeneral.Instancia.List();
                    break;
                default:
                    _list = new List<AreaGeneral>();
                    break;
            }
            return _list;
        }
    }
}
