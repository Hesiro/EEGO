using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinEEGO.Business;
using WinEEGO.Models;

namespace WinEEGO.Views.Mantto
{
    public partial class frmCultivos : Form
    {
        private Cultivo currentCultivo;
        private bool isNew = false;

        public event EventHandler FormularioCerrado;
        public frmCultivos()
        {
            InitializeComponent();
        }

        private void frmCultivos_Load(object sender, EventArgs e)
        {
            txtCultivo.ReadOnly = true;
            txtCultivo.BackColor = Color.Ivory;            
            dgDatos.Enabled = true;
            
            Actualizar();
        }
        private void onFormularioCerrado()
        {
            if (FormularioCerrado != null)
            {
                FormularioCerrado(this, EventArgs.Empty);
            }
        }

        private void frmCultivos_FormClosed(object sender, FormClosedEventArgs e)
        {
            onFormularioCerrado();
        }
        private void Actualizar()
        {
            bsCultivo.DataSource = CultivoBL.Instancia.List();
        }

        private void dgDatos_SelectionChanged(object sender, EventArgs e)
        {
            currentCultivo = (Cultivo)bsCultivo.Current;
            CargarDatos();
        }
        private void CargarDatos()
        {
            if (currentCultivo != null)
            {
                txtCultivo.Text = currentCultivo.NombreCultivo;                
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (isNew)
            {
                btnInsertar.Text = "Nuevo";
                btnEliminar.Text = "Eliminar";

                txtCultivo.ReadOnly = true;
                txtCultivo.BackColor = Color.Ivory;                
                dgDatos.Enabled = true;

                isNew = false;

                CargarDatos();
            }
            else
            {
                if (currentCultivo != null)
                {
                    if (MessageBox.Show("¿Esta seguro de eliminar registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        if (CultivoBL.Instancia.Delete(currentCultivo))
                            Actualizar();
                        else
                            MessageBox.Show("No se pudo eliminar el registro", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (btnInsertar.Text.Equals("Nuevo"))
            {
                btnInsertar.Text = "Guardar";
                btnEliminar.Text = "Cancelar";
                btnExportar.Enabled = false;
                btnImprimir.Enabled = false;

                txtCultivo.ReadOnly = false;
                txtCultivo.BackColor = Color.White;                
                dgDatos.Enabled = false;

                txtCultivo.Text = "";

                txtCultivo.Focus();

                isNew = true;                
            }
            else
            {
                if (Validar())
                {
                    Cultivo _theRow = new Cultivo
                    {
                        NombreCultivo = txtCultivo.Text
                    };

                    if (isNew)
                    {
                        if (CultivoBL.Instancia.Insert(_theRow))
                        {
                            Actualizar();
                            btnInsertar.Text = "Nuevo";
                            btnEliminar.Text = "Eliminar";
                            btnExportar.Enabled = true;
                            btnImprimir.Enabled = true;
                            txtCultivo.ReadOnly = true;
                            txtCultivo.BackColor = Color.Ivory;                            
                            dgDatos.Enabled = true;                            
                            isNew = false;                            
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al intentar guardar el registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }                    
                }
                else
                {
                    MessageBox.Show("Verifique que sea correcto los datos ingresados", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private bool Validar()
        {
            if (txtCultivo.Text.Equals(""))
            {
                txtCultivo.Focus();
                return false;
            }
            else
            {
                return true;                                    
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgDatos.RowCount>0)
            {
                SLDocument sl = new SLDocument();
                SLStyle style = new SLStyle();
                style.Font.Bold=true;
                /*Cabecera*/
                sl.SetCellValue(1, 1, "Nombre del Cultivo");
                sl.SetCellStyle(1, 1, style);
                /*Detalle*/
                int pos = 2;
                foreach (DataGridViewRow item in dgDatos.Rows)
                {
                    sl.SetCellValue(pos, 1, item.Cells[0].Value.ToString());
                    pos++;
                }
                if (saveExport.ShowDialog()== DialogResult.OK)
                {
                    sl.SaveAs(saveExport.FileName);                    
                }
                
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgDatos.RowCount>0)
            {
                printDocument = new PrintDocument();
                PrinterSettings ps = new PrinterSettings();
                printDocument.PrinterSettings = ps;
                printDocument.PrintPage += Imprimir;
                printDocument.Print();
            }            
        }
        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            Font fontA = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
            int witnNombreCultivo = 250;
            int y = 20;
            e.Graphics.DrawString("Nombre del Cultivo", fontA, Brushes.Black, new RectangleF(10, y += 20, witnNombreCultivo, 20));

            Font fontB = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);
            foreach (DataGridViewRow item in dgDatos.Rows)
            {
                e.Graphics.DrawString(item.Cells[0].Value.ToString(), fontB, Brushes.Black, new RectangleF(10, y += 20, witnNombreCultivo, 20));
            }
        }
    }
}
