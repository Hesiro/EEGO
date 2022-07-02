using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinEEGO.Models;

namespace WinEEGO.Database
{
    public class UsuarioDA
    {
        private static UsuarioDA instancia = null;
        private static object padlock = new object();
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
            bool status = false;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    status = MySql.Connection.Instancia.EstadoConexion();
                    break;
                case "MsSql":
                    status = MsSql.Connection.Instancia.EstadoConexion();
                    break;
                default:
                    status = false;
                    break;
            }

            return status;
        }
        public string Version()
        {
            string status;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    status = MySql.Usuario.Instancia.Version();
                    break;
                case "MsSql":
                    status = MsSql.Usuario.Instancia.Version();
                    break;
                default:
                    status = "";
                    break;
            }
            return status;
        }
        public Usuario Login(Usuario obj)
        {
            Usuario status = null;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    status = MySql.Usuario.Instancia.Login(obj);
                    break;
                case "MsSql":
                    status = MsSql.Usuario.Instancia.Login(obj);
                    break;
                default:
                    status = null;
                    break;
            }
            return status;
        }
        public bool UpdatePass(Usuario obj)
        {
            bool status;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    status = MySql.Usuario.Instancia.UpdatePass(obj);
                    break;
                case "MsSql":
                    status = MsSql.Usuario.Instancia.UpdatePass(obj);
                    break;
                default:
                    status = false;
                    break;
            }
            return status;
        }
        public List<Usuario> List()
        {
            List<Usuario> status;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    status = MySql.Usuario.Instancia.List();
                    break;
                case "MsSql":
                    status = MsSql.Usuario.Instancia.List();
                    break;
                default:
                    status = new List<Usuario>();
                    break;
            }
            return status;
        }
        public bool Insert(Usuario obj)
        {
            bool status;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    status = MySql.Usuario.Instancia.Insert(obj);
                    break;
                case "MsSql":
                    status = MsSql.Usuario.Instancia.Insert(obj);
                    break;
                default:
                    status = false;
                    break;
            }
            return status;
        }
        public bool Update(Usuario obj)
        {
            bool status;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    status = MySql.Usuario.Instancia.Update(obj);
                    break;
                case "MsSql":
                    status = MsSql.Usuario.Instancia.Update(obj);
                    break;
                default:
                    status = false;
                    break;
            }
            return status;
        }
        public bool Delete(Usuario obj)
        {
            bool status;
            switch (Parameter.Instancia.Provider)
            {
                case "MySql":
                    status = MySql.Usuario.Instancia.Delete(obj);
                    break;
                case "MsSql":
                    status = MsSql.Usuario.Instancia.Delete(obj);
                    break;
                default:
                    status = false;
                    break;
            }
            return status;
        }
    }
}
