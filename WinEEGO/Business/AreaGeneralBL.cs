using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinEEGO.Database;
using WinEEGO.Models;

namespace WinEEGO.Business
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
        public bool Insert(AreaGeneral Obj)
        {
            return AreaGeneralDA.Instancia.Insert(Obj);
        }
        public bool Update(AreaGeneral obj)
        {
            return AreaGeneralDA.Instancia.Update(obj);
        }
        public bool Delete(AreaGeneral obj)
        {
            return AreaGeneralDA.Instancia.Delete(obj);
        }
        public List<AreaGeneral> List()
        {
            return AreaGeneralDA.Instancia.List();
        }
    }
}
