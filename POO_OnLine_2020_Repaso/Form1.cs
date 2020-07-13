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

namespace POO_OnLine_2020_Repaso
{
    public partial class Form1 : Form
    {
        GestorDescuento _gd;
        public Form1()
        {
            InitializeComponent();
            _gd = new GestorDescuento();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
         
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try 
            { 
            Descuento _d;
            if (radioButton2.Checked)
                { _d = new DescuentoProductoNacional(Decimal.Parse(Interaction.InputBox("Importe: ")),
                                                     Decimal.Parse(Interaction.InputBox("Porcentaje: ")),
                                                     Decimal.Parse(Interaction.InputBox("Dto. Promoción: "))); 
                }
            else
                { _d = new DescuentoProductoImportado(Decimal.Parse(Interaction.InputBox("Importe: ")),
                                                     Decimal.Parse(Interaction.InputBox("Porcentaje: ")),
                                                     Decimal.Parse(Interaction.InputBox("Dto. Promoción: "))); 
                }
                _gd.AgregarDescuento(_d);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _gd.RetornaDescuentos();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

                

        }
    }
    public class GestorDescuento
    {
        List<Descuento> _ld;

       decimal x;

        public GestorDescuento() { _ld = new List<Descuento>(); }

        public void AgregarDescuento(Descuento pDescuento)
        {
            try
            {
                Descuento _d;
                if (pDescuento is DescuentoProductoNacional)
                {
                    _d = new DescuentoProductoNacional(pDescuento.Importe, pDescuento.Porcentaje, ((DescuentoProductoNacional)pDescuento).Dto_Promo);
                }
                else
                {
                    _d = new DescuentoProductoImportado(pDescuento.Importe, pDescuento.Porcentaje, ((DescuentoProductoImportado)pDescuento).Dto_Region_Pocentaje);
                }
                _ld.Add(_d);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
        public List<VistaDescuento> RetornaDescuentos()
        {
            List<VistaDescuento> _lvd = new List<VistaDescuento>();
            foreach (Descuento _d in _ld)
            {
                if (_d is DescuentoProductoNacional)
                {
                    DescuentoProductoNacional _dpn = (DescuentoProductoNacional)_d;
                    _lvd.Add(new VistaDescuento(_dpn.Importe, _dpn.Porcentaje, "Nacional", _dpn.Dto_Promo, 0, _dpn.ImporteAPagar()));
                }
                else
                {
                    DescuentoProductoImportado _dpi = (DescuentoProductoImportado)_d;
                    _lvd.Add(new VistaDescuento(_dpi.Importe, _dpi.Porcentaje, "Importado", 0, _dpi.Dto_Region_Pocentaje, _dpi.ImporteAPagar()));
                }

            }
            return _lvd;
        }
    }
    public class VistaDescuento
        {
            public VistaDescuento(Decimal pImporte,Decimal pPorcentaje,String pNacImp,Decimal pPromo, Decimal pRegion, Decimal pImpPagar )
            { Importe = pImporte;Porcentaje = pPorcentaje;Nac_Imp = pNacImp;Dto_Promo = pPromo;Dto_Region = pRegion;Imp_a_Pagar = pImpPagar; }
            public Decimal Importe { get; set; }
            public Decimal Porcentaje { get; set; }
            public String Nac_Imp { get; set; }
            public Decimal Dto_Promo { get; set; }
            public Decimal Dto_Region { get; set; }
            public Decimal Imp_a_Pagar { get; set; }
        }
    public abstract class Descuento
    {
        public Descuento(Decimal pImporte,Decimal pPorcentaje) { Importe = pImporte;Porcentaje = pPorcentaje; }
        public Decimal Importe { get; set; }
        public Decimal Porcentaje { get; set; }

        public abstract Decimal ImporteAPagar();
    }
    public class DescuentoProductoNacional : Descuento
    {
        public DescuentoProductoNacional(Decimal pImporte, Decimal pPorcentaje, Decimal pDtoPromo) : base(pImporte, pPorcentaje)
        { Dto_Promo = pDtoPromo; }
        public Decimal Dto_Promo { get; set; }
        public override decimal ImporteAPagar()
        {
            Decimal _impNetoPagar =   Porcentaje<50 ? Importe * (1-(Porcentaje/100)) : Importe/2;
            if(_impNetoPagar>Importe/2)
            {
                Decimal _impMaxADescontar = _impNetoPagar - Importe/2;
                if (Dto_Promo > _impMaxADescontar) { _impNetoPagar -=_impMaxADescontar; }
                else { _impNetoPagar -= Dto_Promo; }
            }
            return _impNetoPagar; 
        }
    }
    public class DescuentoProductoImportado : Descuento
    {
        public DescuentoProductoImportado(Decimal pImporte, Decimal pPorcentaje, Decimal pDtoRegionPorcentaje) : base(pImporte, pPorcentaje)
        { Dto_Region_Pocentaje = pDtoRegionPorcentaje; }
        public Decimal Dto_Region_Pocentaje { get; set; }
        public override decimal ImporteAPagar()
        {
            Decimal _impNetoPagar = Porcentaje > 60 ? Importe * 0.40m : Importe * (1-(Porcentaje/100));
            if (_impNetoPagar > Importe * 0.40m)
            {
                Decimal _impMaxADescontar = _impNetoPagar - ( Importe * 0.40m);
                if (Importe * (Dto_Region_Pocentaje/100) > _impMaxADescontar) { _impNetoPagar -= _impMaxADescontar; }
                else { _impNetoPagar -= Importe * (Dto_Region_Pocentaje / 100); }
            }
            return _impNetoPagar;
        }
    }
}
