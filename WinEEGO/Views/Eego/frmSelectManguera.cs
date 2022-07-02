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

namespace WinEEGO.Views.Eego
{
    public partial class frmSelectManguera : Form
    {
        List<TipoManguera> listManguera = new List<TipoManguera>();
        TipoManguera currentManguera = new TipoManguera();
        public frmSelectManguera()
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
        private void frmSelectManguera_Load(object sender, EventArgs e)
        {
            ActualizarDatos();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void ActualizarDatos()
        {
            listManguera = TipoMangueraBL.Instancia.List();
            bsManguera.DataSource = listManguera;
            CargarDato();
        }
        private void dgDatos_SelectionChanged(object sender, EventArgs e)
        {
            CargarDato();
        }
        private void CargarDato()
        {
            if (dgDatos.RowCount > 0)
                currentManguera = (TipoManguera)bsManguera.Current;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
