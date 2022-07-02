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

namespace WinEEGO.Views.User
{
    public partial class frmCambiarClave : Form
    {
        public frmCambiarClave()
        {
            InitializeComponent();
        }

        private void frmCambiarClave_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.Compare(txtNuevaClaveI.Text, txtNuevaClaveII.Text, false) == 0)
            {
                Usuario res = UsuarioBL.Instancia.Login(
                new Usuario()
                {
                    NombreUsuario = Log.UsuarioSistema == null ? "" : Log.UsuarioSistema.NombreUsuario,
                    Password = txtClaveActual.Text
                });
                if (res != null)
                {
                    if (UsuarioBL.Instancia.UpdatePass(new Usuario()
                    {
                        NombreUsuario = Log.UsuarioSistema == null ? "" : Log.UsuarioSistema.NombreUsuario,
                        Password = txtNuevaClaveI.Text
                    }))
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("No se cambiar la clave", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Clave actual incorrecta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtClaveActual.Focus();
                }
            }
            else
            {
                MessageBox.Show("La nueva clave no coinciden.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNuevaClaveI.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
