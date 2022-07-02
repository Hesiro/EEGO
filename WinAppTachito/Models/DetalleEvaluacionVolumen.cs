using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppTachito.Models
{
    public class DetalleEvaluacionVolumen
    {
        public int Id { get; set; }
        public int IdParent { get; set; }
        public string Valvula { get; set; }
        public decimal? Emision { get; set; }
        public decimal? Hectarea { get; set; }
        public int NumeroPulsosProg { get; set; }
        public int NumeroPulsos { get; set; }
        public int TiempoPulso { get; set; }
        public decimal? Medida01 {  get; set; }
        public decimal? Medida02 { get; set; }
        public decimal? TotalMedida
        {
            get
            {
                decimal? suma = 0;
                if (Medida01.HasValue)
                {
                    suma += Medida01;
                }
                if (Medida02.HasValue)
                {
                    suma += Medida02;
                }
                return suma;
            }
        }
        public decimal? LitrosProg
        {
            get
            {
                if (TiempoPulso == 0 && NumeroPulsos == 0)
                {
                    return null;
                }
                else
                {
                    return Emision * NumeroPulsos * TiempoPulso / 60;
                }
            }
        }
        public decimal? LitrosReal
        {
            get
            {
                decimal? suma = 0;
                if (Medida01.HasValue)
                {
                    suma += Medida01;
                }
                if (Medida02.HasValue)
                {
                    suma += Medida02;
                }
                return suma/1000;                
            }
        }
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
