using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppTachito.Database;
using WinAppTachito.Models;

namespace WinAppTachito.Business
{
    public class AreaGeneralBL
    {
        private static AreaGeneralBL instancia = null;
        private static object padlock = new object();
        public static AreaGeneralBL Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new AreaGeneralBL();
                    }
                }
                return instancia;
            }
        }
        public List<AreaGeneral> List()
        {
            return AreaGeneralDA.Instancia.List();
        }
    }
}
