using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppTachito.Models.Report
{
    public class EvaluacionAcumulado
    {
        public string Cultivo { get; set; }
        public string Lote { get; set; }
        public string Valvula { get; set; }
        public List<DetalleEvaluacionCorta> Detalle { get; set; }
        public int FallasAcumuladas
        {
            get
            {
                if (Detalle == null)
                    return 0;
                else
                {
                    int cont = 0;
                    foreach (var item in Detalle)
                    {
                        if (item.Variacion != null && item.Incluir)
                        {
                            if (Math.Abs((decimal)item.Variacion) > (decimal)10)
                            {
                                cont++;
                            }
                        }
                    }
                    return cont;
                }
            }
        }
        public int FallasSucesivas
        {
            get
            {
                if (Detalle == null)
                    return 0;
                else
                {
                    int cont = 0;
                    foreach (var item in (from a in Detalle orderby a.Fecha descending select a).ToList())
                    {
                        if (item.Variacion != null && item.Incluir)
                        {
                            if (Math.Abs((decimal)item.Variacion) > (decimal)10)
                            {
                                cont++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    return cont;
                }
            }
        }
        public int AlertasAcumuladas
        {
            get
            {
                if (Detalle == null)
                    return 0;
                else
                {
                    int cont = 0;
                    foreach (var item in Detalle)
                    {
                        if (item.Variacion != null && item.Incluir)
                        {
                            if (Math.Abs((decimal)item.Variacion) > (decimal)7 && Math.Abs((decimal)item.Variacion) <= (decimal)10)
                            {
                                cont++;
                            }
                        }
                    }
                    return cont;
                }
            }
        }
        public int AlertasSucesivas
        {
            get
            {
                if (Detalle == null)
                    return 0;
                else
                {
                    int cont = 0;
                    foreach (var item in (from a in Detalle orderby a.Fecha descending select a).ToList())
                    {
                        if (item.Variacion != null && item.Incluir)
                        {
                            if (Math.Abs((decimal)item.Variacion) > (decimal)7 && Math.Abs((decimal)item.Variacion) <= (decimal)10)
                            {
                                cont++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    return cont;
                }
            }
        }
    }
}
