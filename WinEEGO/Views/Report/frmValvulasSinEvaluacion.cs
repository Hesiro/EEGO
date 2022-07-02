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

namespace WinEEGO.Views.Report
{
    public partial class frmValvulasSinEvaluacion : Form
    {
        private List<EvaluacionGoteros> listEvaluacion = new List<EvaluacionGoteros>();
        public frmValvulasSinEvaluacion()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (cbCultivo.SelectedIndex >= 0)
            {
                if (btnMostrar.Text.Equals("Mostrar"))
                {
                    btnMostrar.Text = "Cambiar";
                    btnMostrar.ImageIndex = 1;
                    dtpDesde.Enabled = false;
                    dtpHasta.Enabled = false;
                    cbCultivo.Enabled = false;
                    dgDatos.Enabled = true;
                    btnMostrar.Enabled = false;
                    ActualizarDatos();
                    btnMostrar.Enabled = true;
                }
                else
                {
                    btnMostrar.Text = "Mostrar";
                    dtpDesde.Enabled = true;
                    dtpHasta.Enabled = true;
                    cbCultivo.Enabled = true;
                    bsSinEvaluacion.DataSource = null;
                    dgDatos.Enabled = false;
                }
            }
        }

        private void frmValvulasSinEvaluacion_Load(object sender, EventArgs e)
        {
            CargarCultivo();
            dgDatos.Enabled = false;

        }
        private void CargarCultivo()
        {
            List<Cultivo> listaCultivo;
            listaCultivo = CultivoBL.Instancia.List();
            cbCultivo.DataSource = listaCultivo;
            cbCultivo.DisplayMember = "NombreCultivo";
            cbCultivo.ValueMember = "NombreCultivo";
        }

        private void ActualizarDatos()
        {
            listEvaluacion = EvaluacionGoterosBL.Instancia.ListPendientes(dtpDesde.Value, dtpHasta.Value, cbCultivo.Text);
            bsSinEvaluacion.DataSource = listEvaluacion;
        }
    }
}
