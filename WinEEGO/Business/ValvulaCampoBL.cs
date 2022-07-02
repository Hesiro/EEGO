using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinEEGO.Database;
using WinEEGO.Models;

namespace WinEEGO.Business
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
        public bool Insert(ValvulaCampo Obj)
        {
            return ValvulaCampoDA.Instancia.Insert(Obj);
        }

        public bool Update(ValvulaCampo obj)
        {
            return ValvulaCampoDA.Instancia.Update(obj);
        }

        public bool Delete(ValvulaCampo obj)
        {
            return ValvulaCampoDA.Instancia.Delete(obj);
        }

        public List<ValvulaCampo> List(AreaGeneral Obj)
        {
            return ValvulaCampoDA.Instancia.List(Obj);
        }
    }
}
