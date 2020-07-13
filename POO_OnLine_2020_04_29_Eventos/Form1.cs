using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO_OnLine_2020_04_29_Eventos
{
    public partial class Form1 : Form
    {
        Calefactor C;
        public Form1()
        {
            InitializeComponent();
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {
            C = new Calefactor();
            C.AltaTemperatura += new EventHandler<InformacionCalefactorEventArgs>(this.SeDesencadenoElEvento);
            C.BajaTemperatura += new EventHandler<InformacionCalefactorEventArgs>(this.SeDesencadenoElEvento);
        }
        private void SeDesencadenoElEvento(object sender, InformacionCalefactorEventArgs e)
        {
            textBox1.BackColor = e.Color; textBox1.Text = e.TemperaturaActual.ToString();
        }
      
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            C.Temperatura = e.NewValue;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton(object sender, EventArgs e)
        {           
            colorDialog1.ShowDialog();
            if (((RadioButton)sender).Name== "radioButton1")
                { C.TemperaturaAlta = colorDialog1.Color; }
            else
                { C.TemperaturaBaja = colorDialog1.Color; }
           ((RadioButton)sender).ForeColor = colorDialog1.Color;
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

       
    }

    public class Calefactor
    {
        private int _temp;
        public event EventHandler<InformacionCalefactorEventArgs> AltaTemperatura;
        public event EventHandler<InformacionCalefactorEventArgs> BajaTemperatura;
        public Color TemperaturaAlta { get; set; }
        public Color TemperaturaBaja { get; set; }
        public int Temperatura
        {
            get { return _temp; }
            set 
            { 
                _temp = value;
                //if (_temp > 100) { if (!(AltaTemperatura == null)) { AltaTemperatura(this, new EventArgs()); } }
                if (_temp > 100) { AltaTemperatura?.Invoke(this, new InformacionCalefactorEventArgs(_temp,TemperaturaAlta)); }
                else { BajaTemperatura?.Invoke(this, new InformacionCalefactorEventArgs(_temp,TemperaturaBaja)); }
            }
        }
    }
    public class InformacionCalefactorEventArgs : EventArgs
    {
        private int _temp; private Color _color;
        public InformacionCalefactorEventArgs(int pTemp, Color pColor)
        { _temp = pTemp;_color = pColor; }
        public int TemperaturaActual { get { return _temp; } }
        public Color Color { get { return _color; } } 

    }

}
