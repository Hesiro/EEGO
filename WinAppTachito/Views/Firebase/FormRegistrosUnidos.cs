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
    public partial class FormRegistrosUnidos : Form
    {
        List<KeyTachitoPadreDetalle> tachitos;
        readonly Database.Firebase.Tachito servicio;
        KeyTachitoPadreDetalle selectedRow;
        List<TachitoDetalle> selectedRowDetalle;
        public FormRegistrosUnidos()
        {
            InitializeComponent();
            servicio = new Database.Firebase.Tachito();
        }

        private async void btnTraerDatos_Click(object sender, EventArgs e)
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
                tachitos = servicio.GetAllTachitoPadreDetalle();                
            });

            btnTraerDatos.Enabled = true;
            btnExportar.Enabled = true;
            btnTransferir.Enabled = true;
            btnEliminar.Enabled = true;
            dgvDatos.Enabled = true;
            dgvDetalle.Enabled = true;
            bsDatos.DataSource = tachitos;
        }

        private void FormRegistrosUnidos_Load(object sender, EventArgs e)
        {
            lbInfo.Text = "";
            lbArea.Text = "";
            lbFecha.Text = "";
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDatos.RowCount > 0)
                CargarDatos();
        }
        private void CargarDatos()
        {
            try
            {
                if (bsDatos.Current != null)
                {
                    selectedRow = (KeyTachitoPadreDetalle)bsDatos.Current;
                    if (selectedRow != null)
                    {                        
                        selectedRowDetalle = selectedRow.Valvulas; 
                        //foreach (var item in selectedRowDetalle)
                        //{
                        //    item.Comentario = selectedRow.Usuario + ": " + item.Comentario;
                        //}
                        bsDetalle.DataSource = selectedRowDetalle;
                        lbArea.Text = "Area: " + selectedRow.Area;
                        lbFecha.Text = "Fecha: " + selectedRow.Fecha.ToString("dd/MM/yyyy");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.FailRegister("FormRegistrosUnidos - " + ex.Message);
            }

        }

        private void btnTransferir_Click(object sender, EventArgs e)
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
                    KeyTachitoPadreDetalle padreTransferir = selectedRow.Copy();
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
                                    foreach (TachitoDetalle item in selectedRowDetalle)
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

        private void btnEliminar_Click(object sender, EventArgs e)
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
        private async void Delete()
        {
            btnTraerDatos.Enabled = false;
            btnExportar.Enabled = false;
            btnTransferir.Enabled = false;
            btnEliminar.Enabled = false;
            dgvDatos.Enabled = false;
            dgvDetalle.Enabled = false;
            lbInfo.Text = "Eliminando...";            
            try
            {
                KeyTachitoPadreDetalle padreEliminar = selectedRow.Copy();  

                await Task.Run(() =>
                {
                    if (servicio.DeleteTachitoPadreDetalle(padreEliminar.Key))
                    {
                        foreach (var i in tachitos)
                        {
                            if (i.Key.Equals(padreEliminar.Key))
                            {
                                tachitos.Remove(i);
                                break;
                            }
                        }
                    }
                });
                lbInfo.Text = "Eliminando...100%";

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
            bsDatos.DataSource = tachitos;
            //bsDetalle.DataSource = selectedRowDetalle;
            CargarDatos();
        }

        private void dgvDatos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }
    }
}
