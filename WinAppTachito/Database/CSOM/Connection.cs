using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinAppTachito.Database.CSOM
{
    public class Connection
    {
        public ClientContext ClientContexto(string user, string pass)
        {
            string usuarioMicrosoftEmail = Log.Decrypt(user);
            string Password = Log.Decrypt(pass);
            SecureString usuarioMicrosoftPassword = new SecureString();            
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            foreach (char c in Password.ToCharArray())
                usuarioMicrosoftPassword.AppendChar(c);
            ClientContext ctx = new ClientContext("https://*.sharepoint.com/personal/*_com_pe/")
            {
                Credentials = new SharePointOnlineCredentials(usuarioMicrosoftEmail, usuarioMicrosoftPassword)
            };
            return ctx;
        }
    }
}
