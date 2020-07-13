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

namespace POO_OnLine_2020_04_15
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

        private void Fx(Calculo pO)
        {
            MessageBox.Show(pO.Ejecutar().ToString());
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Se instancia un objeto Suma y se asigna la refeencia del mismo a la variable S
            Suma S = new Suma(); 
            Fx(S);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            // Se envía al parámetro pO de la función Fx la referencia a una instancia de un objeto Resta
            Fx(new Resta());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Multiplicacion M = new Multiplicacion();
            Fx(M);
        }
    }

    public  abstract class Calculo
    {
        public decimal Numero1 { get; set; }
        public decimal Numero2 { get; set; }
        public abstract decimal Ejecutar(); 
     
    }
    public class Suma : Calculo
    {
        public override decimal Ejecutar()
        {
            try
            {
                Numero1 = Decimal.Parse(Interaction.InputBox("Ingrese el Primer número: "));
                Numero2 = Decimal.Parse(Interaction.InputBox("Ingrese el Segundo número: "));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return Numero1 + Numero2;
        }

    }
    public class Resta: Calculo
    {
        public override decimal Ejecutar()
        {
            try
            {
                Numero1 = Decimal.Parse(Interaction.InputBox("Ingrese el Primer número: "));
                Numero2 = Decimal.Parse(Interaction.InputBox("Ingrese el Segundo número: "));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return Numero1-Numero2;
        }
    }
}
