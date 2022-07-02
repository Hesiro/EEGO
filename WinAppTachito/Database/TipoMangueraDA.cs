using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppTachito.Models;

namespace WinAppTachito.Database
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
                default:
                    _list = new List<TipoManguera>();
                    break;
            }
            return _list;
        }
    }
}
