using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Models
{
    public class TipoManguera
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Emision { get; set; }
        public decimal? EmisionPermisible { get; set; }
        public decimal? EmisionSobrePermisible { get; set; }
    }
}
