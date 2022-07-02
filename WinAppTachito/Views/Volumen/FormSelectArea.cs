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

namespace WinAppTachito.Views.Volumen
{
    public partial class FormSelectArea : Form
    {
        private List<AreaGeneral> listArea = new List<AreaGeneral>();        
        private AreaGeneral currentArea = new AreaGeneral();
        public FormSelectArea()
        {
            InitializeComponent();
        }
        private void FormSelectArea_Load(object sender, EventArgs e)
        {
            ActualizarDatos();
        }
        public AreaGeneral Area
        {
            get
            {
                return currentArea;
            }
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void ActualizarDatos()
        {
            listArea = AreaGeneralBL.Instancia.List();            
            bsDatos.DataSource = listArea;
            CargarDato();
        }
        private void CargarDato()
        {
            if (dgvDatos.RowCount > 0)
                currentArea = (AreaGeneral)bsDatos.Current;
        }
        private void DgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            CargarDato();
        }
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
