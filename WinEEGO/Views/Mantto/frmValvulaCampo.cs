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
    public partial class frmValvulaCampo : Form
    {
        List<ValvulaCampo> listValvulas = new List<ValvulaCampo>();
        ValvulaCampo currentValvula = new ValvulaCampo();
        bool isNew = false;
        bool isEdit = false;
        public frmValvulaCampo(AreaGeneral oArea)
        {
            InitializeComponent();
            AreaGeneralSel = oArea;
        }
        public AreaGeneral AreaGeneralSel { get; set; }
        private void frmValvulaCampo_Load(object sender, EventArgs e)
        {
            txtValvula.ReadOnly = true;
            txtValvula.BackColor = Color.Ivory;            
            txtHectarea.ReadOnly = true;
            txtHectarea.BackColor = Color.Ivory;
            txtOrden.Enabled = false;
            txtOrden.BackColor = Color.Ivory;            
            txtEstado.Enabled = false;
            txtEstado.BackColor = Color.Ivory;
            dgDatos.Enabled = true;
            ActualizarDatos();
            lbTotal.Text = "Total Ha: " + (AreaGeneralSel.Hectarea == null ? "0" : ((decimal)AreaGeneralSel.Hectarea).ToString("N2"));
        }
        private void ActualizarDatos()
        {
            listValvulas = ValvulaCampoBL.Instancia.List(AreaGeneralSel);
            bsValvulaCampo.DataSource = listValvulas;
            //Ordena();

            CargarDato();

        }
        private void CargarDato()
        {
            if (dgDatos.RowCount > 0)
            {
                currentValvula = (ValvulaCampo)bsValvulaCampo.Current;

                txtValvula.Text = currentValvula.Nombre;                
                txtHectarea.Text = currentValvula.Hectarea.ToString();
                txtOrden.Value = currentValvula.Orden;                
                if (currentValvula.Estado == true)
                    txtEstado.Value = 1;
                else
                    txtEstado.Value = 0;
            }
            else
            {
                txtValvula.Text = "";                
                txtHectarea.Text = "";
                txtOrden.Value = 0;                
                txtEstado.Value = 0;
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

                txtValvula.ReadOnly = false;
                txtValvula.BackColor = Color.White;                
                txtHectarea.ReadOnly = false;
                txtHectarea.BackColor = Color.White;
                txtOrden.Enabled = true;
                txtOrden.BackColor = Color.White;                
                txtEstado.Enabled = true;
                txtEstado.BackColor = Color.White;
                dgDatos.Enabled = false;
                txtValvula.Text = "";                
                txtHectarea.Text = "";
                txtOrden.Value = 0;                
                txtValvula.Focus();
                btnEliminar.Enabled = false;

                isNew = true;
                isEdit = false;
            }
            else
            {
                if (Validar())
                {
                    ValvulaCampo _theRow = new ValvulaCampo();
                    _theRow.Nombre = txtValvula.Text;                    

                    if (!txtHectarea.Text.Equals(""))
                        _theRow.Hectarea = Convert.ToDecimal(txtHectarea.Text);

                    _theRow.Orden = (int)txtOrden.Value;                    

                    if (txtEstado.Value == 1)
                        _theRow.Estado = true;
                    else
                        _theRow.Estado = false;

                    _theRow.Id_Parent = AreaGeneralSel.Codigo;

                    if (isNew)
                    {
                        if (ValvulaCampoBL.Instancia.Insert(_theRow))
                        {
                            btnInsertar.Text = "Nuevo";
                            btnEditar.Text = "Editar";
                            txtValvula.ReadOnly = true;
                            txtValvula.BackColor = Color.Ivory;                            
                            txtHectarea.ReadOnly = true;
                            txtHectarea.BackColor = Color.Ivory;
                            txtOrden.Enabled = false;
                            txtOrden.BackColor = Color.Ivory;                            
                            txtEstado.Enabled = false;
                            txtEstado.BackColor = Color.Ivory;
                            dgDatos.Enabled = true;

                            btnEliminar.Enabled = true;

                            isNew = false;
                            isEdit = false;
                            ActualizarDatos();
                            ActualizarPadre();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al intentar guardar el registro", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (isEdit)
                    {
                        _theRow.Id = currentValvula.Id;
                        if (ValvulaCampoBL.Instancia.Update(_theRow))
                        {
                            btnInsertar.Text = "Nuevo";
                            btnEditar.Text = "Editar";

                            txtValvula.ReadOnly = true;
                            txtValvula.BackColor = Color.Ivory;                            
                            txtHectarea.ReadOnly = true;
                            txtHectarea.BackColor = Color.Ivory;
                            txtOrden.Enabled = false;
                            txtOrden.BackColor = Color.Ivory;                            
                            txtEstado.Enabled = false;
                            txtEstado.BackColor = Color.Ivory;
                            dgDatos.Enabled = true;

                            btnEliminar.Enabled = true;

                            isNew = false;
                            isEdit = false;
                            ActualizarDatos();
                            ActualizarPadre();
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

                txtValvula.ReadOnly = true;
                txtValvula.BackColor = Color.Ivory;                
                txtHectarea.ReadOnly = false;
                txtHectarea.BackColor = Color.White;
                txtOrden.Enabled = true;
                txtOrden.BackColor = Color.White;                
                txtEstado.Enabled = true;
                txtEstado.BackColor = Color.White;
                dgDatos.Enabled = false;

                isNew = false;
                isEdit = true;
                txtHectarea.Focus();
            }
            else
            {
                btnInsertar.Text = "Nuevo";
                btnEditar.Text = "Editar";

                txtValvula.ReadOnly = true;
                txtValvula.BackColor = Color.Ivory;                
                txtHectarea.ReadOnly = true;
                txtHectarea.BackColor = Color.Ivory;
                txtOrden.Enabled = false;
                txtOrden.BackColor = Color.Ivory;                
                txtEstado.Enabled = false;
                txtEstado.BackColor = Color.Ivory;
                dgDatos.Enabled = true;
                isNew = false;
                isEdit = false;
                CargarDato();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgDatos.RowCount > 0)
            {
                currentValvula = (ValvulaCampo)bsValvulaCampo.Current;
                if (currentValvula != null)
                    if (MessageBox.Show("¿Esta seguro de eliminar registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        if (ValvulaCampoBL.Instancia.Delete(currentValvula))
                        {
                            ActualizarDatos();
                            ActualizarPadre();
                        }

                        else
                            MessageBox.Show("Ocurrió un error al intentar eliminar el registro", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool Validar()
        {
            if (txtValvula.Text.Equals(""))
            {
                txtValvula.Focus();
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
                    if (!decimal.TryParse(txtHectarea.Text, out _))
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
        private void ActualizarPadre()
        {
            decimal sumArea = 0;
            lbTotal.Text = "Total Ha: 0";
            if (listValvulas != null)
            {
                foreach (var item in listValvulas)
                {
                    if (item.Hectarea.HasValue && item.Estado == true)
                    {
                        sumArea = sumArea + (decimal)item.Hectarea;
                    }
                }
            }

            if (AreaGeneralSel != null)
            {
                AreaGeneralSel.Hectarea = sumArea;
                AreaGeneralBL.Instancia.Update(AreaGeneralSel);
                lbTotal.Text = "Total Ha: " + sumArea.ToString("N2");
            }
        }

        private void frmValvulaCampo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
