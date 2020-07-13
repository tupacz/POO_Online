using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO_OnLine_2020_07_01_ListaClonada
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Auto> _la = new List<Auto>() { new Auto("123", "Fiat"),new Auto("987","Ford") };
            List<Auto> _la2 = Clona<Auto>.MiClone(_la);
            _la2.First().Patente = "999";
        }
    }

    public class Auto : ICloneable

    {
        public Auto(string pPatente,string pMarca) { Patente = pPatente;Marca = pMarca; }
        public string Patente { get; set; }
        public string Marca { get; set; }

        public object Clone()
        {
            Auto _a = (Auto)this.MemberwiseClone();
            return _a;
        }
    }
    public class Clona<T> where T: ICloneable
    {
        static public List<T> MiClone(List<T> pLista)
        {
            List<T> _l = new List<T>();
            foreach(T _a in pLista)
            {
                _l.Add((T)_a.Clone());
            }
            return _l;
        }
    }
}
