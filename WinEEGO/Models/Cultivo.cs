using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Models
{
    public class Cultivo : EventArgs, ICloneable
    {
        public string NombreCultivo { get; set; }
        public override string ToString()
        {
            return NombreCultivo;
        }
        public object Clone()
        {
            return new Cultivo() { NombreCultivo = NombreCultivo};
        }
    }
}
