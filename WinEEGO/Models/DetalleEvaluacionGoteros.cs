using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEEGO.Models
{
    public class DetalleEvaluacionGoteros
    {
        public int Id { get; set; }        
        public int IdParent { get; set; }
        public string Valvula { get; set; }
        public decimal? Hectarea { get; set; }
        public decimal? Cu { get; set; }        
        public decimal? Cv { get; set; }
        public decimal? Cd { get; set; }
        public decimal? Muestra01 { get; set; }
        public decimal? Muestra02 { get; set; }
        public decimal? Muestra03 { get; set; }
        public decimal? Muestra04 { get; set; }
        public decimal? Muestra05 { get; set; }
        public decimal? Muestra06 { get; set; }
        public decimal? Muestra07 { get; set; }
        public decimal? Muestra08 { get; set; }
        public decimal? Muestra09 { get; set; }
        public decimal? Muestra10 { get; set; }
        public decimal? Muestra11 { get; set; }
        public decimal? Muestra12 { get; set; }
        public decimal? Muestra13 { get; set; }
        public decimal? Muestra14 { get; set; }
        public decimal? Muestra15 { get; set; }
        public decimal? Muestra16 { get; set; }
        public decimal? Muestra17 { get; set; }
        public decimal? Muestra18 { get; set; }
        public decimal? Muestra19 { get; set; }
        public decimal? Muestra20 { get; set; }
        public decimal? Muestra21 { get; set; }
        public decimal? Muestra22 { get; set; }
        public decimal? Muestra23 { get; set; }
        public decimal? Muestra24 { get; set; }
        public decimal? Muestra25 { get; set; }
        public decimal? Muestra26 { get; set; }
        public decimal? Muestra27 { get; set; }
        public decimal? Muestra28 { get; set; }
        public decimal? Muestra29 { get; set; }
        public decimal? Muestra30 { get; set; }
        public decimal? Muestra31 { get; set; }
        public decimal? Muestra32 { get; set; }
        public decimal? Muestra33 { get; set; }
        public decimal? Muestra34 { get; set; }
        public decimal? Muestra35 { get; set; }
        public decimal? Muestra36 { get; set; }
        public decimal? PresionCu { get; set; }
        public decimal? Presion01 { get; set; }
        public decimal? Presion02 { get; set; }
        public decimal? Presion03 { get; set; }
        public decimal? Presion04 { get; set; }
        public decimal? Presion05 { get; set; }
        public decimal? Presion06 { get; set; }
        public decimal? Presion07 { get; set; }
        public decimal? Presion08 { get; set; }
        public decimal? Presion09 { get; set; }
        public decimal? Presion10 { get; set; }
        public decimal? Presion11 { get; set; }
        public decimal? Presion12 { get; set; }
        public decimal? Presion13 { get; set; }
        public decimal? Presion14 { get; set; }
        public decimal? Presion15 { get; set; }
        public decimal? Presion16 { get; set; }

        #region Metodos para actualizar los datos
        public void RefreshCoeficientes()
        {            
            Cu = null;
            Cv = null;
            Cd = null;            
            
            List<NodoEvaluacion> listNodo = new List<NodoEvaluacion>();
            if (Muestra01.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra01 });
            if (Muestra02.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra02 });
            if (Muestra03.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra03 });
            if (Muestra04.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra04 });
            if (Muestra05.HasValue)
                listNodo.Add(new  NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra05 });
            if (Muestra06.HasValue)
                listNodo.Add(new  NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra06 });
            if (Muestra07.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra07 });
            if (Muestra08.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra08 });
            if (Muestra09.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra09 });
            if (Muestra10.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra10 });
            if (Muestra11.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra11 });
            if (Muestra12.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra12 });
            if (Muestra13.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra13 });
            if (Muestra14.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra14 });
            if (Muestra15.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra15 });
            if (Muestra16.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra16 });
            if (Muestra17.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra17 });
            if (Muestra18.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra18 });
            if (Muestra19.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra19 });
            if (Muestra20.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra20 });
            if (Muestra21.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra21 });
            if (Muestra22.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra22 });
            if (Muestra23.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra23 });
            if (Muestra24.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra24 });
            if (Muestra25.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra25 });
            if (Muestra26.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra26 });
            if (Muestra27.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra27 });
            if (Muestra28.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra28 });
            if (Muestra29.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra29 });
            if (Muestra30.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra30 });
            if (Muestra31.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra31 });
            if (Muestra32.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra32 });
            if (Muestra33.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra33 });
            if (Muestra34.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra34 });
            if (Muestra35.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra35 });
            if (Muestra36.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Muestra36 });
            ///
            ///Si la lista tiene valores, se procede a calcular
            ///
            if (listNodo.Count > 0)
            {
                decimal promMuestras = Promedio(listNodo);
                decimal promMuestras25 = Promedio25(listNodo.OrderBy(o => o.Muestra).ToList());
                decimal? desEstMuestras = DesviacionEstandar(listNodo);

                if (promMuestras != 0)
                {
                    coeUni = 100 * promMuestras25 / promMuestras;

                    if (desEstMuestras != null)
                    {
                        coeVar = 100 * desEstMuestras / promMuestras;
                    }
                    else
                    {
                        coeVar = null;
                    }

                    if (Qnominal != null && Qnominal != 0)
                    {
                        coeDes = 100 * (promMuestras - Qnominal) / Qnominal;
                    }
                    else
                    {
                        coeDes = null;
                    }

                    if (coeUni > 0)
                    {

                    }
                    else
                    {
                        if (desEstMuestras != null)
                        {
                            coeUni = (100 * (1 - ((Decimal)1.27 * desEstMuestras / promMuestras)));
                        }
                        else
                        {
                            coeUni = null;
                        }
                    }                    
                }
            }
        }
        decimal Promedio(List<NodoEvaluacion> obj)
        {
            int total = obj.Count;
            decimal sum = 0;
            foreach (var item in obj)
            {
                sum = (sum + (decimal)item.Muestra);
            }
            return sum / total;
        }
        decimal Promedio25(List<NodoEvaluacion> obj)
        {
            int total = obj.Count / 4;
            decimal sum = 0;

            for (int i = 0; i < total; i++)
            {
                NodoEvaluacion item = obj[i];
                sum = (sum + (decimal)item.Muestra);
            }
            if (total > 0)
            {
                return sum / total;
            }
            else
            {
                return 0;
            }
        }
        decimal? DesviacionEstandar(List<NodoEvaluacion> obj)
        {
            int N = obj.Count;
            decimal sum = 0, prom = 0, sumapotencias = 0;

            foreach (var item in obj)
            {
                sum = (sum + (decimal)item.Muestra);
            }

            if (N > 1)
            {
                prom = sum / N;

                foreach (var item in obj)
                {
                    sumapotencias += (decimal)Math.Pow((double)(item.Muestra - prom), 2);
                }

                return (decimal)Math.Sqrt((double)((1 * sumapotencias) / (N - 1)));
            }
            else
            {
                return null;
            }
        }
        public void RefreshCUPresion()
        {
            coeUniPres = null;
            ///
            ///Cargar a una lista para el calculo
            ///
            List<NodoEvaluacion> listNodo = new List<NodoEvaluacion>();
            if (Presion01.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Presion01 });
            if (Presion02.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Presion02 });
            if (Presion03.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Presion03 });
            if (Presion04.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Presion04 });
            if (Presion05.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Presion05 });
            if (Presion06.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Presion06 });
            if (Presion07.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Presion07 });
            if (Presion08.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Presion08 });
            if (Presion09.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Presion09 });
            if (Presion10.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Presion10 });
            if (Presion11.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Presion11 });
            if (Presion12.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Presion12 });
            if (Presion13.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Presion13 });
            if (Presion14.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Presion14 });
            if (Presion15.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Presion15 });
            if (Presion16.HasValue)
                listNodo.Add(new NodoEvaluacion() { Valvula = Valvula, Muestra = Presion16 });

            if (listNodo.Count > 0)
            {
                decimal promMuestras = Promedio(listNodo);
                //decimal promMuestras25 = Promedio25(listNodo.OrderBy(o => o.Muestra).ToList());
                decimal? desEstMuestras = DesviacionEstandar(listNodo);

                if (desEstMuestras != null)
                {
                    coeUniPres = (100 * (1 - ((Decimal)1.27 * desEstMuestras / promMuestras)));
                }
                else
                {
                    coeUniPres = null;
                }
            }            
        }
        #endregion

        #region Propiedad Actualizables en Edicion
        public decimal? Qnominal { get; set; }

        decimal? coeUni;
        public decimal? CoeficienteUniformidad { get => coeUni; }

        decimal? coeVar;
        public decimal? CoeficienteVariacion { get => coeVar; }

        decimal? coeDes;
        public decimal? CoeficienteDesviacion { get => coeDes; }

        decimal? coeUniPres;
        public decimal? CoeficienteUniformidadPresion { get => coeUniPres; }

        #endregion
    }
}
