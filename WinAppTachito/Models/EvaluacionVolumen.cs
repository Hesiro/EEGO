using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppTachito.Models
{
    public class EvaluacionVolumen
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Lote { get; set; }
        public decimal? Hectarea { get; set; }
        public string Cultivo { get; set; }
        public Usuario Usuario { get; set; }
        public string Status { get; set; }
        public string NombreManguera { get; set; }
        public decimal? Distancia { get; set; }
        public decimal? Emision { get; set; }
        public string TipoEvaluacion { get; set; }
        public int? NroDeficit { get; set; }
        public int? NroOptimo { get; set; }
        public int? NroExceso { get; set; }
    }
}
