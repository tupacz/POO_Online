using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace POO_OnLine_2020_06_03_Try_Catch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                Calefactor _c = new Calefactor();
                _c.Temperatura = int.Parse(Interaction.InputBox("Ingrese la Temperatura: "));
            }
            catch (AltaTemperaturaException ex)
            {
                MessageBox.Show($"{ex.Message}\nTemperatura Ingresada: {ex.TemperaturaIngresada}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }

    public class Calefactor
    {
        int _t;         
		public int Temperatura
        {
            get { return _t; }
            set
            {
                try
                {
                    if (value > 100)
                    { throw new AltaTemperaturaException(value); }
                    else { _t = value; }
                }            
                catch (AltaTemperaturaException ex)
                {                 
                    
                    throw new AltaTemperaturaException(ex.TemperaturaIngresada); 
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
	 }
    public class AltaTemperaturaException : Exception
    {
        int _t;
        public AltaTemperaturaException(int pTemperaturaIngresada) { TemperaturaIngresada = pTemperaturaIngresada; }
        public int TemperaturaIngresada { get; set; }
        public override string Message => "La temperatura ingresada excede el límites de 100 grados";
    }
}
