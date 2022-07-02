using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppTachito.Models;

namespace WinAppTachito.Database
{
    public class UsuarioDA
    {
        private static UsuarioDA instancia = null;
        private static readonly object padlock = new object();
        public static UsuarioDA Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new UsuarioDA();
                    }
                }
                return instancia;
            }
        }
        public bool VerifyConnection()
        {
            bool status;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    status = MySql.Connection.Instancia.EstadoConexion();
                    break;
                //case "MsSql":
                //    status = MsSql.Connection.Instancia.EstadoConexion();
                //    break;
                default:
                    status = false;
                    break;
            }
            return status;
        }
        public Usuario Login(Usuario obj)
        {
            Usuario status;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    status = MySql.Usuario.Instancia.Login(obj);
                    break;
                //case "MsSql":
                //    status = MsSql.Usuario.Instancia.Login(obj);
                //    break;
                default:
                    status = null;
                    break;
            }
            return status;
        }
    }
}
