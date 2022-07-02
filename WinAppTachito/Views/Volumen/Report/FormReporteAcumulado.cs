using SpreadsheetLight;
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
    public partial class FormReporteAcumulado : Form
    {
        List<EvaluacionAcumulado> listaEvaluacion;
        EvaluacionAcumulado currentEvaluacion = new EvaluacionAcumulado();
        List<DetalleEvaluacionCorta> resultado1;
        public FormReporteAcumulado()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            btnActualizar.Enabled = false;
            btnFiltrar.Enabled = false;
            btnExportar.Enabled = false;
            dgvDatos.Enabled = false;
            panFiltro.Visible = false;
            cbCultivo.Enabled = true;
            cbArea.Enabled = false;
            cbValvula.Enabled = false;

            ActualizarDatos();

            dgvDatos.Enabled = true;
            btnActualizar.Enabled = true;
            btnFiltrar.Enabled = true;
            btnExportar.Enabled = true;
        }
        private async void ActualizarDatos()
        {
            cbCultivo.Items.Clear();
            cbArea.Items.Clear();
            cbValvula.Items.Clear();

            cbCultivo.Items.Add("Todos");
            cbArea.Items.Add("Todos");
            cbValvula.Items.Add("Todos");

            cbCultivo.SelectedIndex = 0;
            cbArea.SelectedIndex = 0;
            cbValvula.SelectedIndex = 0;

            await Task.Run(() => {
                listaEvaluacion = EvaluacionVolumenBL.Instancia.ListAcumulado();
            });            
            //bsDatos.DataSource = listaEvaluacion;            

            FiltrarDatos(cbCultivo.Text, cbArea.Text, cbValvula.Text);
            FiltroCultivos();
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDatos.RowCount > 0)
                CargarDatos();
        }
        private void CargarDatos()
        {
            try
            {
                if (bsDatos.Current != null)
                {
                    currentEvaluacion = (EvaluacionAcumulado)bsDatos.Current;
                    bsDetalle.DataSource = currentEvaluacion.Detalle;
                    PaintGrid();
                    Grafico01();
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister("frmReporteAcumulado - " + ex.Message);
            }

        }
        private void PaintGrid()
        {
            if (dgvDetalle.RowCount > 0)
            {
                try
                {
                    decimal limiteSuperior = 10;
                    decimal limiteInferior = -10;

                    decimal limiteSuperior2 = 7;
                    decimal limiteInferior2 = -7;

                    decimal tCurrent;
                    for (int i = 0; i < dgvDetalle.RowCount; i++)
                    {
                        int colGrid = 4;
                        if (dgvDetalle.Rows[i].Cells[colGrid].Value != null)
                        {
                            if (decimal.TryParse(dgvDetalle.Rows[i].Cells[colGrid].Value.ToString(), out tCurrent))
                            {
                                if (tCurrent <= limiteSuperior2 && tCurrent >= limiteInferior2)
                                {
                                    dgvDetalle.Rows[i].Cells[colGrid].Style.ForeColor = Color.White;
                                    dgvDetalle.Rows[i].Cells[colGrid].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if (tCurrent <= limiteSuperior && tCurrent >= limiteInferior)
                                    {
                                        dgvDetalle.Rows[i].Cells[colGrid].Style.ForeColor = Color.Black;
                                        dgvDetalle.Rows[i].Cells[colGrid].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgvDetalle.Rows[i].Cells[colGrid].Style.ForeColor = Color.White;
                                        dgvDetalle.Rows[i].Cells[colGrid].Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.FailRegister("frmReporteAcumulado - " + ex.Message);
                }
            }
        }

        private void Grafico01()
        {
            chart01.Series.Clear();
            chart01.ChartAreas.Clear();
            chart01.Legends.Clear();
            chart01.Titles.Clear();
            chart01.ChartAreas.Add("Grafico");
            chart01.Series.Add("Del gotero testigo");

            foreach (Series serie in chart01.Series)
            {
                serie.ChartType = SeriesChartType.Line;
                serie.Font = new Font("Arial", 8, FontStyle.Regular);
                serie.MarkerStyle = MarkerStyle.Circle;
                serie.MarkerBorderColor = Color.Black;
                serie.BorderWidth = 2;
                serie.MarkerSize = 6;
            }

            chart01.ChartAreas["Grafico"].BackColor = Color.Transparent;
            chart01.ChartAreas["Grafico"].AxisX.MajorGrid.Enabled = true;
            chart01.ChartAreas["Grafico"].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart01.ChartAreas["Grafico"].AxisX.MajorGrid.LineWidth = 1;
            chart01.ChartAreas["Grafico"].AxisX.LabelStyle.Font = new Font("Arial", 8, FontStyle.Regular);
            chart01.ChartAreas["Grafico"].AxisX.LabelStyle.IsStaggered = false;
            chart01.ChartAreas["Grafico"].AxisX.IsMarginVisible = true;
            chart01.ChartAreas["Grafico"].AxisX.LabelStyle.Format = "d MMM";

            chart01.ChartAreas["Grafico"].AxisY.MajorGrid.Enabled = true;
            chart01.ChartAreas["Grafico"].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart01.ChartAreas["Grafico"].AxisY.MajorGrid.LineWidth = 1;
            chart01.ChartAreas["Grafico"].AxisY.LabelStyle.Font = new Font("Arial", 8, FontStyle.Regular);
            chart01.ChartAreas["Grafico"].AxisY.Maximum = 50;
            chart01.ChartAreas["Grafico"].AxisY.Minimum = -50;
            chart01.ChartAreas["Grafico"].AxisY.LabelStyle.Format = "#0 '%'";
                        
            if (currentEvaluacion != null)
            {
                chart01.Titles.Add("Grafico");
                chart01.Titles[0].Text = currentEvaluacion.Cultivo + " " + currentEvaluacion.Lote + " " + currentEvaluacion.Valvula;

                resultado1 = (from ss in currentEvaluacion.Detalle
                                                           where ss.Incluir
                                                           select ss).ToList();

                chart01.Series["Del gotero testigo"].Points.DataBindXY(resultado1, "Fecha", resultado1, "Variacion");                
            }

            StripLine stripLineGreen = new StripLine();
            stripLineGreen.BackColor = Color.FromArgb(33, Color.Green);
            stripLineGreen.IntervalOffset = -7;
            stripLineGreen.StripWidth = 14;

            StripLine stripLineYellowExceso = new StripLine();
            stripLineYellowExceso.BackColor = Color.FromArgb(33, Color.Yellow);
            stripLineYellowExceso.IntervalOffset = 7;
            stripLineYellowExceso.StripWidth = 3;

            StripLine stripLineYellowDeficit = new StripLine();
            stripLineYellowDeficit.BackColor = Color.FromArgb(33, Color.Yellow);
            stripLineYellowDeficit.IntervalOffset = -10;
            stripLineYellowDeficit.StripWidth = 3;

            StripLine stripLineRedExceso = new StripLine();
            stripLineRedExceso.BackColor = Color.FromArgb(33, Color.Red);
            stripLineRedExceso.IntervalOffset = 10;
            stripLineRedExceso.StripWidth = 40;

            StripLine stripLineRedDeficit = new StripLine();
            stripLineRedDeficit.BackColor = Color.FromArgb(33, Color.Red);
            stripLineRedDeficit.IntervalOffset = -50;
            stripLineRedDeficit.StripWidth = 40;

            chart01.ChartAreas["Grafico"].AxisY.StripLines.Add(stripLineGreen);
            chart01.ChartAreas["Grafico"].AxisY.StripLines.Add(stripLineYellowExceso);
            chart01.ChartAreas["Grafico"].AxisY.StripLines.Add(stripLineYellowDeficit);
            chart01.ChartAreas["Grafico"].AxisY.StripLines.Add(stripLineRedExceso);
            chart01.ChartAreas["Grafico"].AxisY.StripLines.Add(stripLineRedDeficit);
        }

        private void FormReporteAcumulado_Load(object sender, EventArgs e)
        {
            panFiltro.Visible = false;
            cbCultivo.Enabled = true;
            cbArea.Enabled = false;
            cbValvula.Enabled = false;
        }

        private void chart01_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            switch (e.HitTestResult.ChartElementType)
            {
                case ChartElementType.DataPoint:                   

                    if (e.HitTestResult.Series.Name.Equals("Del gotero testigo"))
                    {
                        e.Text = "Variacion: " +
                        chart01.Series[e.HitTestResult.Series.Name].Points[e.HitTestResult.PointIndex].GetValueByName("Y").ToString("N2") + "% \n" +
                        "Fecha: " + resultado1[e.HitTestResult.PointIndex].Fecha.ToShortDateString() + "\n" + 
                        resultado1[e.HitTestResult.PointIndex].Nota;
                    }

                    break;

            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (listaEvaluacion != null)
                if (panFiltro.Visible)
                    panFiltro.Visible = false;
                else
                    panFiltro.Visible = true;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (listaEvaluacion != null)
            {
                saveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pathFile = saveFileDialog.FileName;
                    SLDocument oSLDocument = new SLDocument();

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Cultivo", typeof(string));
                    dt.Columns.Add("Area", typeof(string));
                    dt.Columns.Add("Valvula", typeof(string));                    
                    dt.Columns.Add(DateTime.Today.AddDays(-30).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-29).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-28).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-27).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-26).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-25).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-24).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-23).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-22).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-21).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-20).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-19).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-18).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-17).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-16).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-15).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-14).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-13).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-12).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-11).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-10).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-9).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-8).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-7).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-6).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-5).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-4).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-3).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-2).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(-1).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add(DateTime.Today.AddDays(0).ToShortDateString(), typeof(decimal));
                    dt.Columns.Add("Fallas Acumuladas", typeof(int));
                    dt.Columns.Add("Fallas Sucesivas", typeof(int));
                    dt.Columns.Add("Alertas Acumuladas", typeof(int));
                    dt.Columns.Add("Alertas Sucesivas", typeof(int));

                    foreach (var item in listaEvaluacion)
                    {
                        dt.Rows.Add(
                            item.Cultivo,
                            item.Lote,
                            item.Valvula,
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-30)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-29)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-28)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-27)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-26)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-25)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-24)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-23)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-22)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-21)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-20)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-19)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-18)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-17)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-16)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-15)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-14)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-13)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-12)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-11)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-10)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-9)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-8)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-7)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-6)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-5)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-4)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-3)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-2)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(-1)),
                            BuscarImprimir(item.Detalle, DateTime.Today.AddDays(0)),
                            item.FallasAcumuladas,
                            item.FallasSucesivas,
                            item.AlertasAcumuladas,
                            item.AlertasSucesivas);
                    }
                    
                    oSLDocument.ImportDataTable(1, 1, dt, true);
                    oSLDocument.SaveAs(pathFile);

                }
            }            
        }

        private decimal? BuscarImprimir(List<DetalleEvaluacionCorta> lista, DateTime fecha)
        {
            if (lista != null)
            {
                var res = from a in lista where a.Fecha == fecha select a.Variacion;
                if (res != null)
                    if (res.Count() > 0)
                        return res.First();
                    else
                        return null;
                else
                    return null;
            }
            else
                return null;
        }
        private void FiltrarDatos(string cultivo, string area, string valvula)
        {
            if (listaEvaluacion != null)
            {
                List<EvaluacionAcumulado> listaFiltrada = new List<EvaluacionAcumulado>();
                if (cultivo.Equals("Todos") && area.Equals("Todos") && valvula.Equals("Todos"))
                {
                    listaFiltrada = listaEvaluacion.ToList();
                }
                else
                {
                    if (area.Equals("Todos") && valvula.Equals("Todos"))
                    {
                        var res = from a in listaEvaluacion
                                  where a.Cultivo.Equals(cbCultivo.Text)
                                  select a;
                        if (res != null)
                            listaFiltrada = res.ToList();
                    }
                    else
                    {
                        if (valvula.Equals("Todos"))
                        {
                            var res = from a in listaEvaluacion
                                      where a.Cultivo.Equals(cbCultivo.Text) && a.Lote.Equals(cbArea.Text)
                                      select a;
                            if (res != null)
                                listaFiltrada = res.ToList();
                        }
                        else
                        {
                            var res = from a in listaEvaluacion
                                      where a.Cultivo.Equals(cbCultivo.Text) && a.Lote.Equals(cbArea.Text) && a.Valvula.Equals(cbValvula.Text)
                                      select a;
                            if (res != null)
                                listaFiltrada = res.ToList();
                        }
                    }
                }                
                bsDatos.DataSource = listaFiltrada;
            }
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

        private void FiltroAreas()
        {
            if (true)
            {
                if (listaEvaluacion != null)
                {
                    var res = (from a in listaEvaluacion
                               where a.Cultivo.Equals(cbCultivo.Text)
                               select a.Lote).Distinct();
                    if (res != null)
                        foreach (var item in res)
                            cbArea.Items.Add(item.ToString());

                }
            }
        }
        private void FiltroValvulas()
        {
            if (true)
            {
                if (listaEvaluacion != null)
                {
                    var res = (from a in listaEvaluacion
                               where a.Cultivo.Equals(cbCultivo.Text) && a.Lote.Equals(cbArea.Text)
                               select a.Valvula).Distinct();
                    if (res != null)
                        foreach (var item in res)
                            cbValvula.Items.Add(item.ToString());

                }
            }
        }

        private void cbCultivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbArea.Items.Clear();
            cbValvula.Items.Clear();

            cbArea.Items.Add("Todos");
            cbValvula.Items.Add("Todos");

            cbArea.SelectedIndex = 0;
            cbValvula.SelectedIndex = 0;

            if (cbCultivo.Text.Equals("Todos"))
            {
                cbArea.Enabled = false;
                cbValvula.Enabled = false;
            }
            else
            {
                cbArea.Enabled = true;
                FiltroAreas();
            }

            FiltrarDatos(cbCultivo.Text, cbArea.Text, cbValvula.Text);
        }

        private void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {            
            cbValvula.Items.Clear();
           
            cbValvula.Items.Add("Todos");
            
            cbValvula.SelectedIndex = 0;

            if (cbArea.Text.Equals("Todos"))
            {                
                cbValvula.Enabled = false;
            }
            else
            {
                cbValvula.Enabled = true;
                FiltroValvulas();
            }

            FiltrarDatos(cbCultivo.Text, cbArea.Text, cbValvula.Text);
        }

        private void cbValvula_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarDatos(cbCultivo.Text, cbArea.Text, cbValvula.Text);
        }
    }
}
