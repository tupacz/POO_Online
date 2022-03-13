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
    public partial class Form2 : Form
    {
        private Prestamos prestamos;

        public Form2()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<Prestamo> list = (from prestamo in Form1.staticPrestamos where prestamo.EstaVencido == true select prestamo).ToList<Prestamo>();
            VistaPrestamoTodos vistaPrestamoTodos = new VistaPrestamoTodos(list);
            dataGridView1.DataSource = new List<VistaPrestamoTodos>();
            dataGridView1.Refresh();
            dataGridView1.DataSource = vistaPrestamoTodos.ReturnVista();
            dataGridView1.Refresh();
        }
    }
}
