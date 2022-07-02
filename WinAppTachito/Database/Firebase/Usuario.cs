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
    public class Usuario
    {
        public List<KeyUsuarioFB> GetAllUsuarios()
        {
            List<KeyUsuarioFB> usuarios = new List<KeyUsuarioFB>();
            try
            {
                FirebaseResponse res = Connection.Instancia.Cliente.Get("Usuarios");
                Dictionary<string, UsuarioFB> data = JsonConvert.DeserializeObject<Dictionary<string, UsuarioFB>>(res.Body.ToString());
                if (data != null)
                {
                    foreach (KeyValuePair<string, UsuarioFB> item in data)
                    {
                        KeyUsuarioFB usuario = new KeyUsuarioFB
                        {
                            Key = item.Key,
                            Usuario = item.Value.Usuario,
                            Clave = Log.Decrypt(item.Value.Clave, "sifuentes-romisoncco"),
                            Nombres = item.Value.Nombres,
                            Correo = item.Value.Correo,
                            Celular = item.Value.Celular,
                            Estado = item.Value.Estado,
                            Version = item.Value.Version
                        };
                        usuarios.Add(usuario);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister(ex.ToString());
            }
            
            return usuarios;
        }
        public KeyUsuarioFB GetUsuario(string key)
        {
            KeyUsuarioFB usuarioFbModelKey;
            FirebaseResponse res = Connection.Instancia.Cliente.Get("Usuarios/" + key);
            UsuarioFB usuario = res.ResultAs<UsuarioFB>();
            usuarioFbModelKey = usuario != null
                ? new KeyUsuarioFB
                {
                    Key = key,
                    Usuario = usuario.Usuario,
                    Clave = Log.Decrypt(usuario.Clave, "sifuentes-romisoncco"),
                    Nombres = usuario.Nombres,
                    Correo = usuario.Correo,
                    Celular = usuario.Celular,
                    Estado = usuario.Estado,
                    Version = usuario.Version
                }
                : null;
            return usuarioFbModelKey;
        }
        public bool AddUsuario(KeyUsuarioFB usuario)
        {
            try
            {
                UsuarioFB usuarioFbModel = new UsuarioFB
                {
                    Usuario = usuario.Usuario,
                    Clave = Log.Encrypt(usuario.Clave, "sifuentes-romisoncco"),
                    Nombres = usuario.Nombres,
                    Correo = usuario.Correo,
                    Celular = usuario.Celular,
                    Estado = usuario.Estado,
                    Version = usuario.Version
                };
                FirebaseResponse res = Connection.Instancia.Cliente.Set("Usuarios/" + usuario.Key, usuarioFbModel);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateUsuario(KeyUsuarioFB usuario)
        {
            try
            {
                UsuarioFB usuarioFbModel = new UsuarioFB
                {
                    Usuario = usuario.Usuario,
                    Clave = Log.Encrypt(usuario.Clave, "sifuentes-romisoncco"),
                    Nombres = usuario.Nombres,
                    Correo = usuario.Correo,
                    Celular = usuario.Celular,
                    Estado = usuario.Estado,
                    Version = usuario.Version
                };
                FirebaseResponse res = Connection.Instancia.Cliente.Update("Usuarios/" + usuario.Key, usuarioFbModel);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteUsuario(string key)
        {
            try
            {
                if (!key.Equals(""))
                {
                    FirebaseResponse res = Connection.Instancia.Cliente.Delete("Usuarios/" + key);
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
