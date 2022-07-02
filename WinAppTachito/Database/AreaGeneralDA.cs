using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppTachito.Models;

namespace WinAppTachito.Database
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
        public List<AreaGeneral> List()
        {
            List<AreaGeneral> _list;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    _list = MySql.AreaGeneral.Instancia.List();
                    break;                
                default:
                    _list = new List<AreaGeneral>();
                    break;
            }
            return _list;
        }
    }
}
