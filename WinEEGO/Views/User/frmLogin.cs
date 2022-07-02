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
    public partial class frmLogin : Form
    {
        int intentosSesion = 0;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUser.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Usuario res = UsuarioBL.Instancia.Login(
                new Usuario()
                {
                    NombreUsuario = txtUser.Text,
                    Password = txtPass.Text
                });
            if (res != null)
            {
                Log.UsuarioSistema.NombreUsuario = res.NombreUsuario;
                Log.UsuarioSistema.AccesoEGO = res.AccesoEGO;
                Log.UsuarioSistema.PerteneceA = res.PerteneceA;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No se pudo Iniciar Sesión, verifique sus datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                intentosSesion++;
                if (intentosSesion.Equals(3))
                    Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
