using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace POO_OnLine_2020_07_01_Accionistas
{
    public partial class Form1 : Form
    {
        List<Accion> _la;
        List<Accionista> _lacc;
        public Form1()
        {
            InitializeComponent();
            _la = new List<Accion>(); _lacc = new List<Accionista>();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.MultiSelect = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try 
            { 
                _lacc.Add(new Accionista(Interaction.InputBox("Nombre: ")));
                Mostrar(dataGridView1, _lacc); 
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

           
        }
        private void Mostrar(DataGridView pD,object pO)
        { pD.DataSource = null;pD.DataSource = pO; }
        private void button2_Click(object sender, EventArgs e)
        {
            try 
            {
                _lacc.Remove(dataGridView1.SelectedRows[0].DataBoundItem as Accionista);
                Mostrar(dataGridView1, _lacc);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            try 
            {
                _la.Add(new Accion(Interaction.InputBox("Id: "),Interaction.InputBox("Descripción: ")));
                Mostrar(dataGridView2, _la);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            try 
            {
                _la.Remove(dataGridView2.SelectedRows[0].DataBoundItem as Accion);
                Mostrar(dataGridView2, _la);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void button6_Click(object sender, EventArgs e)
        {
            (dataGridView2.SelectedRows[0].DataBoundItem as Accion).Precio = decimal.Parse(Interaction.InputBox("Ingrese el nuevo precio: "));
            Mostrar(dataGridView2, _la);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try 
            {
                Accionista _a = (dataGridView1.SelectedRows[0].DataBoundItem as Accionista);
                _a.AgregarAccion(dataGridView2.SelectedRows[0].DataBoundItem as Accion);
                Mostrar(dataGridView3,_a.RetornaAcciones());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Mostrar(dataGridView3, (dataGridView1.SelectedRows[0].DataBoundItem as Accionista).RetornaAcciones());
            }
            catch (Exception)
            {

          
            }
        } 
        private void button7_Click(object sender, EventArgs e)
        {
            try 
            {
                Accionista _a = (dataGridView1.SelectedRows[0].DataBoundItem as Accionista);
                _a.QuitarAccion(dataGridView3.SelectedRows[0].DataBoundItem as Accion);
                Mostrar(dataGridView3, _a.RetornaAcciones());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            try 
            {
                Accionista _a = (dataGridView1.SelectedRows[0].DataBoundItem as Accionista);
                _a.AgregarAccion(dataGridView2.SelectedRows[0].DataBoundItem as Accion);
                Mostrar(dataGridView3, _a.RetornaAcciones());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }

    public class Accionista
    {
        List<Accion> _l;
        public Accionista(string pNombre) { _l = new List<Accion>();Nombre = pNombre; }
        public string Nombre { get; set; }

        public void AgregarAccion(Accion pAccion)
        {
            _l.Add(pAccion); pAccion.CambioValor += Recalcular;
        }
        public void QuitarAccion(Accion pAccion)
        {
             pAccion.CambioValor -= Recalcular; _l.Remove(pAccion);
        }
        private void Recalcular(object sender, CambioValorEventArg e)
        {
            MessageBox.Show($"{Nombre} se enteró que la acción cambió de precio" +
                            $"{Constants.vbCrLf}{Constants.vbCrLf}" +
                            $"{((Accion)sender).Id}  {((Accion)sender).Descripcion} " +
                            $"{Constants.vbCrLf}{Constants.vbCrLf}" +
                            $"Precio Actual:   {e.PrecioActual.ToString()}{Constants.vbCrLf}" +
                            $"Precio Anterior: {e.PrecioAnterior.ToString()}");
        }

        public List<Accion> RetornaAcciones()
        {
            return _l;
        }
    }
    public class Accion
    {


        decimal _precio;
        decimal _precioAnterior;
        public event EventHandler<CambioValorEventArg> CambioValor;
        public Accion(string pId, string pDescripcion) { Id = pId;Descripcion = pDescripcion;Precio = 0; }
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio
        { 
            get { return _precio; } 
            set { _precioAnterior = _precio; _precio = value; CambioValor?.Invoke(this, new CambioValorEventArg(_precio,_precioAnterior)); } 
            // if(CambioValor!=null){ ... Desencadeno}
        }

    }
    public class CambioValorEventArg
    {
        public CambioValorEventArg(Decimal pPrecioActual, Decimal pPrecioAnterior)
        { PrecioActual = pPrecioActual;PrecioAnterior = pPrecioAnterior; }
        public Decimal PrecioActual { get; set; }
        public Decimal PrecioAnterior { get; set; }
    }
}
