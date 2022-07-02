using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppTachito.Database;
using WinAppTachito.Models;

namespace WinAppTachito.Business
{
    public class TipoMangueraBL
    {
        private static TipoMangueraBL instancia = null;
        public static TipoMangueraBL Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new TipoMangueraBL();

                return instancia;
            }
        }
        public List<TipoManguera> List()
        {
            return TipoMangueraDA.Instancia.List();
        }
    }
}
