using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZULETA_POO_2P
{
    public partial class Form1 : Form
    {
        // Declaro la lista Clientes
        Clientes clientes = new Clientes();
        Prestamos prestamos = new Prestamos();
        // Declaro el evento que se utilizará para cambiar la fecha del sistema;
        public event EventHandler OnCambioFechaSistema;
        public static DateTime FechaSistema;
        public static string SetValueForText1 = "";
        public static List<Prestamo> staticPrestamos;
        public Form1()
        {
            InitializeComponent();
            // Suscribo el método para que se ejecute cada vez que se llama al evento.
            OnCambioFechaSistema += SetFechaSistema;
        }

        private void SetFechaSistema(object sender, EventArgs e)
        {
            // Hacemos un try
            try
            {
                // chequeo si hay algo escrito en el campo de texto
                if (textBoxFechaSistema.TextLength > 0)
                {
                    FechaSistema = Convert.ToDateTime(textBoxFechaSistema.Text);
                } else
                {
                    // si no hay nada escrito, uso la fecha de hoy del sistema
                    FechaSistema = FechaSistema != null ? FechaSistema : DateTime.Now;
                }
                // actualizo todas las fechas en la lista de prestamo
                foreach (var pres in prestamos.ListPrestamos)
                {
                    pres.FechaSistema = FechaSistema;
                }
                lblFechaSistema.Visible = true;
                if (prestamos.ListPrestamos.Count != 0)
                {
                    staticPrestamos = Clona<Prestamo>.NuevoClon(prestamos.ListPrestamos);
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                }
                
            }
            catch (Exception ex)
            {
                // Lo más probable es que falle la conversión de fecha
                
                MessageBox.Show(ex.Message);
                throw new Exception("No se pudo convertir la fecha. Ingrese un formato válido. Por ejemplo dd/mm/yyyy");
            }
        }

        private void BtnAltaCliente_Click(object sender, EventArgs e)
        {
            // Abrimos un try catch. El primer try ingresa al metodo para crear un nuevo cliente
            try
            {
                clientes.Nuevo();
                MostrarDatagridClientes();
            }
            catch (ExIdRepetido ex)
            {
                // Nos muestra el mensaje en caso de ser un id repetido
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarDatagridClientes()
        {
            datagridClientes.DataSource = new List<Cliente>();
            datagridClientes.Refresh();
            if (clientes.ListClientes.Count() > 0)
            {
                datagridClientes.DataSource = clientes.ListClientes;
                datagridClientes.Refresh();
            }
        }

        // Se usa este botón para que todo el sistema recalcule en base a la fecha del textbox
        private void BtnRecalcular_Click(object sender, EventArgs e)
        {
            // Hacemos un try
            try
            {
                // chequeo si hay algo escrito en el campo de texto
                if (textBoxFechaSistema.TextLength > 0)
                {
                    FechaSistema = Convert.ToDateTime(textBoxFechaSistema.Text);
                }
                else
                {
                    // si no hay nada escrito, uso la fecha de hoy del sistema
                    FechaSistema = FechaSistema != null ? FechaSistema : DateTime.Now;
                }
                // actualizo todas las fechas en la lista de prestamo
                foreach (var pres in prestamos.ListPrestamos)
                {
                    pres.FechaSistema = FechaSistema;
                }
                lblFechaSistema.Visible = true;
                if (prestamos.ListPrestamos.Count != 0)
                {
                    staticPrestamos = Clona<Prestamo>.NuevoClon(prestamos.ListPrestamos);
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                // Lo más probable es que falle la conversión de fecha

                MessageBox.Show(ex.Message);
                throw new Exception("No se pudo convertir la fecha. Ingrese un formato válido. Por ejemplo dd/mm/yyyy");
            }

            textBoxFechaSistema.Text = FechaSistema.ToString("dd'/'MM'/'yyyy");

            //Llamo al evento del cambio de fecha de sistema
            /*try
            {
                OnCambioFechaSistema?.Invoke(this, EventArgs.Empty);
                
                foreach (var item in prestamos.ListPrestamos)
                {
                    item.Update(FechaSistema);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void BtnModificarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente clienteSeleccionado = (Cliente)datagridClientes.SelectedCells[0].OwningRow.DataBoundItem;
                clientes.Modificar(clienteSeleccionado);
                MostrarDatagridClientes();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnBajaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente clienteSeleccionado = (Cliente)datagridClientes.SelectedCells[0].OwningRow.DataBoundItem;
                clientes.Baja(clienteSeleccionado);
                MostrarDatagridClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAltaPrestamoPesos_Click(object sender, EventArgs e)
        {
            // Abrimos un try catch. El primer try ingresa al metodo para crear un nuevo Prestamo
            try
            {
                if (textBoxFechaSistema.Text == "") { throw new Exception("No hay fecha de sistema"); }
                prestamos.NuevoPresPesos();
                MostrarDatagridPrestamo();
            }
            catch (ExIdRepetido ex)
            {
                // Nos muestra el mensaje en caso de ser un id repetido
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarDatagridPrestamo()
        {
            try
            {
               
                // Genero mis listas y mis vistas correspondientes
                List<Prestamo> listNoPagados = (from prestamo in prestamos.ListPrestamos where prestamo.EstaPagado == false select prestamo).ToList<Prestamo>();
                List<Prestamo> listPagados = (from prestamo in prestamos.ListPrestamos where prestamo.EstaPagado == true select prestamo).ToList<Prestamo>();

                // Estos son los que tienen que ver con el cliente seleccionado
                if (datagridClientes.SelectedCells.Count > 0)
                {
                    Cliente clienteSeleccionado = (Cliente)datagridClientes.SelectedCells[0].OwningRow.DataBoundItem;
                    List<Prestamo> listNoPagadosCliente = (from prestamo in prestamos.ListPrestamos where prestamo.EstaPagado == false && prestamo.cliente == clienteSeleccionado select prestamo).ToList();
                    List<Prestamo> listPagadosCliente = (from prestamo in prestamos.ListPrestamos where prestamo.EstaPagado == true && prestamo.cliente == clienteSeleccionado select prestamo).ToList();
                    List<Prestamo> listVencidosCliente = (from prestamo in prestamos.ListPrestamos where prestamo.EstaVencido == true && prestamo.cliente == clienteSeleccionado select prestamo).ToList();
                    VistaPrestamoTodos vistaPrestamoTodos = new VistaPrestamoTodos(prestamos.ListPrestamos);
                    VistaPrestamoTodos vistaPrestamoPagados = new VistaPrestamoTodos(listPagados);
                    VistaPrestamoTodos vistaPrestamoNoPagados = new VistaPrestamoTodos(listNoPagados);
                    VistaPrestamoTodos vistaPagadosCliente = new VistaPrestamoTodos(listPagadosCliente);
                    VistaPrestamoTodos vistaNoPagadosCliente = new VistaPrestamoTodos(listNoPagadosCliente);
                    VistaPrestamoTodos vistaVencidosCliente = new VistaPrestamoTodos(listVencidosCliente);



                    // Inicializo las grillas
                    datagridPrestamos.DataSource = new List<VistaPrestamoTodos>();
                    datagridNoPagados.DataSource = new List<VistaPrestamoTodos>();
                    datagridPagados.DataSource = new List<VistaPrestamoTodos>();
                    dgClPrestamosNoPagados.DataSource = new List<VistaPrestamoTodos>();
                    dgClPrestamosPagados.DataSource = new List<VistaPrestamoTodos>();
                    dgClPrestamosVencidos.DataSource = new List<VistaPrestamoTodos>();

                    // Hago refresh en todas
                    datagridPrestamos.Refresh();
                    datagridNoPagados.Refresh();
                    datagridPagados.Refresh();
                    dgClPrestamosNoPagados.Refresh();
                    dgClPrestamosVencidos.Refresh();
                    dgClPrestamosPagados.Refresh();

                    // Actualizo los datasources

                    if (listNoPagados.Count() > 0)
                    {
                        datagridNoPagados.DataSource = vistaPrestamoNoPagados.ReturnVista();
                        datagridNoPagados.Refresh();
                    }
                    if (listPagados.Count() > 0)
                    {
                        datagridPagados.DataSource = vistaPrestamoPagados.ReturnVista();
                        datagridPagados.Refresh();
                    }
                    if (listNoPagadosCliente.Count() > 0)
                    {
                        dgClPrestamosNoPagados.DataSource = vistaNoPagadosCliente.ReturnVista();
                        dgClPrestamosNoPagados.Refresh();
                    }
                    if (listPagadosCliente.Count() > 0)
                    {
                        dgClPrestamosPagados.DataSource = vistaPagadosCliente.ReturnVista();
                        dgClPrestamosPagados.Refresh();
                    }
                    if (listVencidosCliente.Count() > 0)
                    {
                        dgClPrestamosVencidos.DataSource = vistaVencidosCliente.ReturnVista();
                        dgClPrestamosVencidos.Refresh();
                    }
                }

                if (prestamos.ListPrestamos.Count() > 0)
                {
                    datagridPrestamos.DataSource = vistaPrestamoTodos.ReturnVista();
                    datagridPrestamos.Refresh();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAltaPrestamoDolares_Click(object sender, EventArgs e)
        {
            // Abrimos un try catch. El primer try ingresa al metodo para crear un nuevo Prestamo
            try
            {
                if (textBoxFechaSistema.Text == "") { throw new Exception("No hay fecha de sistema"); }
                prestamos.NuevoPresDolares();
                MostrarDatagridPrestamo();
            }
            catch (ExIdRepetido ex)
            {
                // Nos muestra el mensaje en caso de ser un id repetido
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBajaPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                Prestamo prestamo = ((VistaPrestamoTodos)datagridPrestamos.SelectedCells[0].OwningRow.DataBoundItem).ReturnOriginal() ;
                prestamos.Baja(prestamo);
                MostrarDatagridPrestamo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnModifPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                Prestamo prestamo = ((VistaPrestamoTodos)datagridPrestamos.SelectedCells[0].OwningRow.DataBoundItem).ReturnOriginal();
                prestamos.Modificar(prestamo);
                MostrarDatagridPrestamo();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                Prestamo prestamoSeleccionado = ((VistaPrestamoTodos)datagridPrestamos.SelectedCells[0].OwningRow.DataBoundItem).ReturnOriginal();
                Cliente clienteSeleccionado = (Cliente)datagridClientes.SelectedCells[0].OwningRow.DataBoundItem;
                clienteSeleccionado.AsignarPrestamo(prestamoSeleccionado);
                MostrarDatagridClientes();
                MostrarDatagridPrestamo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void datagridClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarDatagridPrestamo();
        }

        private void BtnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                Prestamo prestamoSeleccionado = ((VistaPrestamoTodos)dgClPrestamosNoPagados.SelectedCells[0].OwningRow.DataBoundItem).ReturnOriginal();
                prestamoSeleccionado.EstaPagado = true;
                MostrarDatagridPrestamo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public class Clona<T> where T : ICloneable
    {
        static public List<T> NuevoClon(List<T> pLista)
        {
            List<T> _l = new List<T>();
            foreach (T _a in pLista)
            {
                _l.Add((T)_a.Clone());
            }
            return _l;
        }
    }

    public class utVistaprestamo<T> where T : VistaPrestamo
    {
        public void CargarTablas(T datagrid)
        {

        }
    }
}
