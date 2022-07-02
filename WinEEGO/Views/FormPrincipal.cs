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

namespace WinEEGO.Views
{
    public partial class FormPrincipal : Form
    {
        private int statusConnection;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            evaluacionTSMI.Enabled = false;
            //actividadesTSMI.Enabled = false;
            reporteTSMI.Enabled = false;
            mantenimientoTSMI.Enabled = false;
            usuarioTSMI.Enabled = false;
            ventanaTSMI.Enabled = false;
            //ayudaTSMI.Enabled = false;

            btnNuevo.Enabled = false;
            btnAbrir.Enabled = false;
            btnPorAnio.Enabled = false;
            btnPorArea.Enabled = false;
            btnPorValvula.Enabled = false;
            //btnValvulasProblema.Enabled = false;
            btnIniciarSesion.Visible = false;
            btnCerrarSesion.Visible = false;
        }

        private void FormPrincipal_Shown(object sender, EventArgs e)
        {
            msStatusBar.Text = "Estableciendo conexion con la Base de Datos...";
            bwk.RunWorkerAsync();
            this.WindowState = FormWindowState.Maximized;
        }

        private void bwk_DoWork(object sender, DoWorkEventArgs e)
        {
            VerificarConexion();
        }
        private void VerificarConexion()
        {
            bool result = UsuarioBL.Instancia.VerifyConnection();
            statusConnection = 0;
            if (result)
            {
                statusConnection = 1;                
                if (Log.VersionSW().Equals(UsuarioBL.Instancia.Version()))
                {
                    statusConnection = 2;
                }
            }

        }
        private void bwk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (statusConnection != 0)
            {
                if (statusConnection == 1)
                {
                    MessageBox.Show("¡Hay una nueva version del software!\n\n Pongase en contacto con su proveedor para acceder a la nueva versión.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    msStatusBar.Text = "Actualizar software con la nueva versión...";
                }
                else
                {
                    Log.UsuarioSistema = new Usuario()
                    {
                        NombreUsuario = "",
                        AccesoEGO = TipoUsuario.Ninguno
                    };
                    loadUser();
                }
            }
            else
            {
                msStatusBar.Text = "Error al establecer conexión con la base de datos...";
            }
        }

        private void loadUser()
        {
            reporteTSMI.Enabled = true;
            usuarioTSMI.Enabled = true;
            ventanaTSMI.Enabled = true;
            //ayudaTSMI.Enabled = true;
            btnPorAnio.Enabled = true;
            btnPorArea.Enabled = true;
            btnPorValvula.Enabled = true;
            //btnValvulasProblema.Enabled = true;


            if (Log.UsuarioSistema.AccesoEGO == TipoUsuario.Administrador)
            {
                evaluacionTSMI.Enabled = true;
                abrirTSMI.Enabled = true;
                //    actividadesTSMI.Enabled = true;
                mantenimientoTSMI.Enabled = true;
                iniciarSesionTSMI.Enabled = false;
                cambiarClaveTSMI.Enabled = true;
                cerrarSesionTSMI.Enabled = true;

                btnNuevo.Enabled = true;
                btnAbrir.Enabled = true;
                btnIniciarSesion.Visible = false;
                btnCerrarSesion.Visible = true;

                msStatusBar.Text = "Usuario: " + Log.UsuarioSistema.NombreUsuario;
            }
            else
            {
                if (Log.UsuarioSistema.AccesoEGO == TipoUsuario.Registrador)
                {
                    evaluacionTSMI.Enabled = true;
                    abrirTSMI.Enabled = true;
                    mantenimientoTSMI.Enabled = false;
                    iniciarSesionTSMI.Enabled = false;
                    cambiarClaveTSMI.Enabled = true;
                    cerrarSesionTSMI.Enabled = true;

                    btnNuevo.Enabled = true;
                    btnAbrir.Enabled = true;
                    btnIniciarSesion.Visible = false;
                    btnCerrarSesion.Visible = true;
                    msStatusBar.Text = "Usuario: " + Log.UsuarioSistema.NombreUsuario;
                }
                else
                {
                    evaluacionTSMI.Enabled = false;
                    mantenimientoTSMI.Enabled = false;
                    iniciarSesionTSMI.Enabled = true;
                    cambiarClaveTSMI.Enabled = false;
                    cerrarSesionTSMI.Enabled = false;

                    btnNuevo.Enabled = false;
                    btnAbrir.Enabled = false;
                    btnIniciarSesion.Visible = true;
                    btnCerrarSesion.Visible = false;
                    msStatusBar.Text = "";
                }
            }
        }

        #region Eventos Menu
        private void cascadaTSMI_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void verticalTSMI_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void horizontalTSMI_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
        private void iniciarSesionTSMI_Click(object sender, EventArgs e)
        {
            OpenReport("LogIn");
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            OpenReport("LogIn");
        }

        private void cerrarSesionTSMI_Click(object sender, EventArgs e)
        {
            OpenReport("LogOut");
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            OpenReport("LogOut");
        }

        private void cambiarClaveTSMI_Click(object sender, EventArgs e)
        {
            OpenReport("LogUpdate");
        }
        private void nuevoTSMI_Click(object sender, EventArgs e)
        {
            OpenReport("Nuevo");
        }
        #endregion

        private void OpenReport(string winToOpen)
        {
            switch (winToOpen)
            {
                case "Nuevo":
                    Eego.frmNewEvaluacion frmNew = new Eego.frmNewEvaluacion();
                    if (frmNew.ShowDialog() == DialogResult.OK)
                    {
                        Eego.frmDetailEvaluacion frmDetail = new Eego.frmDetailEvaluacion(frmNew.Evaluacion);
                        frmDetail.MdiParent = this;
                        frmNew.Close();
                        frmDetail.Show();
                    }
                    else
                    {
                        frmNew.Close();
                    }
                    break;
                case "Abrir":
                    Eego.frmOpenEvaluacion frmOpen = new Eego.frmOpenEvaluacion();
                    frmOpen.MdiParent = this;
                    frmOpen.onFormCerrado += new EventHandler(frm_onFormCerradoOpen);
                    frmOpen.Show();
                    abrirTSMI.Enabled = false;
                    btnAbrir.Enabled = false;
                    break;
                case "LogIn":
                    User.frmLogin oUser = new User.frmLogin();
                    oUser.ShowDialog();
                    if (oUser.DialogResult == DialogResult.OK)
                        loadUser();
                    oUser.Close();
                    break;
                case "LogOut":
                    if (Log.UsuarioSistema != null)
                    {
                        Log.UsuarioSistema.NombreUsuario = "";
                        Log.UsuarioSistema.AccesoEGO = TipoUsuario.Ninguno;
                        foreach (var item in this.MdiChildren)
                        {
                            item.Close();
                        }
                        loadUser();
                    }
                    break;
                case "LogUpdate":
                    User.frmCambiarClave oUserUpdate = new User.frmCambiarClave();
                    oUserUpdate.ShowDialog();
                    if (oUserUpdate.DialogResult == DialogResult.OK)
                        loadUser();
                    oUserUpdate.Close();
                    break;
                case "001":
                    Report.frmPorAnio frm001 = new Report.frmPorAnio();
                    frm001.MdiParent = this;
                    frm001.Show();
                    break;
                case "002":
                    Report.frmPorArea frm002 = new Report.frmPorArea();
                    frm002.MdiParent = this;
                    frm002.Show();
                    break;
                case "003":
                    Report.frmPorValvula frm003 = new Report.frmPorValvula();
                    frm003.MdiParent = this;
                    frm003.Show();
                    break;
                default:
                    break;
            }
        }

        #region "Eventos Menu EventHandler"
        private void usuariosTSMI_Click(object sender, EventArgs e)
        {
            Mantto.frmUsuarios frm = new Mantto.frmUsuarios();
            frm.FormularioCerrado += new EventHandler(FormularioCerradoAcceso);
            frm.MdiParent = this;
            frm.Show();
            usuariosTSMI.Enabled = false;
        }
        void FormularioCerradoAcceso(Object sender, EventArgs e)
        {
            usuariosTSMI.Enabled = true;
        }
        private void cultivosTSMI_Click(object sender, EventArgs e)
        {
            Mantto.frmCultivos frm = new Mantto.frmCultivos();
            frm.FormularioCerrado += new EventHandler(FormularioCerradoCultivo);
            frm.MdiParent = this;
            frm.Show();
            cultivosTSMI.Enabled = false;
        }
        void FormularioCerradoCultivo(Object sender, EventArgs e)
        {
            cultivosTSMI.Enabled = true;
        }
        private void areasTSMI_Click(object sender, EventArgs e)
        {
            Mantto.frmAreaGeneral frm = new Mantto.frmAreaGeneral();
            frm.onFormCerrado += new EventHandler(frm_onFormCerradoAreas);
            frm.MdiParent = this;
            frm.Show();
            areasTSMI.Enabled = false;
        }
        void frm_onFormCerradoAreas(Object sender, EventArgs e)
        {
            areasTSMI.Enabled = true;
        }
        private void emisoresTSMI_Click(object sender, EventArgs e)
        {
            Mantto.frmTipoManguera frm = new Mantto.frmTipoManguera();
            frm.onFormCerrado += new EventHandler(frm_onFormCerradoManguera);
            frm.MdiParent = this;
            frm.Show();
            emisoresTSMI.Enabled = false;
        }
        void frm_onFormCerradoManguera(Object sender, EventArgs e)
        {
            emisoresTSMI.Enabled = true;
        }
        private void abrirTSMI_Click(object sender, EventArgs e)
        {
            OpenReport("Abrir");
        }
        void frm_onFormCerradoOpen(Object sender, EventArgs e)
        {
            abrirTSMI.Enabled = true;
            btnAbrir.Enabled = true;
        }




        #endregion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            OpenReport("Nuevo");
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenReport("Abrir");
        }        

        private void btnPorAnio_Click(object sender, EventArgs e)
        {
            OpenReport("001");
        }

        private void porAnioTSMI_Click(object sender, EventArgs e)
        {
            OpenReport("001");
        }

        private void porAreaTSMI_Click(object sender, EventArgs e)
        {
            OpenReport("002");
        }

        private void btnPorArea_Click(object sender, EventArgs e)
        {
            OpenReport("002");
        }

        private void btnPorValvula_Click(object sender, EventArgs e)
        {
            OpenReport("003");
        }

        private void porValvulaTSMI_Click(object sender, EventArgs e)
        {
            OpenReport("003");
        }

        private void ssPrincipal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (statusConnection == 0)
            {
                Config.frmConfig oUser = new Config.frmConfig();
                oUser.ShowDialog();
                if (oUser.DialogResult == DialogResult.OK)
                    Application.Restart();
            }
                
        }

        private void lotesSinEvaluaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report.frmValvulasSinEvaluacion frmXYZ = new Report.frmValvulasSinEvaluacion();
            frmXYZ.MdiParent = this;
            frmXYZ.Show();
        }

        private void cuCvCdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report.frmCuCvCd frmXYZ = new Report.frmCuCvCd();
            frmXYZ.MdiParent = this;
            frmXYZ.Show();
        }
    }
}
