using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinEEGO.Models;

namespace WinEEGO.Database
{
    public class DepartamentoDA
    {
        private static DepartamentoDA instancia = null;
        private static Object padlock = new object();
        public static DepartamentoDA Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new DepartamentoDA();
                    }
                }
                return instancia;
            }
        }
        public List<Departamento> List()
        {
            List<Departamento> status;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    status = MySql.Departamento.Instancia.List();
                    break;
                case "MsSql":
                    status = MsSql.Departamento.Instancia.List();
                    break;
                default:
                    status = new List<Departamento>();
                    break;
            }
            return status;
        }
    }
}
