using SpreadsheetLight;
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
using WinAppTachito.Business;
using WinAppTachito.Models;
using WinAppTachito.Models.Firebase;

namespace WinAppTachito.Views.Sharepoint
{
    public partial class FormRegistros : Form
    {
        private readonly string user;
        private readonly string pass;
        List<KeyTachitoPadre> tachitosPadre;
        List<KeyTachitoDetalle> tachitosDetalle;
        readonly Database.CSOM.Tachito servicio;
        KeyTachitoPadre selectedRow;
        List<KeyTachitoDetalle> selectedRowDetalle;
        public FormRegistros(string userMicrosoft, string passMicrosoft)
        {
            InitializeComponent();
            user = userMicrosoft;
            pass = passMicrosoft;
            servicio = new Database.CSOM.Tachito();
        }
        private void BtnTraerDatos_Click(object sender, EventArgs e)
        {
            TraerDatos();
        }
        private async void TraerDatos()
        {
            btnTraerDatos.Enabled = false;
            btnExportar.Enabled = false;
            btnTransferir.Enabled = false;
            btnEliminar.Enabled = false;
            dgvDatos.Enabled = false;
            dgvDetalle.Enabled = false;
            bsDatos.DataSource = null;
            bsDetalle.DataSource = null;
            selectedRow = null;
            selectedRowDetalle = null;
            lbArea.Text = "";
            lbFecha.Text = "";
            dtpFecha.Enabled = false;

            long fechaDesde = dtpFecha.Value.Year * 10000000000 +
                dtpFecha.Value.Month * 100000000 +
                dtpFecha.Value.Day * 1000000;
            long fechaHasta = fechaDesde + 1000000;

            await Task.Run(() => {
                tachitosPadre = servicio.GetAllTachitosPadre(user, pass, fechaDesde, fechaHasta);
                if (tachitosDetalle != null)
                    tachitosDetalle.Clear();
                else
                    tachitosDetalle = new List<KeyTachitoDetalle>();
                foreach (var item in tachitosPadre)
                {
                    List<KeyTachitoDetalle> tachitosDetalleTemp;
                    tachitosDetalleTemp = servicio.GetAllTachitosDetalle(user, pass, item.Id);
                    foreach (var itemTemp in tachitosDetalleTemp)
                    {
                        tachitosDetalle.Add(itemTemp);
                    }
                }
            });           

            btnTraerDatos.Enabled = true;
            btnExportar.Enabled = true;
            btnTransferir.Enabled = true;
            btnEliminar.Enabled = true;
            dgvDatos.Enabled = true;
            dgvDetalle.Enabled = true;
            bsDatos.DataSource = tachitosPadre;
            dtpFecha.Enabled = true;
        }
        private void DgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            selectedRow = (KeyTachitoPadre)bsDatos.Current;
            if (selectedRow != null)
            {
                List<KeyTachitoDetalle> listaFiltro = new List<KeyTachitoDetalle>();
                var filtro = tachitosDetalle.Where(n => n.IdPadre == selectedRow.Id).ToList();
                foreach (var item in filtro)
                {
                    listaFiltro.Add(item.Copy());
                }
                selectedRowDetalle = listaFiltro;
                foreach (var item in selectedRowDetalle)
                {
                    item.Comentario = selectedRow.Usuario + ": " + item.Comentario;
                }
                bsDetalle.DataSource = selectedRowDetalle;
                lbArea.Text = "Area: " + selectedRow.Area;
                lbFecha.Text = "Fecha: " + selectedRow.Fecha.ToString("dd/MM/yyyy");
            }
        }
        private void BtnTransferir_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                if (selectedRowDetalle != null)
                {
                    if (MessageBox.Show("¿Esta seguro de transferir el registro: " + selectedRow.Area + "?", "Confirmar",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Transferir();
                    }
                }
            }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                if (selectedRowDetalle != null)
                {
                    if (MessageBox.Show("¿Esta seguro de eliminar el registro: " + selectedRow.Area + "?", "Confirmar",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Delete();
                    }
                }
            }
        }
        private void FormRegistros_Load(object sender, EventArgs e)
        {
            lbInfo.Text = "";
            lbArea.Text = "";
            lbFecha.Text = "";
            try
            {
                string recordar = ConfigurationManager.AppSettings["ToRemember"];
                if (!string.IsNullOrEmpty(recordar))
                {
                    if (recordar.Equals("0"))
                    {
                        lbCerrarSesion.Visible = false;
                    }
                    else
                    {
                        lbCerrarSesion.Visible = true;
                    }
                }
                else
                {
                    lbCerrarSesion.Visible = false;
                }
            }
            catch (Exception)
            {
                lbCerrarSesion.Visible = false;
            }
        }
        private void Transferir()
        {
            btnTraerDatos.Enabled = false;
            btnTransferir.Enabled = false;
            btnExportar.Enabled = false;
            btnEliminar.Enabled = false;
            dgvDatos.Enabled = false;
            dgvDetalle.Enabled = false;
            dtpFecha.Enabled = false;
            lbInfo.Text = "Transfiriendo...";
            if (selectedRowDetalle.Count > 0)
            {
                try
                {
                    KeyTachitoPadre padreTransferir = selectedRow.Copy();
                    List<EvaluacionVolumen> registrosDB = EvaluacionVolumenBL.Instancia.List(selectedRow.Fecha, selectedRow.Area);
                    if (registrosDB.Count == 0)
                    {
                        MessageBox.Show("No se econcontraron coincidencias", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (registrosDB.Count > 1)
                        {
                            MessageBox.Show("Se econcontraron varias coincidencias", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            List<DetalleEvaluacionVolumen> registroDetalleDB = EvaluacionVolumenBL.Instancia.ListDetalle(registrosDB[0]);
                            if (registroDetalleDB.Count > 0)
                            {
                                foreach (DetalleEvaluacionVolumen itemDB in registroDetalleDB)
                                {
                                    foreach (KeyTachitoDetalle item in selectedRowDetalle)
                                    {
                                        if (itemDB.Valvula.Equals(item.Valvula))
                                        {
                                            if (item.Total > 0)
                                            {
                                                itemDB.Medida01 = item.Medida1;
                                                itemDB.Medida02 = item.Medida2;
                                                itemDB.Nota = item.Comentario;
                                            }
                                            break;
                                        }
                                    }
                                }

                                if (EvaluacionVolumenBL.Instancia.UpdateDetalle(registroDetalleDB))
                                    MessageBox.Show("Se actualizaron los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    MessageBox.Show("No se actualizaron los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron las valvulas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.FailRegister("Firebase.FormRegistros: " + ex.Message);
                }
            }
            btnTraerDatos.Enabled = true;
            btnExportar.Enabled = true;
            btnTransferir.Enabled = true;
            btnEliminar.Enabled = true;
            dgvDatos.Enabled = true;
            dgvDetalle.Enabled = true;
            dtpFecha.Enabled = true;
            lbInfo.Text = "";
        }
        private async void Delete()
        {
            btnTraerDatos.Enabled = false;
            btnExportar.Enabled = false;
            btnTransferir.Enabled = false;
            btnEliminar.Enabled = false;
            dgvDatos.Enabled = false;
            dgvDetalle.Enabled = false;
            dtpFecha.Enabled = false;
            lbInfo.Text = "Eliminando...";
            bool errores = false;
            try
            {
                KeyTachitoPadre padreEliminar = selectedRow.Copy();
                if (selectedRowDetalle.Count > 0)
                {
                    int total = selectedRowDetalle.Count;
                    int contador = 0;
                    
                    foreach (KeyTachitoDetalle item in selectedRowDetalle)
                    {
                        await Task.Run(() =>
                        {
                            servicio.DeleteListItemsTachitosDetalle(user, pass, Convert.ToInt32(item.Key));
                        });                                                    
                        contador++;
                        lbInfo.Text = "Eliminando..." + (100 * (decimal)contador / (decimal)total).ToString("N0") + "%";
                    }

                    lbInfo.Text = "Eliminando...100%";
                    if (!errores)
                    {
                        await Task.Run(() =>
                        {
                            servicio.DeleteListItemsTachitosPadre(user, pass, Convert.ToInt32(padreEliminar.Key));
                        });                                                  
                    }
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister("Sharepoint.FormRegistros: " + ex.Message);
            }
            btnTraerDatos.Enabled = true;
            btnExportar.Enabled = true;
            btnTransferir.Enabled = true;
            btnEliminar.Enabled = true;
            dgvDatos.Enabled = true;
            dgvDetalle.Enabled = true;
            lbInfo.Text = "";            
            dtpFecha.Enabled = true;
            TraerDatos();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                if (selectedRowDetalle != null)
                {
                    saveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string pathFile = saveFileDialog.FileName;
                        SLDocument oSLDocument = new SLDocument();

                        DataTable dt = new DataTable();
                        dt.Columns.Add("Area", typeof(string));
                        dt.Columns.Add("Nombre de area", typeof(string));
                        dt.Columns.Add("Fecha", typeof(DateTime));
                        dt.Columns.Add("Usuario", typeof(string));

                        dt.Rows.Add(selectedRow.Area, selectedRow.NombreArea, selectedRow.Fecha, selectedRow.Usuario);

                        DataTable dta = new DataTable();
                        dta.Columns.Add("Valvula", typeof(string));
                        dta.Columns.Add("1ra medicion", typeof(decimal));
                        dta.Columns.Add("2da medicion", typeof(decimal));
                        dta.Columns.Add("Total", typeof(decimal));
                        dta.Columns.Add("Comentarios", typeof(string));
                        foreach (var item in selectedRowDetalle)
                        {
                            dta.Rows.Add(item.Valvula, item.Medida1, item.Medida2, item.Total, item.Comentario);
                        }

                        oSLDocument.ImportDataTable(1, 1, dt, true);
                        oSLDocument.ImportDataTable(4, 1, dta, true);
                        oSLDocument.SaveAs(pathFile);
                    }
                }
            }
        }

        private void lbCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["ToRemember"].Value = "0";
                configuration.AppSettings.Settings["Email"].Value = Log.Encrypt("abc@def.com", "real-soft-solutions");
                configuration.AppSettings.Settings["Password"].Value = Log.Encrypt("123456", "real-soft-solutions");
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception)
            {
                
            }
            this.Close();
        }
    }
}
