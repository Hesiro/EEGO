using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinEEGO.Database;
using WinEEGO.Models;

namespace WinEEGO.Business
{
    class CultivoBL
    {
        private static CultivoBL instancia = null;
        private static object padlock = new object();
        public static CultivoBL Instancia
        {
            get
            {
                if (instancia == null)
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new CultivoBL();
                    }

                return instancia;
            }
        }
        public List<Cultivo> List()
        {
            return CultivoDA.Instancia.List();
        }
        public bool Insert(Cultivo obj)
        {
            return CultivoDA.Instancia.Insert(obj);
        }
        public bool Delete(Cultivo obj)
        {
            return CultivoDA.Instancia.Delete(obj);
        }
    }
}
