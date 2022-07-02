using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppTachito.Views.Config
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {

        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["Proveedor"].Value = txtProveedor.Text;
                configuration.AppSettings.Settings["Servidor"].Value = txtServidor.Text;
                configuration.AppSettings.Settings["BD"].Value = txtDB.Text;
                configuration.AppSettings.Settings["SerUsuario"].Value = Log.Encrypt(txtUsuario.Text);
                configuration.AppSettings.Settings["SerAcceso"].Value = Log.Encrypt(txtAcceso.Text);
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                Log.FailRegister("frmConfig: " + ex.Message);
            }
            DialogResult = DialogResult.OK;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
