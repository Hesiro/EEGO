using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinEEGO.Database;
using WinEEGO.Models;

namespace WinEEGO.Business
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
        public Boolean Insert(TipoManguera Obj)
        {
            return TipoMangueraDA.Instancia.Insert(Obj);
        }
        public Boolean Update(TipoManguera obj)
        {
            return TipoMangueraDA.Instancia.Update(obj);
        }
        public Boolean Delete(TipoManguera obj)
        {
            return TipoMangueraDA.Instancia.Delete(obj);
        }
        public List<TipoManguera> List()
        {
            return TipoMangueraDA.Instancia.List();
        }
    }
}
