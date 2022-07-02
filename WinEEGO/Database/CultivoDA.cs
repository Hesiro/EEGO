using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinEEGO.Models;

namespace WinEEGO.Database
{
    public class CultivoDA
    {
        private static CultivoDA instancia = null;
        private static object padlock = new object();
        public static CultivoDA Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new CultivoDA();
                    }
                }
                return instancia;
            }
        }
        public List<Cultivo> List()
        {
            List<Cultivo> status;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    status = MySql.Cultivo.Instancia.List();
                    break;
                case "MsSql":
                    status = MsSql.Cultivo.Instancia.List();
                    break;
                default:
                    status = new List<Cultivo>();
                    break;
            }
            return status;
        }
        public bool Insert(Cultivo obj)
        {
            bool status;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    status = MySql.Cultivo.Instancia.Insert(obj);
                    break;
                case "MsSql":
                    status = MsSql.Cultivo.Instancia.Insert(obj);
                    break;
                default:
                    status = false;
                    break;
            }
            return status;
        }
        public bool Delete(Cultivo obj)
        {
            bool status;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    status = MySql.Cultivo.Instancia.Delete(obj);
                    break;
                case "MsSql":
                    status = MsSql.Cultivo.Instancia.Delete(obj);
                    break;
                default:
                    status = false;
                    break;
            }
            return status;
        }
    }
}
