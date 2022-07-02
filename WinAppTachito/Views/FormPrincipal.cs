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

namespace WinAppTachito.Views
{
    public partial class FormPrincipal : Form
    {
        bool res;
        public FormPrincipal()
        {
            InitializeComponent();
        }
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            Log.UsuarioSistema = new Usuario { 
                NombreUsuario = "", 
                AccesoEGO = TipoUsuario.Ninguno };
            LoadUser();
        }
        private void FormPrincipal_Shown(object sender, EventArgs e)
        {
            MsStatusBar.Text = "Estableciendo conexion con la Base de Datos...";
            VerificarConeccion();
        }
        private async void VerificarConeccion()
        {
            res = false;
            MsStatusBar.Text = "Estableciendo conexion con la Base de Datos...";
            await Task.Run(() =>
            {
                res = UsuarioBL.Instancia.VerifyConnection();
            });
            if (res)
            {
                Log.UsuarioSistema.AccesoEGO = TipoUsuario.Usuario;
                LoadUser();
                MsStatusBar.Text = "Iniciar sesión";
                User.FormLogin oUser = new User.FormLogin
                {
                    MdiParent = this                    
                };
                oUser.OnFormLogin += OUser_OnFormLogin;
                oUser.Show();                
            }
            else
            {
                MsStatusBar.Text = "Error al establecer conexión con la base de datos";
            }
        }

        private void OUser_OnFormLogin(object sender, bool e)
        {
            if (e)
            {
                LoadUser();
            }
            
        }

        private void LoadUser()
        {
            if (Log.UsuarioSistema.AccesoEGO == TipoUsuario.Administrador)
            {
                EvaluacionTSMI.Enabled = true;
                AppTachitoTSMI.Enabled = true;
                reporteTSMI.Enabled = true;

                UsuariosTSMI.Enabled = true;
                RegistrosTSMI.Enabled = true;
                registros2TSMI.Enabled = true;
                SharepointTSMI.Enabled = true;
            }
            else
            {
                if (Log.UsuarioSistema.AccesoEGO == TipoUsuario.Registrador)
                {
                    EvaluacionTSMI.Enabled = true;
                    AppTachitoTSMI.Enabled = true;
                    reporteTSMI.Enabled = true;

                    UsuariosTSMI.Enabled = false;
                    RegistrosTSMI.Enabled = true;
                    registros2TSMI.Enabled = true;
                    SharepointTSMI.Enabled = true;
                }
                else
                {
                    if(Log.UsuarioSistema.AccesoEGO == TipoUsuario.Usuario)
                    {
                        EvaluacionTSMI.Enabled = false;
                        AppTachitoTSMI.Enabled = false;
                        reporteTSMI.Enabled = true;

                        UsuariosTSMI.Enabled = false;
                        RegistrosTSMI.Enabled = false;
                        registros2TSMI.Enabled = false;
                        SharepointTSMI.Enabled = false;
                    }
                    else
                    {
                        EvaluacionTSMI.Enabled = false;
                        AppTachitoTSMI.Enabled = false;
                        reporteTSMI.Enabled = false;

                        UsuariosTSMI.Enabled = false;
                        RegistrosTSMI.Enabled = false;
                        registros2TSMI.Enabled = false;
                        SharepointTSMI.Enabled = false;
                    }                    
                }
            }
            MsStatusBar.Text = "Usuario: " + Log.UsuarioSistema.NombreUsuario;
        }

        private void SsPrincipal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!res)
            {
                Config.FormConfig oUser = new Config.FormConfig();
                oUser.ShowDialog();
                if (oUser.DialogResult == DialogResult.OK)
                    Application.Restart();
            }
        }

        private void SalirTSMI_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UsuariosTSMI_Click(object sender, EventArgs e)
        {
            Firebase.FormUsuarios oUserFb = new Firebase.FormUsuarios
            {
                MdiParent = this
            };
            oUserFb.Show();
        }

        private void RegistrosTSMI_Click(object sender, EventArgs e)
        {
            Firebase.FormRegistros oRegistrosFb = new Firebase.FormRegistros
            {
                MdiParent = this
            };
            oRegistrosFb.Show();
        }

        private void TachitosTSMI_Click(object sender, EventArgs e)
        {
            Volumen.FormTachito oTachito = new Volumen.FormTachito { 
                MdiParent = this
            };
            oTachito.Show();
        }

        private void SharepointTSMI_Click(object sender, EventArgs e)
        {
            Sharepoint.FormLogin oLogin = new Sharepoint.FormLogin
            {
                MdiParent = this
            };
            oLogin.Show();
        }

        private void acumuladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Volumen.Report.FormReporteAcumulado oReport = new Volumen.Report.FormReporteAcumulado
            {
                MdiParent = this
            };
            oReport.Show();
        }

        private void resumenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Volumen.Report.FormReporteResumen oReport = new Volumen.Report.FormReporteResumen
            {
                MdiParent = this
            };
            oReport.Show();
        }

        private void registrosV13ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Firebase.FormRegistrosUnidos oRegistrosFb = new Firebase.FormRegistrosUnidos
            {
                MdiParent = this
            };
            oRegistrosFb.Show();
        }
    }
}
