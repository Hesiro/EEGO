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
    public partial class frmSelectArea : Form
    {
        private List<AreaGeneral> listArea = new List<AreaGeneral>();
        private List<AreaGeneral> listAreaFiltro = new List<AreaGeneral>();
        private AreaGeneral currentArea = new AreaGeneral();
        private List<string> LoteExistente;
        public frmSelectArea()
        {
            InitializeComponent();
        }
        public frmSelectArea(List<string> loteExistente)
        {
            InitializeComponent();
            LoteExistente = loteExistente;
        }
        public AreaGeneral Area
        {
            get
            {
                return currentArea;
            }
        }
        private void frmSelectArea_Load(object sender, EventArgs e)
        {
            ActualizarDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void ActualizarDatos()
        {
            listArea = AreaGeneralBL.Instancia.List();
            listAreaFiltro = new List<AreaGeneral>();
            bool Looking = false;
            if (LoteExistente != null)
            {
                if (LoteExistente.Count() > 0)
                {
                    foreach (var item in listArea)
                    {
                        Looking = false;
                        foreach (var arr in LoteExistente)
                        {
                            if (item.Codigo == arr)
                            {
                                Looking = true;
                                break;
                            }
                        }

                        if (!Looking)
                        {
                            listAreaFiltro.Add(item);
                        }
                        Looking = false;
                    }
                }
                else
                {
                    listAreaFiltro = listArea.ToList();
                }
            }
            else
            {
                listAreaFiltro = listArea.ToList();
            }

            bsArea.DataSource = listAreaFiltro;
            CargarDato();
        }

        private void dgDatos_SelectionChanged(object sender, EventArgs e)
        {
            CargarDato();
        }
        private void CargarDato()
        {
            if (dgDatos.RowCount > 0)
                currentArea = (AreaGeneral)bsArea.Current;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
