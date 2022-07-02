using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinEEGO.Database;
using WinEEGO.Models;

namespace WinEEGO.Business
{
    public class DepartamentoBL
    {
        private static DepartamentoBL instancia = null;
        private static object padlock = new object();
        public static DepartamentoBL Instancia
        {
            get
            {
                if (instancia == null)
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new DepartamentoBL();
                    }
                return instancia;
            }
        }
        public List<Departamento> List()
        {
            return DepartamentoDA.Instancia.List();
        }
    }
}
