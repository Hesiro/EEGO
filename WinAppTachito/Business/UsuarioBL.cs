using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppTachito.Database;
using WinAppTachito.Models;

namespace WinAppTachito.Business
{
    public class UsuarioBL
    {
        private static UsuarioBL instancia = null;
        private static readonly object padlock = new object();
        public static UsuarioBL Instancia
        {
            get
            {
                if (instancia == null)
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new UsuarioBL();
                    }

                return instancia;
            }
        }
        public bool VerifyConnection()
        {
            return UsuarioDA.Instancia.VerifyConnection();
        }
        public Usuario Login(Usuario obj)
        {
            return UsuarioDA.Instancia.Login(obj);
        }
    }
}
