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
    public partial class frmUsuarios : Form
    {
        private Usuario currentUser;
        private bool isNew = false;
        private bool isEdit = false;

        public event EventHandler FormularioCerrado;
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            txtCodigo.ReadOnly = true;
            txtCodigo.BackColor = Color.Ivory;
            txtApeNom.ReadOnly = true;
            txtApeNom.BackColor = Color.Ivory;
            cbNivelAccesoEGO.Enabled = false;            
            cbPerteneceA.Enabled = false;
            dgDatos.Enabled = true;

            CargarAcceso();
            CargarDepartamento();
            Actualizar();
        }
        private void frmUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            onFormularioCerrado();
        }
        private void onFormularioCerrado()
        {
            if (FormularioCerrado != null)
            {
                FormularioCerrado(this, EventArgs.Empty);
            }
        }
        private void CargarAcceso()
        {
            cbNivelAccesoEGO.DataSource = Enum.GetValues(typeof(TipoUsuario));            
        }
        private void CargarDepartamento()
        {
            List<Departamento> listaDep;
            listaDep = DepartamentoBL.Instancia.List();            
            cbPerteneceA.DataSource = listaDep;
            cbPerteneceA.DisplayMember = "NombreDepartamento";
            cbPerteneceA.ValueMember = "Id";
        }
        private void Actualizar()
        {
            bsUsuario.DataSource = UsuarioBL.Instancia.List();
        }
        private void dgDatos_SelectionChanged(object sender, EventArgs e)
        {
            currentUser = (Usuario)bsUsuario.Current;
            CargarDatos();
        }
        private void CargarDatos()
        {
            if (currentUser != null)
            {
                txtCodigo.Text = currentUser.NombreUsuario;
                cbNivelAccesoEGO.Text = currentUser.AccesoEGO.ToString();                
                cbPerteneceA.Text = currentUser.PerteneceA.NombreDepartamento;
                txtApeNom.Text = currentUser.ApeNom;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Equals("Admin"))
            {
                MessageBox.Show("No se debe eliminar el Usuario 'Admin'");
            }
            else
            {
                if (currentUser != null)
                {
                    if (MessageBox.Show("¿Esta seguro de eliminar registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        if (UsuarioBL.Instancia.Delete(currentUser))
                            Actualizar();
                        else
                            MessageBox.Show("No se pudo eliminar el registro", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (btnInsertar.Text.Equals("Nuevo"))
            {
                btnInsertar.Text = "Guardar";
                btnEditar.Text = "Cancelar";

                txtCodigo.ReadOnly = false;
                txtCodigo.BackColor = Color.White;
                txtApeNom.ReadOnly = false;
                txtApeNom.BackColor = Color.White;
                cbNivelAccesoEGO.Enabled = true;
                cbPerteneceA.Enabled = true;
                dgDatos.Enabled = false;

                txtCodigo.Text = "";
                txtApeNom.Text = "";
                cbPerteneceA.SelectedIndex = 0;
                cbNivelAccesoEGO.SelectedIndex = 0;                

                txtCodigo.Focus();

                isNew = true;
                isEdit = false;
                btnEliminar.Enabled = false;
            }
            else
            {
                if (Validar())
                {
                    Usuario _theRow = new Usuario
                    {
                        NombreUsuario = txtCodigo.Text,
                        Password = "",
                        ApeNom = txtApeNom.Text,
                        PerteneceA = new Departamento()
                        {
                            Id = (Int32)cbPerteneceA.SelectedValue,
                            NombreDepartamento = cbPerteneceA.SelectedText
                        },
                        AccesoEGO = (TipoUsuario)cbNivelAccesoEGO.SelectedItem
                    };

                    if (isNew)
                    {
                        if (UsuarioBL.Instancia.Insert(_theRow))
                        {
                            Actualizar();
                            btnInsertar.Text = "Nuevo";
                            btnEditar.Text = "Editar";
                            txtCodigo.ReadOnly = true;
                            txtCodigo.BackColor = Color.Ivory;
                            txtApeNom.ReadOnly = true;
                            txtApeNom.BackColor = Color.Ivory;
                            cbNivelAccesoEGO.Enabled = false;                            
                            cbPerteneceA.Enabled = false;
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
                        _theRow.NombreUsuario = currentUser.NombreUsuario;
                        if (UsuarioBL.Instancia.Update(_theRow))
                        {
                            Actualizar();
                            btnInsertar.Text = "Nuevo";
                            btnEditar.Text = "Editar";
                            txtCodigo.ReadOnly = true;
                            txtCodigo.BackColor = Color.Ivory;
                            txtApeNom.ReadOnly = true;
                            txtApeNom.BackColor = Color.Ivory;
                            cbNivelAccesoEGO.Enabled = false;                            
                            cbPerteneceA.Enabled = false;
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

                txtCodigo.ReadOnly = true;
                txtCodigo.BackColor = Color.Ivory;
                txtApeNom.ReadOnly = false;
                txtApeNom.BackColor = Color.White;
                cbNivelAccesoEGO.Enabled = true;                
                cbPerteneceA.Enabled = true;
                dgDatos.Enabled = false;

                txtApeNom.Focus();

                isNew = false;
                isEdit = true;

                btnEliminar.Enabled = false;
            }
            else
            {
                btnInsertar.Text = "Nuevo";
                btnEditar.Text = "Editar";

                txtCodigo.ReadOnly = true;
                txtCodigo.BackColor = Color.Ivory;
                txtApeNom.ReadOnly = true;
                txtApeNom.BackColor = Color.Ivory;
                cbNivelAccesoEGO.Enabled = false;                
                cbPerteneceA.Enabled = false;
                dgDatos.Enabled = true;

                isNew = false;
                isEdit = false;

                btnEliminar.Enabled = true;

                CargarDatos();
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
                if (!(cbNivelAccesoEGO.SelectedIndex >= 0))
                {
                    cbNivelAccesoEGO.Focus();
                    return false;
                }
                else
                {
                    if (!(cbPerteneceA.SelectedIndex >= 0))
                    {
                        cbPerteneceA.Focus();
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
