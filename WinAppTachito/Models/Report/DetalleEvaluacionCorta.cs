using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppTachito.Models.Report
{
    public class DetalleEvaluacionCorta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal? LitrosProg { get; set; }
        public decimal? LitrosReal { get; set; }
        public decimal? Variacion
        {
            get
            {
                if (LitrosProg.HasValue && LitrosReal.HasValue)
                {
                    if (LitrosProg > 0)
                    {
                        return 100 * (LitrosReal - LitrosProg) / LitrosProg;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        public bool Incluir { get; set; }
        public string Nota { get; set; }
    }
}
