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
using WinAppTachito.Business;
using WinAppTachito.Models;

namespace WinAppTachito.Views.Volumen
{
    public partial class FormTachito : Form
    {
        List<EvaluacionVolumen> listaEvaluacion;
        EvaluacionVolumen currentEvaluacion = new EvaluacionVolumen();
        public FormTachito()
        {
            InitializeComponent();
            listaEvaluacion = new List<EvaluacionVolumen>();
        }

        private void FormTachito_Load(object sender, EventArgs e)
        {
            btnRecargar.Enabled = false;
            btnFiltrar.Enabled = false;
            btnDetalle.Enabled = false;
            btnImprimir.Enabled = false;
            btnExportar.Enabled = false;
            btnNuevo.Enabled = false;
            btnEstado.Enabled = false;
            btnEliminar.Enabled = false;            
            dgvDatos.Enabled = false;
            panFiltro.Visible = false;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            btnActualizar.Enabled = false;
            btnRecargar.Enabled = false;
            btnFiltrar.Enabled = false;
            btnDetalle.Enabled = false;
            btnImprimir.Enabled = false;
            btnExportar.Enabled = false;
            btnNuevo.Enabled = false;
            btnEstado.Enabled = false;
            btnEliminar.Enabled = false;
            panFiltro.Visible = false;
            dgvDatos.Enabled = false;
            //traer datos
            if (btnActualizar.Text.Equals("MOSTRAR"))
            {
                btnActualizar.Text = "CAMBIAR";
                dtpDesde.Enabled = false;
                cbArea.Text = "Todos";
                cbEstado.Text = "Todos";
                ActualizarDatos();
                btnRecargar.Enabled = true;
                btnFiltrar.Enabled = true;
                btnDetalle.Enabled = true;
                btnImprimir.Enabled = true;
                btnExportar.Enabled = true;
                btnNuevo.Enabled = true;
                btnEstado.Enabled = true;
                btnEliminar.Enabled = true;                
                dgvDatos.Enabled = true;
            }
            else
            {
                btnActualizar.Text = "MOSTRAR";
                dtpDesde.Enabled = true;
                btnRecargar.Enabled = false;
                btnFiltrar.Enabled = false;
                btnDetalle.Enabled = false;
                btnImprimir.Enabled = false;
                btnExportar.Enabled = false;
                btnNuevo.Enabled = false;
                btnEstado.Enabled = false;
                btnEliminar.Enabled = false;                
                dgvDatos.Enabled = false;
                bsDatos.DataSource = null;
                cbArea.Items.Clear();
                cbArea.Items.Add("Todos");
            }
            btnActualizar.Enabled = true;
        }

        private void ActualizarDatos()
        {            
            string tempArea = cbArea.Text;
            string temEstado = cbEstado.Text;
            listaEvaluacion = EvaluacionVolumenBL.Instancia.List(dtpDesde.Value, dtpDesde.Value, Log.UsuarioSistema);            

            cbArea.Items.Clear();
            cbArea.Items.Add("Todos");
            var res = (from a in listaEvaluacion
                       select a.Lote).Distinct();
            if (res != null)
                foreach (var item in res)
                    cbArea.Items.Add(item.ToString());

            FiltrarDatos(tempArea, temEstado);
        }
        private void FiltrarDatos(string area, string estado)
        {
            List<EvaluacionVolumen> listaFiltrada = new List<EvaluacionVolumen>();
            if (area.Equals("Todos") && estado.Equals("Todos"))
            {
                listaFiltrada = listaEvaluacion.ToList();
            }
            else
            {
                if (area.Equals("Todos"))
                {
                    var res = from a in listaEvaluacion
                              where a.Status.Equals(cbEstado.Text)
                              select a;
                    if (res != null)
                        listaFiltrada = res.ToList();
                }
                else
                {
                    if (estado.Equals("Todos"))
                    {
                        var res = from a in listaEvaluacion
                                  where a.Lote.Equals(cbArea.Text)
                                  select a;
                        if (res != null)
                            listaFiltrada = res.ToList();
                    }
                    else
                    {
                        var res = from a in listaEvaluacion
                                  where a.Lote.Equals(cbArea.Text) && a.Status.Equals(cbEstado.Text)
                                  select a;
                        if (res != null)
                            listaFiltrada = res.ToList();
                    }
                }
            }
            bsDatos.DataSource = listaFiltrada;
            PaintGrid();
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FormNuevo frm = new FormNuevo(dtpDesde.Value);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ActualizarDatos();
            }
            frm.Close();
        }

        private void BtnDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDatos.RowCount > 0)
            {
                MostrarDetalle();
            }
        }
        private void MostrarDetalle()
        {
            currentEvaluacion = (EvaluacionVolumen)bsDatos.Current;
            if (currentEvaluacion != null)
            {
                FormDetalleTachito frm = new FormDetalleTachito(currentEvaluacion);
                frm.onFormCerrado += new EventHandler(Frm_onFormCerrado);
                if (this.MdiParent != null)
                    frm.MdiParent = this.MdiParent;
                this.Hide();
                frm.Show();
                if(this.WindowState==FormWindowState.Maximized)
                    frm.WindowState = FormWindowState.Maximized;
            }
        }
        void Frm_onFormCerrado(object sender, EventArgs e)
        {
            Show();
            ActualizarDatos();
        }
        private void DgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            CargarDato();
        }
        private void CargarDato()
        {
            if (dgvDatos.RowCount > 0)
                currentEvaluacion = (EvaluacionVolumen)bsDatos.Current;
        }        
        private void DgvDatos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvDatos.RowCount > 0)
            {
                MostrarDetalle();
            }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.RowCount > 0)
            {
                currentEvaluacion = (EvaluacionVolumen)bsDatos.Current;
                if (currentEvaluacion != null)
                    //if (currentEvaluacion.Status.Equals("En creacion")/* && currentEvaluacion.Usuario.NombreUsuario.Equals(Log.UsuarioSistema.NombreUsuario)*/)
                        if (MessageBox.Show("¿Esta seguro de eliminar registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            if (EvaluacionVolumenBL.Instancia.Delete(currentEvaluacion))
                                ActualizarDatos();
                            else
                                MessageBox.Show("No se pudo eliminar el registro", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnEstado_Click(object sender, EventArgs e)
        {
            if (dgvDatos.RowCount > 0)
            {
                currentEvaluacion = (EvaluacionVolumen)bsDatos.Current;                
                if (currentEvaluacion != null)
                {
                    FormEditar frm = new FormEditar(currentEvaluacion);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        ActualizarDatos();
                    }
                    frm.Close();
                }
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            ActualizarDatos();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if(panFiltro.Visible)
                panFiltro.Visible = false;
            else
                panFiltro.Visible = true;
        }

        private void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarDatos(cbArea.Text, cbEstado.Text);
        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarDatos(cbArea.Text, cbEstado.Text);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pathFile = saveFileDialog.FileName;
                SLDocument oSLDocument = new SLDocument();

                DataTable dt = new DataTable();
                dt.Columns.Add("Fecha Evaluacion", typeof(DateTime));
                dt.Columns.Add("Lote", typeof(string));
                dt.Columns.Add("Cultivo", typeof(string));
                dt.Columns.Add("Deficit", typeof(int));
                dt.Columns.Add("Optimo", typeof(int));
                dt.Columns.Add("Exceso", typeof(int));
                dt.Columns.Add("Estado", typeof(string));

                foreach (var item in listaEvaluacion)
                {
                    dt.Rows.Add(item.Fecha, item.Lote, item.Cultivo, item.NroDeficit, item.NroOptimo, item.NroExceso, item.Status);
                }

                oSLDocument.ImportDataTable(1, 1, dt, true);
                oSLDocument.SaveAs(pathFile);
            }
        }
        private void PaintGrid()
        {
            if (dgvDatos.RowCount > 0)
            {
                try
                {                    
                    for (int i = 0; i < dgvDatos.RowCount; i++)
                    {
                        int colGrid = 12;
                        if (dgvDatos.Rows[i].Cells[colGrid].Value != null)
                        {
                            if (dgvDatos.Rows[i].Cells[colGrid].Value.ToString().Equals("En creacion"))
                            {                                
                                dgvDatos.Rows[i].Cells[colGrid].Style.BackColor = Color.Yellow;
                            }
                            else
                            {                               
                                dgvDatos.Rows[i].Cells[colGrid].Style.BackColor = Color.White;
                            }                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.FailRegister("FormTachito - " + ex.Message);
                }
            }
        }
    }
}
