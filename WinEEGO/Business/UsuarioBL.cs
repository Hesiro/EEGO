using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinEEGO.Database;
using WinEEGO.Models;

namespace WinEEGO.Business
{
    public class UsuarioBL
    {
        private static UsuarioBL instancia = null;
        private static object padlock = new object();
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
        public string Version()
        {
            return UsuarioDA.Instancia.Version();
        }
        public Usuario Login(Usuario obj)
        {
            return UsuarioDA.Instancia.Login(obj);
        }
        public bool UpdatePass(Usuario obj)
        {
            return UsuarioDA.Instancia.UpdatePass(obj);
        }
        public List<Usuario> List()
        {
            return UsuarioDA.Instancia.List();
        }
        public bool Insert(Usuario obj)
        {
            return UsuarioDA.Instancia.Insert(obj);
        }
        public bool Update(Usuario obj)
        {
            return UsuarioDA.Instancia.Update(obj);
        }
        public bool Delete(Usuario obj)
        {
            return UsuarioDA.Instancia.Delete(obj);
        }
    }
}
