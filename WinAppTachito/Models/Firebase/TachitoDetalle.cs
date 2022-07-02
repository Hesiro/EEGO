using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppTachito.Models.Firebase
{
    public class TachitoDetalle
    {
        public string Id { get; set; }
        public string IdPadre { get; set; }
        public string Valvula { get; set; }
        public int Orden { get; set; }
        public decimal Medida1 { get; set; }
        public decimal Medida2 { get; set; }
        public decimal Total { get { return Medida1 + Medida2; } }
        public string Comentario { get; set; }
    }
}
