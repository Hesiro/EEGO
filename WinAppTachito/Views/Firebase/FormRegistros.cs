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
using WinAppTachito.Models.Firebase;

namespace WinAppTachito.Views.Firebase
{
    public partial class FormRegistros : Form
    {
        List<KeyTachitoPadre> tachitosPadre;
        List<KeyTachitoDetalle> tachitosDetalle;
        readonly Database.Firebase.Tachito servicio;
        KeyTachitoPadre selectedRow;
        List<KeyTachitoDetalle> selectedRowDetalle;
        public FormRegistros()
        {
            InitializeComponent();
            servicio = new Database.Firebase.Tachito();
        }

        private void FormRegistros_Load(object sender, EventArgs e)
        {
            lbInfo.Text = "";
            lbArea.Text = "";
            lbFecha.Text = "";
        }

        private async void BtnTraerDatos_Click(object sender, EventArgs e)
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

            await Task.Run(() => {
                tachitosPadre = servicio.GetAllTachitosPadre();
                tachitosDetalle = servicio.GetAllTachitosDetalle();
            });            

            btnTraerDatos.Enabled = true;
            btnExportar.Enabled = true;
            btnTransferir.Enabled = true;
            btnEliminar.Enabled = true;
            dgvDatos.Enabled = true;
            dgvDetalle.Enabled = true;
            bsDatos.DataSource = tachitosPadre;
        }

        private void DgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvDatos.RowCount > 0)
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                if (bsDatos.Current != null)
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
            }
            catch (Exception)
            {
                
            }
            
        }

        private void BtnTransferir_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                if(selectedRowDetalle!=null)
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
                        MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Delete();
                    }
                }
            }            
        }
        private void Transferir()
        {
            btnTraerDatos.Enabled = false;
            btnExportar.Enabled = false;
            btnTransferir.Enabled = false;
            btnEliminar.Enabled = false;
            dgvDatos.Enabled = false;
            dgvDetalle.Enabled = false;
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
                            if (!servicio.DeleteTachitoDetalle(item.Key))
                            {
                                errores = true;
                            }
                            else
                            {
                                foreach (KeyTachitoDetalle i in tachitosDetalle)
                                {
                                    if (i.Key.Equals(item.Key))
                                    {
                                        tachitosDetalle.Remove(i);
                                        break;
                                    }
                                }
                            }
                        });
                        contador++;
                        lbInfo.Text = "Eliminando..." + (100 * (decimal)contador / (decimal)total).ToString("N0") + "%";
                    }

                    lbInfo.Text = "Eliminando...100%";
                }
                if (!errores)
                {
                    await Task.Run(() =>
                    {
                        if (servicio.DeleteTachitoPadre(padreEliminar.Key))
                        {
                            foreach (var i in tachitosPadre)
                            {
                                if (i.Key.Equals(padreEliminar.Key))
                                {
                                    tachitosPadre.Remove(i);
                                    break;
                                }
                            }
                        }
                    });
                }
                
            }
            catch (Exception ex)
            {
                Log.FailRegister("Firebase.FormRegistros: " + ex.Message);
            }            
            btnTraerDatos.Enabled = true;
            btnExportar.Enabled = true;
            btnTransferir.Enabled = true;
            btnEliminar.Enabled = true;
            dgvDatos.Enabled = true;
            dgvDetalle.Enabled = true;
            lbInfo.Text = "";
            bsDetalle.DataSource = null;
            bsDatos.DataSource = null;            
            selectedRowDetalle = null;
            selectedRow = null;
            lbArea.Text = "";
            lbFecha.Text = "";
            bsDatos.DataSource = tachitosPadre;            
            //bsDetalle.DataSource = selectedRowDetalle;
            CargarDatos();
        }

        private void dgvDatos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }
    }
}
