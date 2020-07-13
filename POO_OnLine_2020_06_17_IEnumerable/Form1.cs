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
using Microsoft.VisualBasic;

namespace POO_OnLine_2020_06_17_IEnumerable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 012 3456 78901
            // 779 0895 06413 5
            // 010 1010 10101
            // Suma de pares: 7+9+8+5+6+1= 36
            // Suma de impares: 7+0+9+0+4+3= 23
            // TImpares * 3= 23 * 3= 69
            // Sumamos Pares + Timpares =  105
            // Buscamos el múltiplo de 10 inmediato superior al nro obtenido en el paso anterior: 110
            // restamos 110-105 = 5 DV

            // 779074214460 7
            // 010101010101
            // I: 16 * 3=48
            // P: 35
            // P + I = 83
            // 90-83= 7
          

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] _leyenda = { "País: ", "Empresa: ", "Producto: ", "DV: " };
            int _c = 0;
            List<Producto> _lp = new List<Producto>();
            _lp.Add( new Producto(1, "Botella de Agua", "7790742144607"));
            _lp.Add( new Producto(2, "Cafiaspirina", "7791234987654"));
            textBox1.Clear();
            foreach(Producto _p in _lp)
            {
                textBox1.Text += $"Id: {_p.Id}     Descripción: {_p.Descripcion}{Constants.vbCrLf}";
                foreach (string _s in _p)
                {
                    textBox1.Text += $"{_leyenda[_c]}{_s}{Constants.vbCrLf}"; _c++;
                }
                textBox1.Text += $"************************{Constants.vbCrLf}";
                _c = 0;
            }
            
        } 
    }

    public class Producto : IEnumerable
    {

        public Producto(int pId,string pDescripcion,string pEAN13) { Id = pId;Descripcion = pDescripcion;EAN13 = pEAN13; }
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string EAN13 { get; set; }
      
        public IEnumerator GetEnumerator()
        {         
            return new ProductoEnumerador1(EAN13);
        }
      
    }

    public class ProductoEnumerador1 : IEnumerator<string>
    {
        string EAN13;
        public ProductoEnumerador1(string pEAN13) { EAN13 = pEAN13; }
       
        string _actual;
        public string Current { get { return _actual; } }


        object IEnumerator.Current
        { get { return Current; } }

        public void Dispose()
        {

        }

        bool _sigue = true;
        int x = 0;
        public bool MoveNext()
        {
            if (EAN13 == "" || EAN13.Length < 13 || x == 4)
            { _sigue = false; _actual = ""; }
            else
            {
                int[] _pos = { 0, 3, 7, 12, 13 };
                //I:0   3    7     12 13
                //  779 0742 14460 7
                //Q:3   4    5     1
                _actual = EAN13.Substring(_pos[x], _pos[x + 1] - _pos[x]);
                x++;
            }
            return _sigue;
        }

        public void Reset()
        {
            x = 0; _actual = ""; EAN13 = "";
        }
    }
}

  


















