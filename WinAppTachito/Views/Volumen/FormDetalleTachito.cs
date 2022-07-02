using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinAppTachito.Business;
using WinAppTachito.Models;

namespace WinAppTachito.Views.Volumen
{
    public partial class FormDetalleTachito : Form
    {
        public event EventHandler onFormCerrado;
        private EvaluacionVolumen currentParent;
        private List<DetalleEvaluacionVolumen> listDetalleEvaluacion = new List<DetalleEvaluacionVolumen>();
        private DetalleEvaluacionVolumen currentDetalleEvaluacion;
        private List<string> listIDs = new List<string>();
        public FormDetalleTachito(EvaluacionVolumen obj)
        {
            InitializeComponent();
            currentParent = obj;
        }

        private void FormDetalleTachito_Load(object sender, EventArgs e)
        {
            txtFecha.Text = currentParent.Fecha.ToShortDateString();
            txtArea.Text = currentParent.Lote;
            txtHectarea.Text = String.Format("{0:N2}", currentParent.Hectarea);
            txtCultivo.Text = currentParent.Cultivo;            
            txtEmision.Text = String.Format("{0:N2}", currentParent.Emision) + " l/h";
            txtTipoEvaluacion.Text = currentParent.TipoEvaluacion;
            pActualizar.Visible = false;
            if (/*!currentParent.Usuario.NombreUsuario.Equals(Log.UsuarioSistema.NombreUsuario) || */currentParent.Status.Equals("Terminado"))
            {
                btnActualizar.Enabled = false;
                btnGuardar.Enabled = false;
                btnTerminar.Enabled = false;
                dgvDatos.ReadOnly = true;
            }            
            ActualizarDatos();
        }

        private void FormDetalleTachito_FormClosed(object sender, FormClosedEventArgs e)
        {
            onFormCerrado?.Invoke(this, EventArgs.Empty);
        }

        private void FormDetalleTachito_Shown(object sender, EventArgs e)
        {            
            PaintGrid();
        }
        private void ActualizarDatos()
        {
            listDetalleEvaluacion = EvaluacionVolumenBL.Instancia.ListDetalle(currentParent);
            bsDatos.DataSource = listDetalleEvaluacion;
            if (currentParent.Status.Equals("Terminado"))
            {
                btnActualizar.Enabled = false;
                btnGuardar.Enabled = false;
                btnTerminar.Enabled = false;                
                dgvDatos.ReadOnly = true;
            }
            PaintGrid();
        }
        private void PaintGrid()
        {
            if (dgvDatos.RowCount > 0)
            {                
                try
                {
                    decimal limiteSuperior = 7;
                    decimal limiteInferior = -7;

                    decimal limiteSuperior2 = 10;
                    decimal limiteInferior2 = -10;

                    decimal tCurrent;
                    for (int i = 0; i < dgvDatos.RowCount; i++)
                    {
                        int colGrid = 12;
                        if (dgvDatos.Rows[i].Cells[colGrid].Value != null)
                        {
                            if (decimal.TryParse(dgvDatos.Rows[i].Cells[colGrid].Value.ToString(), out tCurrent))
                            {
                                if (tCurrent <= limiteSuperior && tCurrent >= limiteInferior)
                                {
                                    dgvDatos.Rows[i].Cells[colGrid].Style.ForeColor = Color.White;
                                    dgvDatos.Rows[i].Cells[colGrid].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if ((tCurrent >= limiteInferior2 && tCurrent < limiteInferior) || (tCurrent <= limiteSuperior2 && tCurrent > limiteSuperior))
                                    {
                                        dgvDatos.Rows[i].Cells[colGrid].Style.ForeColor = Color.Black;
                                        dgvDatos.Rows[i].Cells[colGrid].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgvDatos.Rows[i].Cells[colGrid].Style.ForeColor = Color.White;
                                        dgvDatos.Rows[i].Cells[colGrid].Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.FailRegister("frmDetailEvaluacionI - " + ex.Message);
                }
            }
        }

        private void DgvDatos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                MessageBox.Show("Dato ingresado incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dgvDatos.CurrentCell.ColumnIndex.Equals(5) || dgvDatos.CurrentCell.ColumnIndex.Equals(6) || dgvDatos.CurrentCell.ColumnIndex.Equals(7))
                {
                    dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells[dgvDatos.CurrentCell.ColumnIndex].Value = 0;
                }
                else
                {
                    dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells[dgvDatos.CurrentCell.ColumnIndex].Value = "";
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister("frmDatailEvaluacion - " + ex.Message);
            }
        }
        private void DgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            currentDetalleEvaluacion = (DetalleEvaluacionVolumen)bsDatos.Current;
        }
        private void DgvDatos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
            {
                AgregarListaIDs(dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells[4].Value.ToString());
                btnTerminar.Enabled = false;
                PaintGrid();
            }
        }
        private void AgregarListaIDs(string ID)
        {
            bool find = false;
            foreach (var item in listIDs)
            {
                if (item.Equals(ID))
                {
                    find = true;
                    break;
                }
            }
            if (!find)
                listIDs.Add(ID);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (EvaluacionVolumenBL.Instancia.UpdateDetalle(DevolverListaIDs()))
            {
                listIDs.Clear();
                btnTerminar.Enabled = true;
                EvaluacionVolumenBL.Instancia.UpdateResult(currentParent, listDetalleEvaluacion, false);                
                ActualizarDatos();
            }
        }
        private List<DetalleEvaluacionVolumen> DevolverListaIDs()
        {
            List<DetalleEvaluacionVolumen> oLista = new List<DetalleEvaluacionVolumen>();
            if (listIDs.Count > 0)
            {
                bool incluir;
                foreach (DetalleEvaluacionVolumen item in listDetalleEvaluacion)
                {
                    incluir = false;
                    foreach (var itemA in listIDs)
                    {
                        if (item.Id.ToString().Equals(itemA))
                        {
                            incluir = true;
                            break;
                        }
                    }
                    if (incluir)
                    {
                        //item.RefreshCoeficientes();
                        oLista.Add(item);
                    }
                }
            }
            return oLista;
        }

        private void BtnTerminar_Click(object sender, EventArgs e)
        {
            foreach (var item in listDetalleEvaluacion)
            {
                if (item.Variacion == null)
                    item.Incluir = false;
            }
            if (EvaluacionVolumenBL.Instancia.UpdateDetalle(listDetalleEvaluacion))
            {
                currentParent.Status = "Terminado";
                if (EvaluacionVolumenBL.Instancia.UpdateResult(currentParent, listDetalleEvaluacion, true))
                {                    
                    ActualizarDatos();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvDatos.Enabled = false;
            pActualizar.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvDatos.Enabled = true;
            pActualizar.Visible = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.RowCount > 0)
            {
                for (int i = 0; i < dgvDatos.RowCount; i++)
                {
                    if (chbPulsoProg.Checked)
                        dgvDatos.Rows[i].Cells[5].Value = (int)numPulsosProg.Value;
                    if (chbPulsoReal.Checked)
                        dgvDatos.Rows[i].Cells[6].Value = (int)numPulsosReal.Value;
                    if (chbTiempo.Checked)
                        dgvDatos.Rows[i].Cells[7].Value = (int)numTiempoPulso.Value;

                    AgregarListaIDs(dgvDatos.Rows[i].Cells[4].Value.ToString());

                }
                btnTerminar.Enabled = false;
                PaintGrid();
            }

            dgvDatos.Enabled = true;
            pActualizar.Visible = false;
        }

        private void chbPulsoProg_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPulsoProg.Checked)
            { 
                numPulsosProg.Enabled = true; 
            }
            else { 
                numPulsosProg.Enabled = false; 
            }
        }

        private void chbPulsoReal_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPulsoReal.Checked)
            {
                numPulsosReal.Enabled = true;
            }
            else
            {
                numPulsosReal.Enabled = false;
            }
        }

        private void chbTiempo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTiempo.Checked)
            {
                numTiempoPulso.Enabled = true;
            }
            else
            {
                numTiempoPulso.Enabled = false;
            }
        }
    }
}
