using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppTachito.Models;

namespace WinAppTachito.Database
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
        public List<ValvulaCampo> List(AreaGeneral Obj)
        {
            List<ValvulaCampo> list;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    list = MySql.ValvulaCampo.Instancia.List(Obj);
                    break;                
                default:
                    list = new List<ValvulaCampo>();
                    break;
            }
            return list;
        }
    }
}
