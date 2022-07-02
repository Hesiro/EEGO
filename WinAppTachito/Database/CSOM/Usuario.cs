using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppTachito.Database.CSOM
{
    public class Usuario
    {
        static readonly string referencia = "CSOM.Usuario.";
        public bool Verificar(string user, string pass)
        {
            bool response;
            try
            {
                ClientContext ctx = new Connection().ClientContexto(user, pass);
                Web web = ctx.Web;
                ctx.Load(web);
                ctx.ExecuteQuery();
                if (ctx.Web.Title.Equals(""))
                    response = false;
                else
                    response = true;
            }
            catch (Exception ex)
            {
                response = false;
                Log.FailRegister(referencia + "Verificar: " + ex.Message);
            }
            
            return response;
        }
    }
}
