using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppTachito.Models.Firebase;

namespace WinAppTachito.Database.CSOM
{
    public class Tachito
    {
        public List<KeyTachitoPadre> GetAllTachitosPadre(string user, string pass)
        {
            List<KeyTachitoPadre> listaRegistros = new List<KeyTachitoPadre>();
            ClientContext ctx = new Connection().ClientContexto(user, pass);
            List oList = ctx.Web.Lists.GetByTitle("TachitoPadre");
            CamlQuery camlQuery = new CamlQuery
            {
                ViewXml =
                @"<View>
                    <ViewFields>
                        <FieldRef Name='Title'/>
                        <FieldRef Name='Fecha'/>
                        <FieldRef Name='IdLocal'/>
                        <FieldRef Name='Responsable'/>
                        <FieldRef Name='ID'/>
                    </ViewFields>
                 </View>"
            };
            ListItemCollection collListItem = oList.GetItems(camlQuery);
            ctx.Load(collListItem);
            ctx.ExecuteQuery();
            foreach (ListItem item in collListItem)
            {
                KeyTachitoPadre reg = new KeyTachitoPadre
                {
                    Area = item["Title"].ToString(),
                    Fecha = Convert.ToDateTime(item["Fecha"]),
                    Id = Convert.ToInt64(item["IdLocal"]).ToString(),
                    Usuario = item["Responsable"].ToString(),
                    Key = item["ID"].ToString()
                };
                listaRegistros.Add(reg);
            }
            return listaRegistros;
        }
        public List<KeyTachitoDetalle> GetAllTachitosDetalle(string user, string pass)
        {
            List<KeyTachitoDetalle> listaRegistros = new List<KeyTachitoDetalle>();
            ClientContext ctx = new Connection().ClientContexto(user, pass);
            List oList = ctx.Web.Lists.GetByTitle("TachitoDetalle");
            CamlQuery camlQuery = new CamlQuery
            {
                ViewXml =
                @"<View>
                    <ViewFields>
                        <FieldRef Name='Title'/>
                        <FieldRef Name='Orden'/>
                        <FieldRef Name='Medida1'/>
                        <FieldRef Name='Medida2'/>
                        <FieldRef Name='Comentario'/> 
                        <FieldRef Name='IdPadre'/>
                        <FieldRef Name='ID'/>
                    </ViewFields>
                 </View>"
            };
            ListItemCollection collListItem = oList.GetItems(camlQuery);
            ctx.Load(collListItem);
            ctx.ExecuteQuery();
            foreach (ListItem item in collListItem)
            {
                KeyTachitoDetalle reg = new KeyTachitoDetalle
                {
                    Valvula = item["Title"].ToString(),
                    Orden = Convert.ToInt32(item["Orden"]),
                    Medida1 = Convert.ToDecimal(item["Medida1"]),
                    Medida2 = Convert.ToDecimal(item["Medida2"]),
                    Comentario = item["Comentario"] == null ? "" : item["Comentario"].ToString(),
                    IdPadre = item["IdPadre"].ToString(),
                    Key = item["ID"].ToString()
                };
                listaRegistros.Add(reg);
            }
            return listaRegistros;
        }
        public List<KeyTachitoPadre> GetAllTachitosPadre(string user, string pass, long desde, long hasta)
        {
            List<KeyTachitoPadre> listaRegistros = new List<KeyTachitoPadre>();
            ClientContext ctx = new Connection().ClientContexto(user, pass);
            List oList = ctx.Web.Lists.GetByTitle("TachitoPadre");
            CamlQuery camlQuery = new CamlQuery
            {
                ViewXml =
                @"<View>
                    <ViewFields>
                        <FieldRef Name='Title'/>
                        <FieldRef Name='Fecha'/>
                        <FieldRef Name='IdLocal'/>
                        <FieldRef Name='Responsable'/>
                        <FieldRef Name='ID'/>
                    </ViewFields>
                    <Query>
                        <Where>
                            <And>
                                <Geq>
                                    <FieldRef Name='IdLocal'/>
                                    <Value Type='Number'>" + desde.ToString() + @"</Value>
                                </Geq>
                                <Leq>
                                    <FieldRef Name='IdLocal'/>
                                    <Value Type='Number'>" + hasta.ToString() + @"</Value>
                                </Leq> 
                            </And>
                        </Where>
                    </Query>
                 </View>"
            };
            ListItemCollection collListItem = oList.GetItems(camlQuery);
            ctx.Load(collListItem);
            ctx.ExecuteQuery();
            foreach (ListItem item in collListItem)
            {
                KeyTachitoPadre reg = new KeyTachitoPadre
                {
                    Area = item["Title"].ToString(),
                    Fecha = Convert.ToDateTime(item["Fecha"]),
                    Id = Convert.ToInt64(item["IdLocal"]).ToString(),
                    Usuario = item["Responsable"].ToString(),
                    Key = item["ID"].ToString()
                };
                listaRegistros.Add(reg);
            }
            return listaRegistros;
        }
        public List<KeyTachitoDetalle> GetAllTachitosDetalle(string user, string pass, string IdPadre)
        {
            List<KeyTachitoDetalle> listaRegistros = new List<KeyTachitoDetalle>();
            ClientContext ctx = new Connection().ClientContexto(user, pass);
            List oList = ctx.Web.Lists.GetByTitle("TachitoDetalle");
            CamlQuery camlQuery = new CamlQuery
            {
                ViewXml =
                @"<View>
                    <ViewFields>
                        <FieldRef Name='Title'/>
                        <FieldRef Name='Orden'/>
                        <FieldRef Name='Medida1'/>
                        <FieldRef Name='Medida2'/>
                        <FieldRef Name='Comentario'/> 
                        <FieldRef Name='IdPadre'/>
                        <FieldRef Name='ID'/>
                    </ViewFields>
                    <Query>
                        <Where>                            
                            <Eq>
                                <FieldRef Name='IdPadre'/>
                                <Value Type='Number'>" + IdPadre + @"</Value>
                            </Eq>                            
                        </Where>
                    </Query>
                 </View>"
            };
            ListItemCollection collListItem = oList.GetItems(camlQuery);
            ctx.Load(collListItem);
            ctx.ExecuteQuery();
            foreach (ListItem item in collListItem)
            {
                KeyTachitoDetalle reg = new KeyTachitoDetalle
                {
                    Valvula = item["Title"].ToString(),
                    Orden = Convert.ToInt32(item["Orden"]),
                    Medida1 = Convert.ToDecimal(item["Medida1"]),
                    Medida2 = Convert.ToDecimal(item["Medida2"]),
                    Comentario = item["Comentario"] == null ? "" : item["Comentario"].ToString(),
                    IdPadre = item["IdPadre"].ToString(),
                    Key = item["ID"].ToString()
                };
                listaRegistros.Add(reg);
            }
            return listaRegistros;
        }
        public bool DeleteListItemsTachitosPadre(string user, string pass, int ID)
        {
            try
            {
                ClientContext ctx = new Connection().ClientContexto(user, pass);
                List oList = ctx.Web.Lists.GetByTitle("TachitoPadre");
                ListItem listItem = oList.GetItemById(ID);
                listItem.DeleteObject();
                ctx.ExecuteQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public bool DeleteListItemsTachitosDetalle(string user, string pass, int ID)
        {
            try
            {
                ClientContext ctx = new Connection().ClientContexto(user, pass);
                List oList = ctx.Web.Lists.GetByTitle("TachitoDetalle");
                ListItem listItem = oList.GetItemById(ID);
                listItem.DeleteObject();
                ctx.ExecuteQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
