using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Models
{
    public class EvaluacionGoterosAnio
    {
        public int RepMes { get; set; }
        public string RepNombreMes { get; set; }
        public decimal? CoeficienteUniformidad
        {
            get
            {
                decimal? coeficienteUniformidad = null;
                decimal sumaHa = 0;
                decimal sumaCUxHa = 0;

                if (Evaluaciones != null)
                    if (Evaluaciones.Count > 0)
                    {
                        foreach (var item in Evaluaciones)
                        {
                            if (item.CoeficienteUniformidad != null)
                            {
                                sumaHa += item.AreaEvaluada;
                                sumaCUxHa += (item.AreaEvaluada * (decimal)item.CoeficienteUniformidad);
                            }
                        }
                        if (sumaHa > 0)
                            coeficienteUniformidad = sumaCUxHa / sumaHa;

                    }
                return coeficienteUniformidad;

            }
        }

        public decimal? CoeficienteVariacion
        {
            get
            {
                decimal? coeficienteVariacion = null;
                decimal sumaHa = 0;
                decimal sumaCVxHa = 0;

                if (Evaluaciones != null)
                    if (Evaluaciones.Count > 0)
                    {
                        foreach (var item in Evaluaciones)
                        {
                            if (item.CoeficienteVariacion != null)
                            {
                                sumaHa += item.AreaEvaluada;
                                sumaCVxHa += (item.AreaEvaluada * (decimal)item.CoeficienteVariacion);
                            }
                        }
                        if (sumaHa > 0)
                            coeficienteVariacion = sumaCVxHa / sumaHa;
                    }

                return coeficienteVariacion;
            }
        }
        public Decimal? CoeficienteDesviacion
        {
            get
            {
                decimal? coeficienteDesviacion = null;
                decimal sumaHa = 0;
                decimal sumaCDxHa = 0;

                if (Evaluaciones != null)
                    if (Evaluaciones.Count > 0)
                    {
                        foreach (var item in Evaluaciones)
                        {
                            if (item.CoeficienteDesviacion != null)
                            {
                                sumaHa += item.AreaEvaluada;
                                sumaCDxHa += (item.AreaEvaluada * /*Math.Abs(*/(decimal)item.CoeficienteDesviacion)/*)*/;
                            }
                        }
                        if (sumaHa > 0)
                            coeficienteDesviacion = sumaCDxHa / sumaHa;
                    }

                return coeficienteDesviacion;
            }
        }
        public List<EvaluacionGoteros> Evaluaciones { get; set; }
    }
}
