using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppTachito.Models.Firebase;

namespace WinAppTachito.Database.Firebase
{
    public class Tachito
    {
        public List<KeyTachitoPadre> GetAllTachitosPadre()
        {
            List<KeyTachitoPadre> lista = new List<KeyTachitoPadre>();
            FirebaseResponse res = Connection.Instancia.Cliente.Get("TachitosPadre");
            Dictionary<string, TachitoPadre> data = JsonConvert.DeserializeObject<Dictionary<string, TachitoPadre>>(res.Body.ToString());
            if (data != null)
                foreach (KeyValuePair<string, TachitoPadre> item in data)
                {
                    KeyTachitoPadre tachitoPadre = new KeyTachitoPadre
                    {
                        Key = item.Key,
                        Id = item.Value.Id,
                        Area = item.Value.Area,
                        NombreArea = item.Value.NombreArea,
                        Fecha = item.Value.Fecha,
                        FechaNum = item.Value.FechaNum,
                        Usuario = item.Value.Usuario
                    };
                    lista.Add(tachitoPadre);
                }
            return lista;
        }
        public List<KeyTachitoDetalle> GetAllTachitosDetalle()
        {
            List<KeyTachitoDetalle> lista = new List<KeyTachitoDetalle>();
            FirebaseResponse res = Connection.Instancia.Cliente.Get("TachitosDetalle");
            Dictionary<string, TachitoDetalle> data = JsonConvert.DeserializeObject<Dictionary<string, TachitoDetalle>>(res.Body.ToString());
            if (data != null)
                foreach (KeyValuePair<string, TachitoDetalle> item in data)
                {
                    KeyTachitoDetalle tachitoDetalle = new KeyTachitoDetalle
                    {
                        Key = item.Key,
                        Id = item.Value.Id,
                        IdPadre = item.Value.IdPadre,
                        Valvula = item.Value.Valvula,
                        Orden = item.Value.Orden,
                        Medida1 = item.Value.Medida1,
                        Medida2 = item.Value.Medida2,
                        Comentario = item.Value.Comentario
                    };
                    lista.Add(tachitoDetalle);
                }
            return lista;
        }
        public bool DeleteTachitoPadre(string key)
        {
            try
            {
                if (!key.Equals(""))
                {
                    FirebaseResponse res = Connection.Instancia.Cliente.Delete("TachitosPadre/" + key);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteTachitoDetalle(string key)
        {
            try
            {
                if (!key.Equals(""))
                {
                    FirebaseResponse res = Connection.Instancia.Cliente.Delete("TachitosDetalle/" + key);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<KeyTachitoPadreDetalle> GetAllTachitoPadreDetalle()
        {
            List<KeyTachitoPadreDetalle> lista = new List<KeyTachitoPadreDetalle>();
            FirebaseResponse res = Connection.Instancia.Cliente.Get("Tachitos");
            Dictionary<string, TachitoPadreDetalle> data = JsonConvert.DeserializeObject<Dictionary<string, TachitoPadreDetalle>>(res.Body.ToString());
            if (data != null)
                foreach (KeyValuePair<string, TachitoPadreDetalle> item in data)
                {
                    KeyTachitoPadreDetalle tachitoPadreDetalle = new KeyTachitoPadreDetalle
                    {
                        Key = item.Key,
                        Id = item.Value.Id,
                        Area = item.Value.Area,
                        NombreArea = item.Value.NombreArea,
                        Fecha = item.Value.Fecha,
                        FechaNum = item.Value.FechaNum,
                        Usuario = item.Value.Usuario,
                        Valvulas = item.Value.Valvulas
                    };
                    lista.Add(tachitoPadreDetalle);
                }
            foreach (var i in lista)
            {
                if (i.Valvulas != null)
                    if (i.Valvulas.Count > 0)
                        foreach (var j in i.Valvulas)
                        {
                            j.Comentario = i.Usuario + ": " + j.Comentario;
                        }
            }
            return lista;
        }
        public bool DeleteTachitoPadreDetalle(string key)
        {
            try
            {
                if (!key.Equals(""))
                {
                    FirebaseResponse res = Connection.Instancia.Cliente.Delete("Tachitos/" + key);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
