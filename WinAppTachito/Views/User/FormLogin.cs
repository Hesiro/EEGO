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

namespace WinAppTachito.Views.User
{
    public partial class FormLogin : Form
    {
        int intentosSesion = 0;
        public event EventHandler<bool> OnFormLogin;
        public FormLogin()
        {
            InitializeComponent();
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
        private void BtnAceptar_Click(object sender, EventArgs e)
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
                OnFormLogin?.Invoke(this, true);
                Close();
            }
            else
            {
                MessageBox.Show("No se pudo Iniciar Sesión, verifique sus datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                intentosSesion++;
                if (intentosSesion.Equals(3))
                {
                    OnFormLogin?.Invoke(this, false);
                    Close(); 
                }
            }            
        }
    }
}
