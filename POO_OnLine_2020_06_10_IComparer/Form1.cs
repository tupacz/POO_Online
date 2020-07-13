using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO_OnLine_2020_06_10_IComparer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        IComparer<Persona> _ic;
        private void Form1_Load(object sender, EventArgs e)
        {
            _ic = new Persona.NombreAsc();
            Mostrar();
        }

        private void Mostrar()
        {
            Persona[] _personas = { new Persona("Maria", "Fernandez",22),
                                    new Persona("Ana", "Zabala",44),
                                    new Persona("Ana", "Garcia",33)};
            dataGridView1.DataSource = null; dataGridView1.DataSource = _personas.ToList<Persona>();

            Array.Sort(_personas,_ic);

            dataGridView2.DataSource = null; dataGridView2.DataSource = _personas.ToList<Persona>();



            List<Persona> _personas2 = new List<Persona>() { new Persona("Maria", "Fernandez",22),
                                                             new Persona("Ana", "Zabala",44),
                                                             new Persona("Ana", "Garcia",33)};

            List<Persona> _personas3 = new List<Persona>();
            foreach (Persona _p in _personas2)
            { _personas3.Add(new Persona(_p.Nombre, _p.Apellido, _p.Edad)); }

            _personas3.Sort(_ic);

            dataGridView3.DataSource = null; dataGridView3.DataSource = _personas2;
            dataGridView4.DataSource = null; dataGridView4.DataSource = _personas3;

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            _ic = new Persona.NombreDesc();
            Mostrar();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _ic = new Persona.NombreAsc();
            Mostrar();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _ic = new Persona.ApellidoAsc();
            Mostrar();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            _ic = new Persona.ApellidoDesc();
            Mostrar();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            _ic = new Persona.EdadAsc();
            Mostrar();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            _ic = new Persona.EdadDesc();
            Mostrar();
        }
    }

    public class Persona 
    {
        public Persona(string pNombre, string pApellido, int pEdad) { Nombre = pNombre; Apellido = pApellido; Edad = pEdad; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public class NombreAsc : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                return String.Compare(x.Nombre, y.Nombre);
            }
        }
        public class NombreDesc : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                return String.Compare(x.Nombre, y.Nombre) * -1;
            }
        }
        public class ApellidoAsc : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                return String.Compare(x.Apellido, y.Apellido) ;
            }
        }
        public class ApellidoDesc : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                return String.Compare(x.Apellido,y.Apellido) * -1;
            }
        }
        public class EdadAsc : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                return x.Edad < y.Edad ? -1 : (x.Edad == y.Edad ? 0 : 1);
            }
        }
        public class EdadDesc : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                return x.Edad > y.Edad ? -1 : (x.Edad == y.Edad ? 0 : 1);
            }
        }

    }
}
