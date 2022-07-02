using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinEEGO.Business;
using WinEEGO.Models;

namespace WinEEGO.Views.Eego
{
    public partial class frmOpenEvaluacion : Form
    {
        private List<EvaluacionGoteros> listEvaluacion = new List<EvaluacionGoteros>();
        private List<EvaluacionGoteros> listEvaluacionFiltro = new List<EvaluacionGoteros>();
        private EvaluacionGoteros currentEvaluacion = new EvaluacionGoteros();

        public event EventHandler onFormCerrado;

        private List<string> listToCombo = new List<string>();
        public frmOpenEvaluacion()
        {
            InitializeComponent();
        }

        private void frmOpenEvaluacion_Load(object sender, EventArgs e)
        {
            btnDetalles.Enabled = false;
            btnModificar.Enabled = false;
            btnQuitar.Enabled = false;
            btnReset.Enabled = false;
            dgDatos.Enabled = false;
            gbFiltro.Enabled = false;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (btnMostrar.Text.Equals("Mostrar"))
            {
                btnMostrar.Text = "Cambiar";
                dtpDesde.Enabled = false;
                dtpHasta.Enabled = false;

                btnDetalles.Enabled = true;
                btnModificar.Enabled = true;
                btnQuitar.Enabled = true;
                btnReset.Enabled = true;


                dgDatos.Enabled = true;

                ///Controles del fltro                
                cbArea.Text = "Todos";
                cbEstado.Text = "Todos";
                ///

                ActualizarDatos();

                ///Filtro para cargar al combo area               
                if (bgwFiltro.IsBusy)
                    bgwFiltro.CancelAsync();
                bgwFiltro.RunWorkerAsync();
                ///  
                gbFiltro.Enabled = true;
            }
            else
            {
                btnMostrar.Text = "Mostrar";
                dtpDesde.Enabled = true;
                dtpHasta.Enabled = true;
                btnDetalles.Enabled = false;
                btnModificar.Enabled = false;
                btnQuitar.Enabled = false;
                btnReset.Enabled = false;
                bsEvaluacionGoteros.DataSource = null;
                dgDatos.Enabled = false;
                ///Filtro de la lista  
                gbFiltro.Enabled = false;
                cbArea.Items.Clear();
                cbArea.Items.Add("Todos");
                ///
                gbFiltro.Enabled = false;
            }
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (dgDatos.RowCount > 0)
            {
                currentEvaluacion = (EvaluacionGoteros)bsEvaluacionGoteros.Current;
                if (currentEvaluacion != null)
                {
                    frmDetailEvaluacion frm = new frmDetailEvaluacion(currentEvaluacion);
                    frm.onFormCerrado += new EventHandler(frm_onFormCerrado);
                    if (this.MdiParent != null)
                        frm.MdiParent = this.MdiParent;

                    this.Hide();
                    frm.Show();
                }
            }
        }
        void frm_onFormCerrado(object sender, EventArgs e)
        {
            try
            {
                this.Show();
                ActualizarDatos();
            }
            catch (Exception)
            {                
            }
                
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgDatos.RowCount > 0)
            {
                currentEvaluacion = (EvaluacionGoteros)bsEvaluacionGoteros.Current;
                if (currentEvaluacion != null)
                    if (currentEvaluacion.Status.Equals("En creacion"))
                        if (MessageBox.Show("¿Esta seguro de eliminar registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            if (EvaluacionGoterosBL.Instancia.Delete(currentEvaluacion))
                                ActualizarDatos();
                            else
                                MessageBox.Show("No se pudo eliminar el registro", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarDatos()
        {
            listEvaluacion = EvaluacionGoterosBL.Instancia.List(dtpDesde.Value, dtpHasta.Value, Log.UsuarioSistema);
            FiltrarDatos();
        }
        private void FiltrarDatos()
        {
            listEvaluacionFiltro.Clear();

            if (cbArea.Text.Equals("Todos") && cbEstado.Text.Equals("Todos"))
            {
                listEvaluacionFiltro = listEvaluacion.ToList();
            }
            else
            {
                if (cbArea.Text.Equals("Todos"))
                {
                    var res = from a in listEvaluacion
                              where a.Status.Equals(cbEstado.Text)
                              select a;
                    if (res != null)
                        listEvaluacionFiltro = res.ToList();
                }
                else
                {
                    if (cbEstado.Text.Equals("Todos"))
                    {
                        var res = from a in listEvaluacion
                                  where a.Area.Equals(cbArea.Text)
                                  select a;
                        if (res != null)
                            listEvaluacionFiltro = res.ToList();
                    }
                    else
                    {
                        var res = from a in listEvaluacion
                                  where a.Area.Equals(cbArea.Text) && a.Status.Equals(cbEstado.Text)
                                  select a;
                        if (res != null)
                            listEvaluacionFiltro = res.ToList();

                    }
                }
            }

            bsEvaluacionGoteros.DataSource = listEvaluacionFiltro;
            CargarDato();
            PintarGrid();
        }

        private void dgDatos_SelectionChanged(object sender, EventArgs e)
        {
            CargarDato();
        }
        private void CargarDato()
        {
            if (dgDatos.RowCount > 0)
                currentEvaluacion = (EvaluacionGoteros)bsEvaluacionGoteros.Current;
        }
        private void PintarGrid()
        {
            if (dgDatos.RowCount > 0)
            {
                try
                {
                    Single cuLimiteSuperior = 90;
                    Single cuLimiteInferior = 70;
                    Single LimiteInferior = 7;
                    Single LimiteSuperior = 10;
                    Single tCurrent;

                    for (int i = 0; i < dgDatos.RowCount; i++)
                    {
                        if (dgDatos.Rows[i].Cells[5].Value != null)
                        {
                            if (Single.TryParse(dgDatos.Rows[i].Cells[5].Value.ToString(), out tCurrent))
                            {
                                if (tCurrent > cuLimiteSuperior)
                                {
                                    dgDatos.Rows[i].Cells[5].Style.ForeColor = Color.White;
                                    dgDatos.Rows[i].Cells[5].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if (tCurrent > cuLimiteInferior)
                                    {
                                        dgDatos.Rows[i].Cells[5].Style.ForeColor = Color.Black;
                                        dgDatos.Rows[i].Cells[5].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgDatos.Rows[i].Cells[5].Style.ForeColor = Color.White;
                                        dgDatos.Rows[i].Cells[5].Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }

                        if (dgDatos.Rows[i].Cells[6].Value != null)
                        {
                            if (Single.TryParse(dgDatos.Rows[i].Cells[6].Value.ToString(), out tCurrent))
                            {
                                tCurrent = Math.Abs(tCurrent);

                                if (tCurrent < LimiteInferior)
                                {
                                    dgDatos.Rows[i].Cells[6].Style.ForeColor = Color.White;
                                    dgDatos.Rows[i].Cells[6].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if (tCurrent < LimiteSuperior)
                                    {
                                        dgDatos.Rows[i].Cells[6].Style.ForeColor = Color.Black;
                                        dgDatos.Rows[i].Cells[6].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgDatos.Rows[i].Cells[6].Style.ForeColor = Color.White;
                                        dgDatos.Rows[i].Cells[6].Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }

                        if (dgDatos.Rows[i].Cells[7].Value != null)
                        {
                            if (Single.TryParse(dgDatos.Rows[i].Cells[7].Value.ToString(), out tCurrent))
                            {
                                tCurrent = Math.Abs(tCurrent);

                                if (tCurrent < LimiteInferior)
                                {
                                    dgDatos.Rows[i].Cells[7].Style.ForeColor = Color.White;
                                    dgDatos.Rows[i].Cells[7].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if (tCurrent < LimiteSuperior)
                                    {
                                        dgDatos.Rows[i].Cells[7].Style.ForeColor = Color.Black;
                                        dgDatos.Rows[i].Cells[7].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgDatos.Rows[i].Cells[7].Style.ForeColor = Color.White;
                                        dgDatos.Rows[i].Cells[7].Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.FailRegister("frmOpenEvaluacion - " + ex.Message);
                }
            }
        }

        private void frmOpenEvaluacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (onFormCerrado != null)
                this.onFormCerrado(this, EventArgs.Empty);
        }

        private void frmOpenEvaluacion_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgDatos.RowCount > 0)
            {
                currentEvaluacion = (EvaluacionGoteros)bsEvaluacionGoteros.Current;
                if (currentEvaluacion != null)
                {
                    if (currentEvaluacion.Status.Equals("En creacion"))
                    {
                        frmUpdateEvaluacion frm = new frmUpdateEvaluacion(currentEvaluacion);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            ActualizarDatos();
                        }
                        frm.Close();
                    }
                }
            }
        }

        private void bgwFiltro_DoWork(object sender, DoWorkEventArgs e)
        {
            listToCombo.Clear();
            var res = (from a in listEvaluacion
                       select a.Area).Distinct();
            if (res != null)
                foreach (var item in res)
                    listToCombo.Add(item.ToString());
        }

        private void bgwFiltro_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (listToCombo.Count > 0)
                foreach (var item in listToCombo)
                    cbArea.Items.Add(item);
        }

        private void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (dgDatos.RowCount > 0)
            {
                currentEvaluacion = (EvaluacionGoteros)bsEvaluacionGoteros.Current;
                if (currentEvaluacion != null)
                    if (currentEvaluacion.Status.Equals("Terminado"))
                        if (MessageBox.Show("¿Esta seguro de cambiar el estado del registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            if (EvaluacionGoterosBL.Instancia.UpdateStatus(currentEvaluacion))
                                ActualizarDatos();
                            else
                                MessageBox.Show("No se pudo actualizar el registro", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
