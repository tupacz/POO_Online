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

namespace POO_OnLIne_2020_04_22_Clases_Anidadas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Persona.Alumno A = new Persona.Alumno(Interaction.InputBox("Nombre del alumno: "),
                                              Interaction.InputBox("Apellido del alumno: "),
                                              int.Parse(Interaction.InputBox("Legajo del alumno: ")));
                Persona.Profesor P = new Persona.Profesor(Interaction.InputBox("Nombre del profesor: "),
                                                          Interaction.InputBox("Apellido del profesor: "),
                                                          Interaction.InputBox("DNI del profesor: "));
                MessageBox.Show($"{A.ToString()}\n\n{P.ToString()}");

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }  
            
    }
    public abstract class Persona
    {
        public Persona(string pNombre,string pApellido)
        {
            Nombre = pNombre; Apellido = pApellido;
        }
        public string Nombre { get; set; }
        public string Apellido { get; set; }



        public class Alumno : Persona
        {
            public Alumno(string pNombre, string pApellido, int pLegajo) : base(pNombre,pApellido)
            {
                Legajo = pLegajo;
            }
            public int Legajo { get; set; }
            public override string ToString()
            {
                return $"El alumno {Nombre} {Apellido} se lo identifica por:\nLegajo: {Legajo}";
            }
        }
        public class Profesor : Persona
        {

            public Profesor(string pNombre, string pApellido,string pDNI) : base(pNombre, pApellido)
            {
                DNI = pDNI;
            }
            public string DNI { get; set; }

            public override string ToString()
            {
                return $"El profesor {Nombre} {Apellido} posee el siguiente documento\nDNI: {DNI}";
            }
        }

    }
  


}
