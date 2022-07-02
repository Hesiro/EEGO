using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Models
{
    public class EvaluacionGoteros
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Area { get; set; }
        public decimal? Hectarea { get; set; }
        public string Cultivo { get; set; }
        public decimal? CoeficienteUniformidad { get; set; }
        public decimal? CoeficienteVariacion { get; set; }
        public decimal? CoeficienteDesviacion { get; set; }
        public int NumeroMuestras { get; set; }
        public int NumeroPresiones { get; set; }
        public Usuario Usuario { get; set; }
        public string Status { get; set; }
        public string NombreManguera { get; set; }
        public decimal Emision { get; set; }
        public decimal? EmisionPermisible { get; set; }
        public decimal? EmisionSobrePermisible { get; set; }
        public decimal? CaudalMedio { get; set; }
        public decimal? CaudalMedio25 { get; set; }
        public decimal? DesviacionS { get; set; }
        public int? GoterosDebajoPermisible { get; set; }        
        public int? GoterosPermisible { get; set; }
        public int? GoterosSobrePermisible { get; set; }
        public decimal? AreaAfectada { get; set; }        
        public decimal? AreaRegular { get; set; }
        public decimal? AreaBueno { get; set; }
        public int? NroAfectado { get; set; }
        public int? NroRegular { get; set; }
        public int? NroBueno { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaCierre { get; set; }

        #region "Campos calculados"
        public int TotalGoteros
        {
            get
            {
                int sum = 0;
                if (GoterosDebajoPermisible.HasValue)
                {
                    sum = sum + (int)GoterosDebajoPermisible;
                }
                if (GoterosPermisible.HasValue)
                {
                    sum = sum + (int)GoterosPermisible;
                }
                if (GoterosSobrePermisible.HasValue)
                {
                    sum = sum + (int)GoterosSobrePermisible;
                }
                return sum;
            }
        }
        public decimal AreaEvaluada
        {
            get
            {
                Decimal suma = 0;
                if (AreaAfectada.HasValue)
                    suma += (Decimal)AreaAfectada;

                if (AreaRegular.HasValue)
                    suma += (Decimal)AreaRegular;

                if (AreaBueno.HasValue)
                    suma += (Decimal)AreaBueno;

                return suma;
            }
        }
        #endregion

        #region Metodos de calculo
        public decimal? PorcentajeAreaAfectada { get; set; }
        public decimal? PorcentajeAreaRegular { get; set; }
        public decimal? PorcentajeAreaBuena { get; set; }
        public void CalcularPorcentajeHa()
        {
            PorcentajeAreaAfectada = 0;
            PorcentajeAreaRegular = 0;
            PorcentajeAreaBuena = 0;

            if (Hectarea.HasValue)
            {

                if (Hectarea > 0)
                {
                    ///---///
                    if (AreaAfectada.HasValue)
                    {
                        PorcentajeAreaAfectada = 100 * AreaAfectada / Hectarea;
                    }
                    else
                    {
                        PorcentajeAreaAfectada = null;
                    }
                    ///---///
                    if (AreaRegular.HasValue)
                    {
                        PorcentajeAreaRegular = 100 * AreaRegular / Hectarea;
                    }
                    else
                    {
                        PorcentajeAreaRegular = null;
                    }
                    ///---///
                    if (AreaBueno.HasValue)
                    {
                        PorcentajeAreaBuena = 100 * AreaBueno / Hectarea;
                    }
                    else
                    {
                        PorcentajeAreaBuena = null;
                    }
                    ///---///
                }
                else
                {
                    PorcentajeAreaAfectada = null;
                    PorcentajeAreaRegular = null;
                    PorcentajeAreaBuena = null;
                }
            }
            else
            {
                PorcentajeAreaAfectada = null;
                PorcentajeAreaRegular = null;
                PorcentajeAreaBuena = null;
            }
        }
        #endregion
        public bool Estado { get; set; }
    }
}
