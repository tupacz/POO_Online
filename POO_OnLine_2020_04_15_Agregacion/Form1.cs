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

namespace POO_OnLine_2020_04_15_Agregacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Molino M = new Molino();
            MessageBox.Show(M.ToString());
            M = null;
            GC.Collect();

        }
    }

    public class Molino
    {
        Motor M;
        Eje E;
        List<Aspa> List_A;
        public Molino()
        {
            // Creación de las instancias de objetos que Compone Molino
            M = new Motor("BMW", 1200);
            E = new Eje(5);
            List_A = new List<Aspa>();
            Aspa[] Aspas = { new Aspa(10), new Aspa(10), new Aspa(10), new Aspa(10)};
            List_A.AddRange(Aspas);
        }

        ~Molino()
        {
           // Aquí se rompen las referencias a los objetos que compone Molino
            M = null;
            E = null;
            List_A = null;
            MessageBox.Show("Se ejecutó el GC y se rompieron las referencas a los objetos agregados");
        }
        public override string ToString()
        {
            string S = M.ToString() + Constants.vbCrLf;
            S += E.ToString() + Constants.vbCrLf;
            int pesoT = 0;
            foreach (Aspa A in List_A) { pesoT += A.Peso; }
            S += $"Cantidad de Apas: {List_A.Count.ToString()} y el peso total es: {pesoT.ToString()}";           
            return S;
        }
    }

    public class Motor
    {

       public Motor(string pMarca, int pPotencia)
        { Marca = pMarca;Potencia = pPotencia; }
        public string Marca { get; set; }
        public int Potencia { get; set; }

        public override string ToString()
        {
            return $"Motor Marca: {Marca} -- Potencia: {Potencia.ToString()}";
        }
    }

    public class Eje
    {
        public Eje(int pTamano)
        {
            Tamano = pTamano;
        }
        public int Tamano { get; set; }
        public override string ToString()
        {
            return $"El tamaño del eje es: {Tamano.ToString()} metros";
        }
    }

    public class Aspa
    {
        public Aspa(int pPeso)
        {
            Peso = pPeso;
        }
        public int Peso { get; set; }

       
    }
}
