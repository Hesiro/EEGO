using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinEEGO.Models;

namespace WinEEGO.Database
{
    public class ValvulaCampoDA
    {
        private static ValvulaCampoDA instancia = null;
        private static object padlock = new object();
        public static ValvulaCampoDA Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new ValvulaCampoDA();
                    }
                }
                return instancia;
            }
        }
        public bool Insert(ValvulaCampo obj)
        {
            bool state = false;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    state = MySql.ValvulaCampo.Instancia.Insert(obj);
                    break;
                case "MsSql":
                    state = MsSql.ValvulaCampo.Instancia.Insert(obj);
                    break;
                default:
                    state = false;
                    break;
            }
            return state;
        }

        public bool Update(ValvulaCampo obj)
        {
            bool state = false;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    state = MySql.ValvulaCampo.Instancia.Update(obj);
                    break;
                case "MsSql":
                    state = MsSql.ValvulaCampo.Instancia.Update(obj);
                    break;
                default:
                    state = false;
                    break;
            }
            return state;
        }

        public bool Delete(ValvulaCampo obj)
        {
            bool state = false;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    state = MySql.ValvulaCampo.Instancia.Delete(obj);
                    break;
                case "MsSql":
                    state = MsSql.ValvulaCampo.Instancia.Delete(obj);
                    break;
                default:
                    state = false;
                    break;
            }
            return state;
        }

        public List<ValvulaCampo> List(AreaGeneral Obj)
        {
            List<ValvulaCampo> list;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    list = MySql.ValvulaCampo.Instancia.List(Obj);
                    break;
                case "MsSql":
                    list = MsSql.ValvulaCampo.Instancia.List(Obj);
                    break;
                default:
                    list = null;
                    break;
            }
            return list;
        }
    }
}
