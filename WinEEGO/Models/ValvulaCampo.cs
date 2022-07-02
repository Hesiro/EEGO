using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Models
{
    public class ValvulaCampo
    {
        public int Id { get; set; }
        public string Id_Parent { get; set; }
        public string Nombre { get; set; }
        public decimal? Hectarea { get; set; }
        public int Orden { get; set; }
        public bool Estado { get; set; }
    }
}
