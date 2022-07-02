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

namespace WinEEGO.Views.Mantto
{
    public partial class frmAreaGeneral : Form
    {
        public event EventHandler onFormCerrado;
        private List<AreaGeneral> listReal = new List<AreaGeneral>();
        private AreaGeneral listMeta = new AreaGeneral();
        private bool isNew = false;
        private bool isEdit = false;
        public frmAreaGeneral()
        {
            InitializeComponent();
        }

        private void frmAreaGeneral_Load(object sender, EventArgs e)
        {
            txtCodigo.ReadOnly = true;
            txtCodigo.BackColor = Color.Ivory;
            txtArea.ReadOnly = true;
            txtArea.BackColor = Color.Ivory;            
            txtHectarea.ReadOnly = true;
            txtHectarea.BackColor = Color.Ivory;
            cbCultivo.Enabled = false;
            cbCultivo.BackColor = Color.Ivory;
            dgDatos.Enabled = true;

            CargarCultivo();            

            ActualizarDatos();
        }

        private void frmAreaGeneral_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (onFormCerrado != null)
                onFormCerrado(this, EventArgs.Empty);
        }
        private void CargarCultivo()
        {
            List<Cultivo> listaCultivo;
            listaCultivo = CultivoBL.Instancia.List();
            cbCultivo.DataSource = listaCultivo;
            cbCultivo.DisplayMember = "NombreCultivo";
            cbCultivo.ValueMember = "NombreCultivo";
        }
        private void ActualizarDatos()
        {
            listReal = AreaGeneralBL.Instancia.List();
            bsAreaGeneral.DataSource = listReal;
            CargarDato();
        }
        private void CargarDato()
        {
            if (dgDatos.RowCount > 0)
            {
                listMeta = (AreaGeneral)bsAreaGeneral.Current;

                txtCodigo.Text = listMeta.Codigo;
                txtArea.Text = listMeta.Area;                
                txtHectarea.Text = listMeta.Hectarea.ToString();
                cbCultivo.Text = listMeta.Cultivo;
            }
            else
            {
                txtCodigo.Text = "";
                txtArea.Text = "";               
                txtHectarea.Text = "";
                cbCultivo.Text = "";
            }
        }

        private void dgDatos_SelectionChanged(object sender, EventArgs e)
        {
            CargarDato();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (btnInsertar.Text.Equals("Nuevo"))
            {
                btnInsertar.Text = "Guardar";
                btnEditar.Text = "Cancelar";
                txtCodigo.ReadOnly = false;
                txtCodigo.BackColor = Color.White;
                txtArea.ReadOnly = false;
                txtArea.BackColor = Color.White;                
                //txtHectarea.ReadOnly = false;
                //txtHectarea.BackColor = Color.White;
                cbCultivo.Enabled = true;
                cbCultivo.BackColor = Color.White;
                dgDatos.Enabled = false;
                txtCodigo.Text = "";
                txtArea.Text = "";                
                txtHectarea.Text = "";
                cbCultivo.Text = "";
                txtCodigo.Focus();
                isNew = true;
                isEdit = false;
                btnEliminar.Enabled = false;
                btnValvulas.Enabled = false;
            }
            else
            {
                if (Validar())
                {
                    AreaGeneral _theRow = new AreaGeneral();
                    _theRow.Codigo = txtCodigo.Text;
                    _theRow.Area = txtArea.Text;                    
                    if (!txtHectarea.Text.Equals(""))
                        _theRow.Hectarea = Convert.ToDecimal(txtHectarea.Text);
                    _theRow.Cultivo = cbCultivo.Text;

                    if (isNew)
                    {
                        if (AreaGeneralBL.Instancia.Insert(_theRow))
                        {
                            ActualizarDatos();
                            btnInsertar.Text = "Nuevo";
                            btnEditar.Text = "Editar";
                            txtArea.ReadOnly = true;
                            txtArea.BackColor = Color.Ivory;                            
                            //txtHectarea.ReadOnly = true;
                            //txtHectarea.BackColor = Color.Ivory;
                            cbCultivo.Enabled = false;
                            cbCultivo.BackColor = Color.Ivory;
                            dgDatos.Enabled = true;
                            btnEliminar.Enabled = true;
                            btnValvulas.Enabled = true;
                            isNew = false;
                            isEdit = false;
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al intentar guardar el registro", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (isEdit)
                    {
                        if (AreaGeneralBL.Instancia.Update(_theRow))
                        {
                            ActualizarDatos();
                            btnInsertar.Text = "Nuevo";
                            btnEditar.Text = "Editar";
                            txtArea.ReadOnly = true;
                            txtArea.BackColor = Color.Ivory;                            
                            //txtHectarea.ReadOnly = true;
                            //txtHectarea.BackColor = Color.Ivory;
                            cbCultivo.Enabled = false;
                            cbCultivo.BackColor = Color.Ivory;
                            dgDatos.Enabled = true;
                            btnEliminar.Enabled = true;
                            btnValvulas.Enabled = true;
                            isNew = false;
                            isEdit = false;
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al intentar actualizar el registro", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Verifique que sea correcto los datos ingresados", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (btnEditar.Text.Equals("Editar"))
            {
                btnInsertar.Text = "Guardar";
                btnEditar.Text = "Cancelar";
                txtCodigo.ReadOnly = true;
                txtCodigo.BackColor = Color.Ivory;
                txtArea.ReadOnly = false;
                txtArea.BackColor = Color.White;                
                cbCultivo.Enabled = true;
                cbCultivo.BackColor = Color.White;
                dgDatos.Enabled = false;
                txtArea.Focus();
                isNew = false;
                isEdit = true;
                btnEliminar.Enabled = false;
                btnValvulas.Enabled = false;
            }
            else
            {
                btnInsertar.Text = "Nuevo";
                btnEditar.Text = "Editar";
                txtCodigo.ReadOnly = true;
                txtCodigo.BackColor = Color.Ivory;
                txtArea.ReadOnly = true;
                txtArea.BackColor = Color.Ivory;                
                cbCultivo.Enabled = false;
                cbCultivo.BackColor = Color.Ivory;
                dgDatos.Enabled = true;
                isNew = false;
                isEdit = false;
                btnEliminar.Enabled = true;
                btnValvulas.Enabled = true;
                CargarDato();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgDatos.RowCount > 0)
            {
                listMeta = (AreaGeneral)bsAreaGeneral.Current;
                if (listMeta != null)
                {
                    if (MessageBox.Show("¿Esta seguro de eliminar registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        if (AreaGeneralBL.Instancia.Delete(listMeta))
                            ActualizarDatos();
                        else
                            MessageBox.Show("Ocurrió un error al intentar eliminar el registro", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool Validar()
        {
            if (txtCodigo.Text.Equals(""))
            {
                txtCodigo.Focus();
                return false;
            }
            else
            {
                if (txtArea.Text.Equals(""))
                {
                    txtArea.Focus();
                    return false;
                }
                else
                {
                    if (!(cbCultivo.SelectedIndex >= 0))
                    {
                        cbCultivo.Focus();
                        return false;
                    }
                    else
                    {
                        if (txtHectarea.Text.Equals(""))
                        {
                            return true;
                        }
                        else
                        {
                            decimal num;
                            if (!decimal.TryParse(txtHectarea.Text, out num))
                            {
                                txtHectarea.Focus();
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                }
            }
        }

        private void btnValvulas_Click(object sender, EventArgs e)
        {
            if (dgDatos.RowCount > 0)
            {
                listMeta = (AreaGeneral)bsAreaGeneral.Current;
                frmValvulaCampo frm = new frmValvulaCampo(listMeta);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.AreaGeneralSel.Hectarea.HasValue)
                    {
                        listMeta.Hectarea = frm.AreaGeneralSel.Hectarea;
                        dgDatos.Refresh();
                        txtHectarea.Text = listMeta.Hectarea.ToString();
                    }
                }
            }
        }
    }
}
