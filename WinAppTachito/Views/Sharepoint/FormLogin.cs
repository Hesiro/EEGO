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

namespace WinAppTachito.Views.Sharepoint
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtUser.Text = "";
            txtPass.Text = "";
            ckbRecordar.Checked = false;
            txtUser.Enabled = false;
            txtPass.Enabled = false;
            ckbRecordar.Enabled = false;
            btnAceptar.Enabled = false;
        }
        private async void FormLogin_Shown(object sender, EventArgs e)
        {
            string recordar = ConfigurationManager.AppSettings["ToRemember"];
            if (!string.IsNullOrEmpty(recordar))
            {                
                if (recordar.Equals("0"))
                {
                    txtUser.Enabled = true;
                    txtPass.Enabled = true;
                    ckbRecordar.Enabled = true;
                    btnAceptar.Enabled = true;
                }
                else
                {
                    bool isLogin = false;
                    await Task.Run(() => {
                        isLogin = Login(ConfigurationManager.AppSettings["Email"], ConfigurationManager.AppSettings["Password"]);
                    });
                    if (isLogin)
                    {
                        FormRegistros oRegistros = new FormRegistros(ConfigurationManager.AppSettings["Email"], ConfigurationManager.AppSettings["Password"])
                        {
                            MdiParent = ParentForm
                        };
                        oRegistros.Show();
                        Close();
                    }
                    else
                    {
                        txtUser.Enabled = true;
                        txtPass.Enabled = true;
                        ckbRecordar.Enabled = true;
                        txtUser.Text = Log.Decrypt(ConfigurationManager.AppSettings["Email"]);
                        ckbRecordar.Checked = true;
                        btnAceptar.Enabled = true;
                        txtUser.Focus();
                    }
                }
            }
            else
            {
                txtUser.Enabled = true;
                txtPass.Enabled = true;
                ckbRecordar.Enabled = true;
                btnAceptar.Enabled = true;
                txtUser.Focus();
            }
        }
        private bool Login(string user, string pass)
        {
            return new Database.CSOM.Usuario().Verificar(user,pass);
        }
        private async void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                txtUser.Enabled = false;
                txtPass.Enabled = false;
                ckbRecordar.Enabled = false;
                btnAceptar.Enabled = false;

                bool isLogin = false;
                await Task.Run(() => {
                    isLogin = Login(Log.Encrypt(txtUser.Text), Log.Encrypt(txtPass.Text));
                });

                if (isLogin)
                {
                    Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    if (ckbRecordar.Checked)
                    {
                        configuration.AppSettings.Settings["ToRemember"].Value = "1";
                        configuration.AppSettings.Settings["Email"].Value = Log.Encrypt(txtUser.Text);
                        configuration.AppSettings.Settings["Password"].Value = Log.Encrypt(txtPass.Text);
                    }
                    else
                    {
                        configuration.AppSettings.Settings["ToRemember"].Value = "0";
                        configuration.AppSettings.Settings["Email"].Value = Log.Encrypt("abc@def.com");
                        configuration.AppSettings.Settings["Password"].Value = Log.Encrypt("123456");
                    }
                    configuration.Save();
                    ConfigurationManager.RefreshSection("appSettings");
                    FormRegistros oRegistros = new FormRegistros(Log.Encrypt(txtUser.Text), Log.Encrypt(txtPass.Text))
                    {
                        MdiParent = ParentForm
                    };
                    oRegistros.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("No se pudo Iniciar Sesión, verifique sus datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtUser.Enabled = true;
                txtPass.Enabled = true;
                ckbRecordar.Enabled = true;
                btnAceptar.Enabled = true;
            }
        }
        private bool Validar()
        {
            if (txtUser.Text.Equals(""))
            {
                return false;
            }
            else
            {
                if (txtPass.Text.Equals(""))
                {
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
