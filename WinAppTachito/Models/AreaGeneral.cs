using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppTachito.Models
{
    public class AreaGeneral : EventArgs
    {
        public string Codigo { get; set; }
        public string Lote { get; set; }
        public string Red { get; set; }
        public decimal? Hectarea { get; set; }
        public string Cultivo { get; set; }
        public List<ValvulaCampo> Valvulas { get; set; }
    }
}
