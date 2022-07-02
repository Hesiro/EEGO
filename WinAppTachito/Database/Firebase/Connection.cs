using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppTachito.Database.Firebase
{
    class Connection
    {
        static Connection instancia = null;
        static readonly object padlock = new object();
        public static Connection Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                        {
                            instancia = new Connection();
                        }
                    }
                }
                return instancia;
            }
        }

        private IFirebaseClient cliente;
        readonly IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "***",
            BasePath = "https://*.firebaseio.com/"
        };
        public IFirebaseClient Cliente
        {
            get
            {
                if (cliente == null)                
                    cliente = new FireSharp.FirebaseClient(config);               
                return cliente;
            }
        }
    }
}
