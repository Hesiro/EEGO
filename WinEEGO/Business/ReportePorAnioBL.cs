using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinEEGO.Database;
using WinEEGO.Models;

namespace WinEEGO.Business
{
    public class ReportePorAnioBL
    {
        private List<EvaluacionGoteros> listEvaluacion; 
        private List<EvaluacionGoterosAnio> listAnio; 
        private int anio;
        private string cultivo;
        public ReportePorAnioBL(int Anio, string Cultivo)
        {
            if (listAnio == null)
                CrearReporteMensual();

            anio = Anio;
            cultivo = Cultivo;
        }
        private void CrearReporteMensual()
        {
            listAnio = new List<EvaluacionGoterosAnio>
            {
                new EvaluacionGoterosAnio() { RepMes = 1, RepNombreMes = "Enero", Evaluaciones = new List<EvaluacionGoteros>() },
                new EvaluacionGoterosAnio() { RepMes = 2, RepNombreMes = "Febrero", Evaluaciones = new List<EvaluacionGoteros>() },
                new EvaluacionGoterosAnio() { RepMes = 3, RepNombreMes = "Marzo", Evaluaciones = new List<EvaluacionGoteros>() },
                new EvaluacionGoterosAnio() { RepMes = 4, RepNombreMes = "Abril", Evaluaciones = new List<EvaluacionGoteros>() },
                new EvaluacionGoterosAnio() { RepMes = 5, RepNombreMes = "Mayo", Evaluaciones = new List<EvaluacionGoteros>() },
                new EvaluacionGoterosAnio() { RepMes = 6, RepNombreMes = "Junio", Evaluaciones = new List<EvaluacionGoteros>() },
                new EvaluacionGoterosAnio() { RepMes = 7, RepNombreMes = "Julio", Evaluaciones = new List<EvaluacionGoteros>() },
                new EvaluacionGoterosAnio() { RepMes = 8, RepNombreMes = "Agosto", Evaluaciones = new List<EvaluacionGoteros>() },
                new EvaluacionGoterosAnio() { RepMes = 9, RepNombreMes = "Septiembre", Evaluaciones = new List<EvaluacionGoteros>() },
                new EvaluacionGoterosAnio() { RepMes = 10, RepNombreMes = "Octubre", Evaluaciones = new List<EvaluacionGoteros>() },
                new EvaluacionGoterosAnio() { RepMes = 11, RepNombreMes = "Noviembre", Evaluaciones = new List<EvaluacionGoteros>() },
                new EvaluacionGoterosAnio() { RepMes = 12, RepNombreMes = "Diciembre", Evaluaciones = new List<EvaluacionGoteros>() }
            };
        }
        private void DevolverDatos()
        {
            listEvaluacion = EvaluacionGoterosDA.Instancia.ListReporte(anio, cultivo, "Por Cultivo");
        }
        public List<EvaluacionGoterosAnio> ListaReporte()
        {
            if (listEvaluacion == null)
                DevolverDatos();
            List<EvaluacionGoteros> res = new List<EvaluacionGoteros>();            
                res = (from a in listEvaluacion
                       select a).ToList();            

            foreach (var item in listAnio)
            {
                item.Evaluaciones.Clear();
            }

            if (res != null)
            {
                if (res.Count > 0)
                {
                    foreach (var item in res)
                    {
                        if (item.Fecha.Month == 1)
                            listAnio[0].Evaluaciones.Add(item);

                        if (item.Fecha.Month == 2)
                            listAnio[1].Evaluaciones.Add(item);

                        if (item.Fecha.Month == 3)
                            listAnio[2].Evaluaciones.Add(item);

                        if (item.Fecha.Month == 4)
                            listAnio[3].Evaluaciones.Add(item);

                        if (item.Fecha.Month == 5)
                            listAnio[4].Evaluaciones.Add(item);

                        if (item.Fecha.Month == 6)
                            listAnio[5].Evaluaciones.Add(item);

                        if (item.Fecha.Month == 7)
                            listAnio[6].Evaluaciones.Add(item);

                        if (item.Fecha.Month == 8)
                            listAnio[7].Evaluaciones.Add(item);

                        if (item.Fecha.Month == 9)
                            listAnio[8].Evaluaciones.Add(item);

                        if (item.Fecha.Month == 10)
                            listAnio[9].Evaluaciones.Add(item);

                        if (item.Fecha.Month == 11)
                            listAnio[10].Evaluaciones.Add(item);

                        if (item.Fecha.Month == 12)
                            listAnio[11].Evaluaciones.Add(item);
                    }
                }
            }
            return listAnio;
        }
    }
    
}
