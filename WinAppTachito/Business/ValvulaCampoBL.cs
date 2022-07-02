using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppTachito.Database;
using WinAppTachito.Models;

namespace WinAppTachito.Business
{
    public class ValvulaCampoBL
    {
        private static ValvulaCampoBL instancia = null;
        private static object padlock = new object();
        public static ValvulaCampoBL Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new ValvulaCampoBL();
                    }
                }
                return instancia;
            }
        }
        public List<ValvulaCampo> List(AreaGeneral Obj)
        {
            return ValvulaCampoDA.Instancia.List(Obj);
        }
    }
}
