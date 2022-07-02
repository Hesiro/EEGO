using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WinAppTachito.Business;
using WinAppTachito.Models.Report;

namespace WinAppTachito.Views.Volumen.Report
{
    public partial class FormReporteResumen : Form
    {
        List<ResumenAnio> listaEvaluacion;
        public FormReporteResumen()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            btnActualizar.Enabled = false;
            tcReporte.Visible = false;                        
            if (btnActualizar.Text.Equals("MOSTRAR"))
            {
                btnActualizar.Text = "CAMBIAR";
                tcReporte.Visible = true;
                nudAnio.Enabled = false;
                ActualizarDatos();
            }
            else
            {
                btnActualizar.Text = "MOSTRAR";
                bsDatos.DataSource = null;
                cbCultivo.Items.Clear();
                cbCultivo.Text = "";
                tcReporte.Visible= false;
                nudAnio.Enabled = true;

                chart01.Series.Clear();
                chart01.ChartAreas.Clear();
                chart01.Legends.Clear();
                chart01.Titles.Clear();

            }
            btnActualizar.Enabled = true;
        }

        private void FormReporteResumen_Load(object sender, EventArgs e)
        {
            nudAnio.Value = DateTime.Today.Year;
        }
        private async void ActualizarDatos()
        {
            await Task.Run(() => {
                listaEvaluacion = EvaluacionVolumenBL.Instancia.ListResumenAnio((int)nudAnio.Value);
            });
            cbCultivo.Items.Clear();
            FiltroCultivos();
            Grafico01();
            Grafico02();
        }
        private void FiltroCultivos()
        {
            if (listaEvaluacion != null)
            {
                var res = (from a in listaEvaluacion
                           select a.Cultivo).Distinct();
                if (res != null)
                    foreach (var item in res)
                        cbCultivo.Items.Add(item.ToString());

            }
        }

        private void cbCultivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarDatos(cbCultivo.Text);
        }
        private void FiltrarDatos(string cultivo)
        {
            if (listaEvaluacion != null)
            {
                List<ResumenAnio> listaFiltrada = new List<ResumenAnio>();
                
                        var res = from a in listaEvaluacion
                                  where a.Cultivo.Equals(cbCultivo.Text)
                                  select a;
                        if (res != null)
                            listaFiltrada = res.ToList();                   
                bsDatos.DataSource = listaFiltrada;
            }
        }
        private void Grafico01()
        {
            chart01.Series.Clear();
            chart01.ChartAreas.Clear();
            chart01.Legends.Clear();
            chart01.Titles.Clear();
            chart01.ChartAreas.Add("Arandano");
            chart01.ChartAreas.Add("Palto");
            chart01.Series.Add("Arandano");
            chart01.Series.Add("Palto");
            chart01.Legends.Add("Arandano");
            chart01.Legends.Add("Palto");

            foreach (Series serie in chart01.Series)
            {
                serie.ChartType = SeriesChartType.Pie;
                serie.Font = new Font("Arial", 8, FontStyle.Regular);
                serie["PieLabelStyle"] = "Inside";
                serie["CollectedThresholdUsePercent"] = "true";
                serie.IsValueShownAsLabel = true;
                serie.LabelFormat = "#0.0 '%'";                
            }            

            if (listaEvaluacion != null)
            {
                int buenosAra = 0, malosAra = 0, buenosPal = 0, malosPal = 0;
                if (listaEvaluacion.Count > 0)
                {
                    foreach (var item in listaEvaluacion)
                    {
                        if (item.Cultivo == "Arandano")
                        {
                            buenosAra = buenosAra + item.TotalVB;
                            malosAra = malosAra + item.TotalVM;
                        }
                        if (item.Cultivo == "Palto")
                        {
                            buenosPal = buenosPal + item.TotalVB;
                            malosPal = malosPal + item.TotalVM;
                        }
                    }
                }

                double porBA=0,porMA=0,porBP=0,porMP=0;
                if(buenosAra != 0 && malosAra != 0)
                {
                    porBA = (double) 100 * buenosAra / (buenosAra + malosAra);
                    porMA = (double) 100 * malosAra / (buenosAra + malosAra);
                }
                if (buenosPal != 0 && malosPal != 0)
                {
                    porBP = (double) 100 * buenosPal / (buenosPal + malosPal);
                    porMP = (double) 100 * malosPal / (buenosPal + malosPal);
                }

                double[] yValuesAra = { porBA, porMA };
                double[] yValuesPal = { porBP, porMP };
                string[] xValues = { "Buenos", "Malos"};

                chart01.Series["Arandano"].Points.DataBindXY(xValues, yValuesAra);
                chart01.Series["Arandano"].ChartArea = "Arandano";
                chart01.Series["Arandano"].Legend = "Arandano";                
                chart01.Legends["Arandano"].DockedToChartArea = "Arandano";
                chart01.Legends["Arandano"].Title = "Arandano";
                chart01.Legends["Arandano"].IsDockedInsideChartArea = false;

                chart01.Series["Palto"].Points.DataBindXY(xValues, yValuesPal);
                chart01.Series["Palto"].ChartArea = "Palto";
                chart01.Series["Palto"].Legend = "Palto";
                chart01.Legends["Palto"].DockedToChartArea = "Palto";
                chart01.Legends["Palto"].Title = "Palto";
                chart01.Legends["Palto"].IsDockedInsideChartArea = false;
                
            }          

            
        }
        private void Grafico02()
        {
            chart02.Series.Clear();
            chart02.ChartAreas.Clear();
            chart02.Legends.Clear();
            chart02.Titles.Clear();
            chart02.ChartAreas.Add("Arandano");
            chart02.ChartAreas.Add("Palto");
            chart02.Series.Add("Arandano");
            chart02.Series.Add("Palto");
            chart02.Legends.Add("Arandano");
            chart02.Legends.Add("Palto");
            foreach (Series serie in chart02.Series)
            {
                serie.ChartType = SeriesChartType.Column;
                serie.Font = new Font("Arial", 8, FontStyle.Regular);
                serie.IsValueShownAsLabel = true;
                serie.LabelFormat = "#0.0 '%'";
                //serie.MarkerStyle = MarkerStyle.Circle;
                //serie.MarkerBorderColor = Color.Black;
                //serie.BorderWidth = 2;
                //serie.MarkerSize = 6;
            }

            chart02.ChartAreas["Arandano"].BackColor = Color.Transparent;
            chart02.ChartAreas["Arandano"].AxisX.MajorGrid.Enabled = true;
            chart02.ChartAreas["Arandano"].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart02.ChartAreas["Arandano"].AxisX.MajorGrid.LineWidth = 1;
            chart02.ChartAreas["Arandano"].AxisX.LabelStyle.Font = new Font("Arial", 8, FontStyle.Regular);
            chart02.ChartAreas["Arandano"].AxisX.LabelStyle.IsStaggered = false;
            chart02.ChartAreas["Arandano"].AxisX.IsMarginVisible = true;
            chart02.ChartAreas["Arandano"].AxisX.LabelStyle.Format = "d MMM";

            chart02.ChartAreas["Arandano"].AxisY.MajorGrid.Enabled = true;
            chart02.ChartAreas["Arandano"].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart02.ChartAreas["Arandano"].AxisY.MajorGrid.LineWidth = 1;
            chart02.ChartAreas["Arandano"].AxisY.LabelStyle.Font = new Font("Arial", 8, FontStyle.Regular);
            chart02.ChartAreas["Arandano"].AxisY.Maximum = 100;
            chart02.ChartAreas["Arandano"].AxisY.Minimum = 0;
            chart02.ChartAreas["Arandano"].AxisY.LabelStyle.Format = "#0 '%'";

            chart02.ChartAreas["Palto"].BackColor = Color.Transparent;
            chart02.ChartAreas["Palto"].AxisX.MajorGrid.Enabled = true;
            chart02.ChartAreas["Palto"].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart02.ChartAreas["Palto"].AxisX.MajorGrid.LineWidth = 1;
            chart02.ChartAreas["Palto"].AxisX.LabelStyle.Font = new Font("Arial", 8, FontStyle.Regular);
            chart02.ChartAreas["Palto"].AxisX.LabelStyle.IsStaggered = false;
            chart02.ChartAreas["Palto"].AxisX.IsMarginVisible = true;
            chart02.ChartAreas["Palto"].AxisX.LabelStyle.Format = "d MMM";

            chart02.ChartAreas["Palto"].AxisY.MajorGrid.Enabled = true;
            chart02.ChartAreas["Palto"].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart02.ChartAreas["Palto"].AxisY.MajorGrid.LineWidth = 1;
            chart02.ChartAreas["Palto"].AxisY.LabelStyle.Font = new Font("Arial", 8, FontStyle.Regular);
            chart02.ChartAreas["Palto"].AxisY.Maximum = 100;
            chart02.ChartAreas["Palto"].AxisY.Minimum = 0;
            chart02.ChartAreas["Palto"].AxisY.LabelStyle.Format = "#0 '%'";

            if (listaEvaluacion != null)
            {
                double?[] yValuesAra = { null, null, null, null, null, null, null, null, null, null, null, null };
                double?[] yValuesPal = { null, null, null, null, null, null, null, null, null, null, null, null };
                String[] xValues = { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Set", "Oct", "Nov", "Dic"};


                if (listaEvaluacion.Count > 0)
                {
                    foreach (var item in listaEvaluacion)
                    {
                        if (item.Cultivo == "Arandano")
                        {
                            yValuesAra[item.Fecha.Value.Month - 1] = (double)item.Cumplimiento;
                        }
                        if (item.Cultivo == "Palto")
                        {
                            yValuesPal[item.Fecha.Value.Month - 1] = (double)item.Cumplimiento;
                        }
                    }
                }


                chart02.Series["Arandano"].Points.DataBindXY(xValues, yValuesAra);
                chart02.Series["Arandano"].ChartArea = "Arandano";
                chart02.Series["Arandano"].Legend = "Arandano";
                chart02.Legends["Arandano"].DockedToChartArea = "Arandano";
                chart02.Legends["Arandano"].Title = "Arandano";
                chart02.Legends["Arandano"].IsDockedInsideChartArea = false;

                chart02.Series["Palto"].Points.DataBindXY(xValues, yValuesPal);
                chart02.Series["Palto"].ChartArea = "Palto";
                chart02.Series["Palto"].Legend = "Palto";
                chart02.Legends["Palto"].DockedToChartArea = "Palto";
                chart02.Legends["Palto"].Title = "Palto";
                chart02.Legends["Palto"].IsDockedInsideChartArea = false;

            }
        }
    }
}
