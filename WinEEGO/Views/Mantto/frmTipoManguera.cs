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
    public partial class frmTipoManguera : Form
    {
        public event EventHandler onFormCerrado;
        List<TipoManguera> listReal = new List<TipoManguera>();
        TipoManguera currentTipoManguera = new TipoManguera();

        Boolean isNew = false;
        Boolean isEdit = false;
        public frmTipoManguera()
        {
            InitializeComponent();
        }

        private void frmTipoManguera_Load(object sender, EventArgs e)
        {
            txtNombre.ReadOnly = true;
            txtNombre.BackColor = Color.Ivory;
            txtEmision.ReadOnly = true;
            txtEmision.BackColor = Color.Ivory;
            txtEmisionPermisible.ReadOnly = true;
            txtEmisionPermisible.BackColor = Color.Ivory;
            txtEmisionSobrePermisible.ReadOnly = true;
            txtEmisionSobrePermisible.BackColor = Color.Ivory;
            ActualizarDatos();
        }
        private void ActualizarDatos()
        {
            listReal = TipoMangueraBL.Instancia.List();
            bsTipoManguera.DataSource = listReal;
        }
        private void frmTipoManguera_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (onFormCerrado != null)
                this.onFormCerrado(this, EventArgs.Empty);
        }
        private void dgDatos_SelectionChanged(object sender, EventArgs e)
        {
            CargarDato();
        }
        private void CargarDato()
        {
            if (dgDatos.RowCount > 0)
            {
                currentTipoManguera = (TipoManguera)bsTipoManguera.Current;

                txtNombre.Text = currentTipoManguera.Nombre;                
                txtEmision.Text = string.Format("{0:N2}", currentTipoManguera.Emision);
                txtEmisionPermisible.Text = string.Format("{0:N4}", currentTipoManguera.EmisionPermisible);
                txtEmisionSobrePermisible.Text = string.Format("{0:N4}", currentTipoManguera.EmisionSobrePermisible);
            }
            else
            {
                txtNombre.Text = "";                
                txtEmision.Text = "";
                txtEmisionPermisible.Text = "";
                txtEmisionSobrePermisible.Text = "";
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (btnInsertar.Text.Equals("Nuevo"))
            {
                btnInsertar.Text = "Guardar";
                btnEditar.Text = "Cancelar";

                txtNombre.ReadOnly = false;
                txtNombre.BackColor = Color.White;                
                txtEmision.ReadOnly = false;
                txtEmision.BackColor = Color.White;
                txtEmisionPermisible.ReadOnly = true;
                txtEmisionPermisible.BackColor = Color.Ivory;
                txtEmisionSobrePermisible.ReadOnly = true;
                txtEmisionSobrePermisible.BackColor = Color.Ivory;
                dgDatos.Enabled = false;

                txtNombre.Text = "";                
                txtEmision.Text = "";
                txtEmisionPermisible.Text = "";
                txtEmisionSobrePermisible.Text = "";

                txtNombre.Focus();

                isNew = true;
                isEdit = false;
                btnEliminar.Enabled = false;
            }
            else
            {
                if (Validar())
                {
                    TipoManguera _theRow = new TipoManguera();
                    _theRow.Nombre = txtNombre.Text;                    
                    if (!txtEmision.Text.Equals(""))
                        _theRow.Emision = decimal.Parse(txtEmision.Text);
                    if (!txtEmisionPermisible.Text.Equals(""))
                        _theRow.EmisionPermisible = decimal.Parse(txtEmisionPermisible.Text);
                    if (!txtEmisionSobrePermisible.Text.Equals(""))
                        _theRow.EmisionSobrePermisible = decimal.Parse(txtEmisionSobrePermisible.Text);


                    if (isNew)
                    {
                        if (TipoMangueraBL.Instancia.Insert(_theRow))
                        {
                            ActualizarDatos();
                            btnInsertar.Text = "Nuevo";
                            btnEditar.Text = "Editar";

                            txtNombre.ReadOnly = true;
                            txtNombre.BackColor = Color.Ivory;                            
                            txtEmision.ReadOnly = true;
                            txtEmision.BackColor = Color.Ivory;
                            txtEmisionPermisible.ReadOnly = true;
                            txtEmisionPermisible.BackColor = Color.Ivory;
                            txtEmisionSobrePermisible.ReadOnly = true;
                            txtEmisionSobrePermisible.BackColor = Color.Ivory;
                            dgDatos.Enabled = true;
                            btnEliminar.Enabled = true;
                            isNew = false;
                            isEdit = false;
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al intentar guardar el registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (isEdit)
                    {
                        _theRow.Id = currentTipoManguera.Id;
                        if (TipoMangueraBL.Instancia.Update(_theRow))
                        {
                            ActualizarDatos();
                            btnInsertar.Text = "Nuevo";
                            btnEditar.Text = "Editar";
                            txtNombre.ReadOnly = true;
                            txtNombre.BackColor = Color.Ivory;                            
                            txtEmision.ReadOnly = true;
                            txtEmision.BackColor = Color.Ivory;
                            txtEmisionPermisible.ReadOnly = true;
                            txtEmisionPermisible.BackColor = Color.Ivory;
                            txtEmisionSobrePermisible.ReadOnly = true;
                            txtEmisionSobrePermisible.BackColor = Color.Ivory;
                            dgDatos.Enabled = true;
                            btnEliminar.Enabled = true;
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

                txtNombre.ReadOnly = true;
                txtNombre.BackColor = Color.Ivory;                
                txtEmision.ReadOnly = false;
                txtEmision.BackColor = Color.White;
                txtEmisionPermisible.ReadOnly = false;
                txtEmisionPermisible.BackColor = Color.White;
                txtEmisionSobrePermisible.ReadOnly = false;
                txtEmisionSobrePermisible.BackColor = Color.White;
                dgDatos.Enabled = false;

                txtEmision.Focus();

                isNew = false;
                isEdit = true;

                btnEliminar.Enabled = false;
            }
            else
            {
                btnInsertar.Text = "Nuevo";
                btnEditar.Text = "Editar";

                txtNombre.ReadOnly = true;
                txtNombre.BackColor = Color.Ivory;                
                txtEmision.ReadOnly = true;
                txtEmision.BackColor = Color.Ivory;
                txtEmisionPermisible.ReadOnly = true;
                txtEmisionPermisible.BackColor = Color.Ivory;
                txtEmisionSobrePermisible.ReadOnly = true;
                txtEmisionSobrePermisible.BackColor = Color.Ivory;
                dgDatos.Enabled = true;

                isNew = false;
                isEdit = false;

                btnEliminar.Enabled = true;

                CargarDato();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgDatos.RowCount > 0)
            {
                currentTipoManguera = (TipoManguera)bsTipoManguera.Current;
                if (currentTipoManguera != null)
                    if (MessageBox.Show("¿Esta seguro de eliminar registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        if (TipoMangueraBL.Instancia.Delete(currentTipoManguera))
                            ActualizarDatos();
                        else
                            MessageBox.Show("Ocurrió un error al intentar eliminar el registro", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool Validar()
        {
            if (txtNombre.Text.Equals(""))
            {
                txtNombre.Focus();
                return false;
            }
            else
            {
                float cA;

                if (!float.TryParse(txtEmision.Text, out cA))
                {
                    txtEmision.Focus();
                    return false;
                }
                else
                {
                    txtEmisionPermisible.Text = string.Format("{0:N4}", Convert.ToSingle(txtEmision.Text) * (1 - 0.07));
                    txtEmisionSobrePermisible.Text = string.Format("{0:N4}", Convert.ToSingle(txtEmision.Text) * (1 + 0.07));

                    if (!txtEmisionPermisible.Text.Equals("") && !float.TryParse(txtEmisionPermisible.Text, out cA))
                    {
                        txtEmisionPermisible.Focus();
                        return false;
                    }
                    else
                    {
                        if (!txtEmisionSobrePermisible.Text.Equals("") && !float.TryParse(txtEmisionSobrePermisible.Text, out cA))
                        {
                            txtEmisionSobrePermisible.Focus();
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
}
