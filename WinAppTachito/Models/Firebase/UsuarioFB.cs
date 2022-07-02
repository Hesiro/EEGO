using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppTachito.Models.Firebase
{
    public class UsuarioFB
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Nombres { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public bool Estado { get; set; }
        public int Version { get; set; }
    }
}
