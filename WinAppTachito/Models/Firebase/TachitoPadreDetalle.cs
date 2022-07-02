using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppTachito.Models.Firebase
{
    public class TachitoPadreDetalle
    {
        public string Id { get; set; }
        public string Area { get; set; }
        public string NombreArea { get; set; }
        public DateTime Fecha { get; set; }
        public long FechaNum { get; set; }
        public string Usuario { get; set; }
        public List<TachitoDetalle> Valvulas { get; set; }
    }
}
