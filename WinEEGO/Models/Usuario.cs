using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Models
{
    public class Usuario : EventArgs, ICloneable
    {
        public string NombreUsuario { get; set; }

        public string Password { get; set; }

        public TipoUsuario AccesoEGO { get; set; }

        public Departamento PerteneceA { get; set; }

        public string ApeNom { get; set; }

        public object Clone()
        {
            return new Usuario()
            {
                NombreUsuario = NombreUsuario,
                Password = Password,
                AccesoEGO = AccesoEGO,
                PerteneceA = PerteneceA,
                ApeNom = ApeNom
            };
        }

        public override string ToString()
        {
            return NombreUsuario;
        }
    }
}
