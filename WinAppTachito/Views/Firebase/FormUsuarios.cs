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
using WinAppTachito.Models.Firebase;

namespace WinAppTachito.Views.Firebase
{
    public partial class FormUsuarios : Form
    {
        List<KeyUsuarioFB> usuarios;
        readonly Database.Firebase.Usuario servicio;
        KeyUsuarioFB selectedRow;
        EstadoManttoDatos condicion;
        public FormUsuarios()
        {
            InitializeComponent();
            servicio = new Database.Firebase.Usuario();
        }
        private void FormUsuarios_Shown(object sender, EventArgs e)
        {
            condicion = EstadoManttoDatos.Ninguno;
            Actualizar();
        }
        public async void Actualizar()
        {
            await Task.Run(() =>
            {
                usuarios = servicio.GetAllUsuarios();
            });
            btnActualizar.Enabled = true;
            btnNuevo.Enabled = true;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnImprimir.Enabled = true;
            btnExportar.Enabled = true;
            dgvDatos.Enabled = true;
            bsDatos.DataSource = usuarios;
        }
        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            btnActualizar.Enabled = false;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnImprimir.Enabled = false;
            btnExportar.Enabled = false;
            dgvDatos.Enabled = false;
        }
        private void DgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            selectedRow = (KeyUsuarioFB)bsDatos.Current;
            CargarDatos();
        }
        private void CargarDatos()
        {
            if (selectedRow != null)
            {
                txtUsuario.Text = selectedRow.Usuario;
                txtClave.Text = selectedRow.Clave;
                txtNombres.Text = selectedRow.Nombres;
                txtCorreo.Text = selectedRow.Correo;
                txtCelular.Text = selectedRow.Celular;
                txtActivo.Checked = selectedRow.Estado;
            }
        }
        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            btnActualizar.Enabled = false;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnImprimir.Enabled = false;
            btnExportar.Enabled = false;
            dgvDatos.Enabled = false;
            Actualizar();
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (condicion == EstadoManttoDatos.Ninguno)
            {
                condicion = EstadoManttoDatos.Nuevo;
                btnNuevo.Text = "Guardar";
                btnModificar.Text = "Cancelar";
                btnActualizar.Enabled = false;
                btnEliminar.Enabled = false;
                btnImprimir.Enabled = false;
                btnExportar.Enabled = false;
                dgvDatos.Enabled = false;
                txtUsuario.ReadOnly = false;
                txtClave.ReadOnly = false;
                txtNombres.ReadOnly = false;
                txtCorreo.ReadOnly = false;
                txtCelular.ReadOnly = false;
                txtActivo.Enabled = true;
                txtUsuario.Text = "";
                txtClave.Text = "";
                txtNombres.Text = "";
                txtCorreo.Text = "";
                txtCelular.Text = "";
                txtActivo.Checked = true;
                txtUsuario.Focus();
            }
            else
            {
                if (Validar())
                {
                    KeyUsuarioFB row = new KeyUsuarioFB() {
                        Key = txtUsuario.Text,
                        Usuario = txtUsuario.Text,
                        Clave = txtClave.Text,
                        Nombres = txtNombres.Text,
                        Correo = txtCorreo.Text,
                        Celular = txtCelular.Text,
                        Estado = txtActivo.Checked,
                        Version = 0
                    };
                    btnNuevo.Enabled = false;
                    btnModificar.Enabled = false;
                    txtUsuario.ReadOnly = true;
                    txtClave.ReadOnly = true;
                    txtNombres.ReadOnly = true;
                    txtCorreo.ReadOnly = true;
                    txtCelular.ReadOnly = true;
                    txtActivo.Enabled = false;
                    if (condicion == EstadoManttoDatos.Nuevo)
                    {
                        row.Version = 1;
                        if (servicio.AddUsuario(row))
                        {
                            condicion = EstadoManttoDatos.Ninguno;
                            btnNuevo.Text = "NUEVO";
                            btnModificar.Text = "MODIFICAR";
                            txtUsuario.ReadOnly = true;
                            txtClave.ReadOnly = true;
                            txtNombres.ReadOnly = true;
                            txtCorreo.ReadOnly = true;
                            txtCelular.ReadOnly = true;
                            txtActivo.Enabled = false;
                            txtUsuario.Text = "";
                            txtClave.Text = "";
                            txtNombres.Text = "";
                            txtCorreo.Text = "";
                            txtCelular.Text = "";
                            txtActivo.Checked = true;
                            Actualizar();
                        }
                        else
                        {
                            btnNuevo.Enabled = true;
                            btnModificar.Enabled = true;
                            txtUsuario.ReadOnly = false;
                            txtClave.ReadOnly = false;
                            txtNombres.ReadOnly = false;
                            txtCorreo.ReadOnly = false;
                            txtCelular.ReadOnly = false;
                            txtActivo.Enabled = true;
                            MessageBox.Show("Ocurrió un error al intentar guardar el registro", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (condicion == EstadoManttoDatos.Editar)
                    {
                        row.Version = selectedRow.Clave.Equals(txtClave.Text) ? selectedRow.Version : selectedRow.Version + 1;
                        if (servicio.UpdateUsuario(row))
                        {
                            condicion = EstadoManttoDatos.Ninguno;
                            btnNuevo.Text = "NUEVO";
                            btnModificar.Text = "MODIFICAR";
                            txtUsuario.ReadOnly = true;
                            txtClave.ReadOnly = true;
                            txtNombres.ReadOnly = true;
                            txtCorreo.ReadOnly = true;
                            txtCelular.ReadOnly = true;
                            txtActivo.Enabled = false;
                            txtUsuario.Text = "";
                            txtClave.Text = "";
                            txtNombres.Text = "";
                            txtCorreo.Text = "";
                            txtCelular.Text = "";
                            txtActivo.Checked = true;
                            Actualizar();
                        }
                        else
                        {
                            btnNuevo.Enabled = true;
                            btnModificar.Enabled = true;
                            txtUsuario.ReadOnly = true;
                            txtClave.ReadOnly = false;
                            txtNombres.ReadOnly = false;
                            txtCorreo.ReadOnly = false;
                            txtCelular.ReadOnly = false;
                            txtActivo.Enabled = true;
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
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
                if (selectedRow != null)
                    if (condicion == EstadoManttoDatos.Ninguno)
                    {
                        condicion = EstadoManttoDatos.Editar;
                        btnNuevo.Text = "GUARDAR";
                        btnModificar.Text = "CANCELAR";
                        btnActualizar.Enabled = false;
                        btnEliminar.Enabled = false;
                        btnImprimir.Enabled = false;
                        btnExportar.Enabled = false;
                        dgvDatos.Enabled = false;
                        txtUsuario.ReadOnly = true;
                        txtClave.ReadOnly = false;
                        txtNombres.ReadOnly = false;
                        txtCorreo.ReadOnly = false;
                        txtCelular.ReadOnly = false;
                        txtActivo.Enabled = true;
                        txtNombres.Focus();
                    }
                    else
                    {
                        condicion = EstadoManttoDatos.Ninguno;
                        btnNuevo.Text = "NUEVO";
                        btnModificar.Text = "MODIFICAR";
                        txtUsuario.ReadOnly = true;
                        txtClave.ReadOnly = true;
                        txtNombres.ReadOnly = true;
                        txtCorreo.ReadOnly = true;
                        txtCelular.ReadOnly = true;
                        txtActivo.Enabled = false;
                        txtUsuario.Text = "";
                        txtClave.Text = "";
                        txtNombres.Text = "";
                        txtCorreo.Text = "";
                        txtCelular.Text = "";
                        txtActivo.Checked = true;
                        Actualizar();
                    }
        }
        private bool Validar()
        {
            if (txtUsuario.Text.Equals("") || txtClave.Text.Equals("") || txtNombres.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                if (MessageBox.Show("¿Esta seguro de eliminar registro?", "Aviso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnActualizar.Enabled = false;
                    btnNuevo.Enabled = false;
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnExportar.Enabled = false;
                    dgvDatos.Enabled = false;
                    if (servicio.DeleteUsuario(selectedRow.Key))
                        Actualizar();
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el registro", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnActualizar.Enabled = true;
                        btnNuevo.Enabled = true;
                        btnModificar.Enabled = true;
                        btnEliminar.Enabled = true;
                        btnImprimir.Enabled = true;
                        btnExportar.Enabled = true;
                        dgvDatos.Enabled = true;
                    }
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pathFile = saveFileDialog.FileName;
                SLDocument oSLDocument = new SLDocument();

                DataTable dt = new DataTable();
                dt.Columns.Add("Usuario", typeof(string));
                dt.Columns.Add("Nombres y Apellidos", typeof(string));
                dt.Columns.Add("Correo", typeof(string));
                dt.Columns.Add("Celular", typeof(string));
                dt.Columns.Add("Activo", typeof(bool));

                foreach (var item in usuarios)
                {
                    dt.Rows.Add(item.Usuario, item.Nombres, item.Correo, item.Celular, item.Estado);
                }

                oSLDocument.ImportDataTable(1, 1, dt, true);
                oSLDocument.SaveAs(pathFile);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printDocument = new System.Drawing.Printing.PrintDocument();
            System.Drawing.Printing.PrinterSettings ps = new System.Drawing.Printing.PrinterSettings();
            printDocument.PrinterSettings = ps;
            printDocument.PrintPage += delegate (object ev, System.Drawing.Printing.PrintPageEventArgs ep)
            {
                Font font = new Font("Arial", 14, FontStyle.Regular, GraphicsUnit.Point);
                int width = 200;
                int y = 20;
                ep.Graphics.DrawString("Usuarion App Tachito", font, Brushes.Black, new RectangleF(0, y += 20, width, 20));
                foreach (var item in usuarios)
                {
                    ep.Graphics.DrawString(item.Usuario, font, Brushes.Black, new RectangleF(0, y += 20, width, 20));
                }
            };
            printDocument.Print();
        }
        
    }
}
