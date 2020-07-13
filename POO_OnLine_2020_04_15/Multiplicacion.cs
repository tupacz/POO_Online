using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace POO_OnLine_2020_04_15
{
    class Multiplicacion : Calculo
    {
        public override decimal Ejecutar()
        {
            try
            {
                Numero1 = Decimal.Parse(Interaction.InputBox("Ingrese el Primer número: "));
                Numero2 = Decimal.Parse(Interaction.InputBox("Ingrese el Segundo número: "));
            }
            catch (Exception ex) {MessageBox.Show(ex.Message); }
            return Numero1 * Numero2;
        }
    }
}
