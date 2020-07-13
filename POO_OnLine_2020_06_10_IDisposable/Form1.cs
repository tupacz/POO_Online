using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO_OnLine_2020_06_10_IDisposable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Alumno A = new Alumno();
            // Se realizan todas las operaciones con el alumno
            if (A is IDisposable) { A.Dispose(); }
            A = null;        
        }
    }
    public class Alumno : IDisposable
    {
        bool DisposeOk = false;
        ~Alumno()
        {
            if(!DisposeOk)
            {/*Destruir la referencia al archivo*/}
        }
        public void Dispose()
        {
           
            // Destruyo la referencia al archivo
            MessageBox.Show("Se ejecutó el Dispose !!!!!");
            DisposeOk = true;
        }
    }

}
