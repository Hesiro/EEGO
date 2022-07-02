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
    public partial class FormSelectEmisor : Form
    {
        List<TipoManguera> listManguera = new List<TipoManguera>();
        TipoManguera currentManguera = new TipoManguera();
        public FormSelectEmisor()
        {
            InitializeComponent();
        }
        public TipoManguera Manguera
        {
            get
            {
                return currentManguera;
            }
        }
        private void FormSelectEmisor_Load(object sender, EventArgs e)
        {
            ActualizarDatos();
        }
        private void ActualizarDatos()
        {
            listManguera = TipoMangueraBL.Instancia.List();
            bsDatos.DataSource = listManguera;
            CargarDato();
        }
        private void CargarDato()
        {
            if (dgvDatos.RowCount > 0)
                currentManguera = (TipoManguera)bsDatos.Current;
        }

        private void DgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            CargarDato();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
