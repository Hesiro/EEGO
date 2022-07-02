using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Models
{
    public class Departamento : EventArgs, ICloneable
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

        public string NombreDepartamento { get; set; }

        public override string ToString()
        {
            return NombreDepartamento;
        }
        public object Clone()
        {
            return new Departamento()
            {
                Id = Id,
                Codigo = Codigo,
                NombreDepartamento = NombreDepartamento
            };
        }
    }
}
