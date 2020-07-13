using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO_OnLine_2020_06_10_Icomparable
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
            Persona[] _personas = { new Persona("Maria", "Fernandez",22),
                                    new Persona("Ana", "Zabala",44),
                                    new Persona("Ana", "Garcia",33)};
            dataGridView1.DataSource = null;dataGridView1.DataSource = _personas.ToList<Persona>();

            Array.Sort(_personas);

            dataGridView2.DataSource = null;dataGridView2.DataSource = _personas.ToList<Persona>();



            List<Persona> _personas2 = new List<Persona>() { new Persona("Maria", "Fernandez",22),
                                                             new Persona("Ana", "Zabala",44),
                                                             new Persona("Ana", "Garcia",33)};

            List<Persona> _personas3 = new List<Persona>();
            foreach (Persona _p in _personas2) 
            { _personas3.Add(new Persona(_p.Nombre, _p.Apellido, _p.Edad)); }

            _personas3.Sort();

            dataGridView3.DataSource = null; dataGridView3.DataSource = _personas2;
            dataGridView4.DataSource = null; dataGridView4.DataSource = _personas3;


        }
    }

    public class Persona : IComparable<Persona>
    {
        public Persona(string pNombre, string pApellido, int pEdad) { Nombre = pNombre;Apellido = pApellido;Edad = pEdad; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public int CompareTo(Persona other)
        {
            return Edad < other.Edad ? -1 : (Edad == other.Edad ? 0 : 1);          
            //return String.Compare(this.Nombre+this.Apellido, other.Nombre+other.Apellido);
        }

     
    }
}
