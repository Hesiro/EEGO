using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Database
{
    class Parameter
    {
        private static Parameter instancia = null;
        private static object padlock = new object();
        public static Parameter Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                            instancia = new Parameter();
                    }
                }
                return instancia;
            }
        }
        public string Provider
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["Proveedor"];
                }
                catch (Exception)
                {

                    return "";
                }
                            
            }
        }
        public string StringConnection
        {
            get
            {
                try
                {
                    string Servidor = ConfigurationManager.AppSettings["Servidor"];
                    string DB = ConfigurationManager.AppSettings["BD"];
                    string User = Log.Decrypt(ConfigurationManager.AppSettings["SerUsuario"], "real-soft-solutions");
                    string Pass = Log.Decrypt(ConfigurationManager.AppSettings["SerAcceso"], "real-soft-solutions");

                    if (Provider.Equals("MySql"))
                    {
                        return "Data Source = " + Servidor + "; Database = " + DB + "; User Id = " + User + "; Password = " + Pass + ";";
                    }
                    else
                    {
                        if(Provider.Equals("MsSql"))
                        {
                            return "Data Source = " + Servidor + "; Initial Catalog = " + DB + "; User ID = " + User + "; Password = " + Pass + ";";
                        }
                        else
                        {
                            return "";
                        }                        
                    }
                }
                catch (Exception)
                {
                    return "";
                }
                
                
            }
        }
    }
}
