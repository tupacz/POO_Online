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

namespace POO_OnLine_2020_05_06_Repaso_Eventos_y_Grilla
{
    public partial class Form1 : Form
    {
        Persona _persona;
        public Form1()
        {
            InitializeComponent();
            _persona = new Persona();
            _persona.CambioApellido += new EventHandler<CambioApellidoEventArgs>(MuestraDatos);
        }
        private void MuestraDatos(object sender, CambioApellidoEventArgs e)
        {
            MessageBox.Show(e.ToString());
        
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _persona.Nombre = Interaction.InputBox("Nombre: ");
            _persona.Apellido = Interaction.InputBox("Apellido: ");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                VistaAuto _a = (VistaAuto)dataGridView1.SelectedRows[0].DataBoundItem;
                _a.Marca = Interaction.InputBox("Marca: ", "", _a.Marca);
                _a.Modelo = Interaction.InputBox("Modelo: ", "", _a.Modelo);
                _persona.ModificarAuto( new Auto(_a.Patente,_a.Marca,_a.Modelo));
                Mostrar(dataGridView1, _persona.RetornaListaAutos());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            try 
            {
                Auto _a = new Auto(Interaction.InputBox("Patente: "),
                                    Interaction.InputBox("Marca: "),
                                    Interaction.InputBox("Modelo: "));
                _persona.AgregarAuto(_a);
                Mostrar(dataGridView1, _persona.ClonListaAuto());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
                
        }
        private void Mostrar(DataGridView pDGV, object pO)
        {
            pDGV.DataSource = null; pDGV.DataSource = pO;   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
               if (_persona.RetornaListaAutos().Count > 0 && dataGridView1.Rows.Count>0)
                {
                VistaAuto _a = (VistaAuto)dataGridView1.SelectedRows[0].DataBoundItem;             
                 _persona.BorrarAuto(new Auto(_a.Patente, _a.Marca, _a.Modelo));
                }
                else { throw new Exception("No hay nada que borrar !!!!"); }
                Mostrar(dataGridView1, _persona.RetornaListaAutos());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
    public class Persona
    {

        List<Auto> _la;
        string _apellido;
        VistaAuto _va;
        public Persona() { _la = new List<Auto>(); _va = new VistaAuto(); }
        public event EventHandler<CambioApellidoEventArgs> CambioApellido;
        public string Nombre { get; set; }
        public string Apellido 
        {
            get { return _apellido; }
            set { _apellido = value; CambioApellido?.Invoke(this, new CambioApellidoEventArgs(this));}
        }
        public void AgregarAuto(Auto pAuto)
        {
            try  {if (!(_la.Exists(x => x.Patente == pAuto.Patente))) {_la.Add(pAuto);}}
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public void BorrarAuto(Auto pAuto)
        {
            try { _la.Remove(_la.Find(x => x.Patente == pAuto.Patente)); }
            catch (Exception ex) { throw new Exception("Intentó borrar un auto inexistente !!!!"); }
        }
        public void ModificarAuto(Auto pAuto)
        {
            try
            {
                if (_la.Exists(x => x.Patente == pAuto.Patente))
                {
                    Auto aux = _la.Find(x => x.Patente == pAuto.Patente);
                    aux.Marca = pAuto.Marca; aux.Modelo = pAuto.Modelo;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public List<VistaAuto> RetornaListaAutos()
        {
            
            
            return _va.RetornaClonListaVistaAuto(_la);
        }
        public List<Auto> ClonListaAuto()
        {       
                List<Auto> _auxLA = new List<Auto>();
                foreach (Auto _a in _la)
                {
                    _auxLA.Add(new Auto(_a.Patente, _a.Marca, _a.Modelo));
                }
                return _auxLA;           
        }
    }
    public class VistaAuto
    {
        public VistaAuto() { }
        public VistaAuto(string pPatente, string pMarca, string pModelo) { Patente = pPatente; Marca = pMarca; Modelo = pModelo; }
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public List<VistaAuto> RetornaClonListaVistaAuto(List<Auto> pLA)
        {
            List<VistaAuto> _auxLA = new List<VistaAuto>();
            foreach (Auto _a in pLA)
            {
                _auxLA.Add(new VistaAuto(_a.Patente, _a.Marca, _a.Modelo));
            }       
            return _auxLA;
        }

    }

    public class CambioApellidoEventArgs : EventArgs
    {
        Persona _persona;
        public CambioApellidoEventArgs(Persona pPersona)
        { _persona = pPersona; }
        public override string ToString()
        {
            return $"{_persona.Apellido}, {_persona.Nombre}";
        }
    }
    public class Auto
    {
        public Auto(string pPatente,string pMarca,string pModelo) { Patente = pPatente; Marca = pMarca;Modelo = pModelo; }
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }


    }
}
