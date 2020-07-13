using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace _POO_OnLine_2020_05_06_TPR_03
{
    public partial class Form1 : Form
    {
        private Empresa _empresa;
        private VistaAuto _vistaAuto;
        public Form1()
        {
            InitializeComponent();

        }
        #region "Funciones suscriptas a eventos"
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ConfiguraGrilla(new List<DataGridView>() { dataGridView1, dataGridView2,dataGridView3,dataGridView4 });
                VisibilidadBotones(0, dataGridView1); VisibilidadBotones(0, dataGridView2);
                _empresa = new Empresa();
                _vistaAuto = new VistaAuto();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Persona _auxPersona = new Persona(Interaction.InputBox("DNI: "), "", "");
                if (!_empresa.PersonaExiste(_auxPersona))
                {
                    IngresaNombreApellido(_auxPersona);
                }
                else
                { throw new Exception("El DNI ingresado ya existe !!!!"); }       
                _empresa.AgregarPersona(_auxPersona);
                Mostrar(dataGridView1, _empresa.RetornaListaPersonas());
                VisibilidadBotones(_empresa.RetornaListaPersonas().Count, dataGridView1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Persona _persona= (Persona)dataGridView1.SelectedRows[0].DataBoundItem;
                if (_persona.CantidadDeAutos() > 0) { foreach(Auto _a in _persona.ListaDeAutos()) { _a.AsignaDuexo(null); } }
                _empresa.BorrarPersona(_persona);
                Mostrar(dataGridView1, _empresa.RetornaListaPersonas());
                if (dataGridView1.Rows.Count > 0)
                    Mostrar(dataGridView3, ((Persona)dataGridView1.SelectedRows[0].DataBoundItem).ListaDeAutos().ToList<Auto>());
                else Mostrar(dataGridView3, null);
                Mostrar(dataGridView4, _vistaAuto.RetornaVistaAuto(_empresa.RetornaListaAutos()));
                VisibilidadBotones(_empresa.RetornaListaPersonas().Count, dataGridView1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Persona _auxPersona = ((Persona)dataGridView1.SelectedRows[0].DataBoundItem);
                if (!(_auxPersona is null))
                {
                    IngresaNombreApellido(_auxPersona);
                }
                Mostrar(dataGridView1, _empresa.RetornaListaPersonas());
                Mostrar(dataGridView4, _vistaAuto.RetornaVistaAuto(_empresa.RetornaListaAutos()));

                VisibilidadBotones(_empresa.RetornaListaPersonas().Count, dataGridView1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        #endregion

        #region "Funciones Privadas de servivio"
        private void IngresaNombreApellido(Persona _auxPersona)
        {
            _auxPersona.Nombre = Interaction.InputBox("Nombre: ", "", _auxPersona.Nombre);
            _auxPersona.Apellido = Interaction.InputBox("Apellido: ", "", _auxPersona.Apellido);
        }
        private void IngresaDatosAuto(Auto _auxAuto)
        {
            try
            {
                _auxAuto.Marca = Interaction.InputBox("Marca: ", "", _auxAuto.Marca);
                _auxAuto.Modelo = Interaction.InputBox("Modelo: ", "", _auxAuto.Modelo);
                _auxAuto.Axo = Interaction.InputBox("Año: ", "", _auxAuto.Axo);
                _auxAuto.Precio = decimal.Parse(Interaction.InputBox("Precio: ", "", _auxAuto.Precio.ToString()));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


        }
        private void Mostrar(DataGridView pDGV, object pQueMuestro)
        { pDGV.DataSource = null; pDGV.DataSource = pQueMuestro;
            if (((DataGridView)pDGV).Name == "dataGridView1" && (((DataGridView)pDGV).Rows.Count > 0))
                dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void VisibilidadBotones(int pCantidad, DataGridView pGrilla)
        {
            if (pGrilla.Name == "dataGridView1" && pCantidad == 0) { button2.Visible = false; button3.Visible = false; }
            if (pGrilla.Name == "dataGridView1" && pCantidad > 0) { button2.Visible = true; button3.Visible = true; }
            if (pGrilla.Name == "dataGridView2" && pCantidad == 0) { button5.Visible = false; button6.Visible = false; }
            if (pGrilla.Name == "dataGridView2" && pCantidad > 0) { button5.Visible = true; button6.Visible = true; }


        }
        private void ConfiguraGrilla(List<DataGridView> _pLDGV)
        {
            foreach (DataGridView _dataGridView in _pLDGV)
            {
                _dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                _dataGridView.MultiSelect = false;
                _dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
                _dataGridView.EnableHeadersVisualStyles = false;
                _dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
                _dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                _dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
                _dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.DarkSlateBlue;
                _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                _dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Auto _auxAuto = new Auto(Interaction.InputBox("Patente: "), "", "", "", 0);
                if (!_empresa.AutoExiste(_auxAuto))
                {
                    IngresaDatosAuto(_auxAuto);
                }
                else
                { throw new Exception("La paternte ingresada ya existe !!!!"); }
                _empresa.AgregarAuto(_auxAuto);
                Mostrar(dataGridView2, _empresa.RetornaListaAutos());
                Mostrar(dataGridView4, _vistaAuto.RetornaVistaAuto(_empresa.RetornaListaAutos()));
                VisibilidadBotones(_empresa.RetornaListaAutos().Count, dataGridView2);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Auto _auto = (Auto)dataGridView2.SelectedRows[0].DataBoundItem;
               
                if (!(_auto.Duexo() is null))  { _auto.Duexo().BorraAuto(_auto); }
                _empresa.BorrarAuto(_auto);
                Mostrar(dataGridView2, _empresa.RetornaListaAutos());
                if (dataGridView2.Rows.Count > 0 && dataGridView3.Rows.Count>0)
                     Mostrar(dataGridView3, ((Persona)dataGridView1.SelectedRows[0].DataBoundItem).ListaDeAutos().ToList<Auto>());
                else Mostrar(dataGridView3, null);
                Mostrar(dataGridView4, _vistaAuto.RetornaVistaAuto(_empresa.RetornaListaAutos()));
                VisibilidadBotones(_empresa.RetornaListaAutos().Count, dataGridView2);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Auto _auxAuto = (Auto)dataGridView2.SelectedRows[0].DataBoundItem;
                if (!(_auxAuto is null))
                {
                    IngresaDatosAuto(_auxAuto);
                }
                Mostrar(dataGridView2, _empresa.RetornaListaAutos());
                if (dataGridView1.Rows.Count > 0)
                    Mostrar(dataGridView3, ((Persona)dataGridView1.SelectedRows[0].DataBoundItem).ListaDeAutos().ToList<Auto>());
                else
                    Mostrar(dataGridView3, null);
               Mostrar(dataGridView4, _vistaAuto.RetornaVistaAuto(_empresa.RetornaListaAutos()));
                VisibilidadBotones(_empresa.RetornaListaAutos().Count, dataGridView2);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                // Se verifica que existe fila seleccionada de la grilla 1
                if (dataGridView1.Rows.Count > 0)
                {
                    // Se toma la persona que corresponde a la fila seleccionada en la grilla 1
                    Persona _auxPersona = ((Persona)dataGridView1.SelectedRows[0].DataBoundItem);
                    // Se verifica que existe fila seleccionada de la grilla 2
                    if (dataGridView2.Rows.Count > 0)
                    {
                        // Se toma el auto que corresponde a la fila seleccionada en la grilla 2
                        Auto _auxAuto = (Auto)dataGridView2.SelectedRows[0].DataBoundItem;
                        // Se verifica si el auto seleccionado tiene dueño
                        if (_auxAuto.Duexo() == null)
                        {
                            _auxPersona.AsignaAuto(_auxAuto);
                            _auxAuto.AsignaDuexo(_auxPersona);
                            Mostrar(dataGridView3, _auxPersona.ListaDeAutos().ToList<Auto>());
                            Mostrar(dataGridView4, _vistaAuto.RetornaVistaAuto(_empresa.RetornaListaAutos()));
                        }
                        else throw new Exception("El auto ya está asignado !!!");
                    }
                    else throw new Exception("No existen autos selecionadas !!!");
                }
                else throw new Exception("No existen personas selecionadas !!!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Mostrar(dataGridView3, ((Persona)dataGridView1.SelectedRows[0].DataBoundItem).ListaDeAutos().ToList<Auto>());
            }
            catch (Exception) { }
        
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Se verifica que existe fila seleccionada de la grilla 1
            if (dataGridView1.Rows.Count > 0)
            {
                // Se toma la persona que corresponde a la fila seleccionada en la grilla 1
                Persona _auxPersona = ((Persona)dataGridView1.SelectedRows[0].DataBoundItem);
                // Se verifica que existe fila seleccionada de la grilla 2
                if (dataGridView2.Rows.Count > 0)
                {
                    // Se toma el auto que corresponde a la fila seleccionada en la grilla 2
                    Auto _auxAuto = (Auto)dataGridView2.SelectedRows[0].DataBoundItem;
                    if (_auxPersona.ListaDeAutos().Exists(x => x.Equals(_auxAuto))) 
                    { 
                        _auxPersona.BorraAuto(_auxAuto);_auxAuto.AsignaDuexo(null);
                        Mostrar(dataGridView3, _auxPersona.ListaDeAutos().ToList<Auto>());
                        Mostrar(dataGridView4, _vistaAuto.RetornaVistaAuto(_empresa.RetornaListaAutos()));
                    }
                }
            }
        }

        private void ActualizaValorAutosEnGUI(object sender, EventArgs e)
        {
            try
            {
               textBox1.Text= ((Persona)dataGridView1.SelectedRows[0].DataBoundItem).ValorAutos().ToString();
            }
            catch (Exception) { textBox1.Text = "0"; }
           
        }

       
    }
}
    public class Empresa
    {
        #region "Campos"
        private List<Persona> _lPersonas;
        private List<Auto> _lAutos;
        #endregion
        #region "Contructores"
        public Empresa() { _lPersonas = new List<Persona> (); _lAutos = new List<Auto>(); }
        #endregion
        #region "Propiedades"
        #endregion
        #region "Métodos"
        public List<Persona> RetornaListaPersonas() {return _lPersonas;}
        public List<Auto> RetornaListaAutos() {return _lAutos;}

        // True= Existe DNI -- False= No existe DNI
        public bool PersonaExiste(Persona pPersona)
        {  return _lPersonas.Exists(x => x.DNI == pPersona.DNI); }
        public void AgregarPersona(Persona pPersona)
        {
            try
            {
                if (!PersonaExiste(pPersona)) { _lPersonas.Add(pPersona); }
                else { throw new Exception("El DNI ingresado ya existe !!!!"); }
            }
            catch (Exception ex) {throw new Exception(ex.Message); }
        }
        public void BorrarPersona(Persona pPersona)
        {
            try
            { _lPersonas.Remove(pPersona);}
            catch (Exception ex) { throw new Exception(ex.Message) ; }
        }

        // True= Existe Patente -- False= No existe Patente
        public bool AutoExiste(Auto pAuto)
        {
            return _lAutos.Exists(x => x.Patente == pAuto.Patente);
        }
        public void AgregarAuto(Auto pAuto)
        {
            try
            {
                if (!AutoExiste(pAuto)) { _lAutos.Add(pAuto); }
                else { throw new Exception("La patente ingresada ya existe !!!!"); }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public void BorrarAuto(Auto pAuto)
        {
            try
            { _lAutos.Remove(pAuto); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        #endregion
        #region "Destructor"
        #endregion
    }
    public class Persona
    {
        #region "Campos"
        private List<Auto> _lAutos;
        #endregion
        #region "Contructores"
        public Persona() { _lAutos = new List<Auto>(); }
        public Persona(string pDNI,string pNombre,string pApellido) : this() 
        { DNI = pDNI;Nombre = pNombre;Apellido = pApellido; }
        #endregion
        #region "Propiedades"
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        #endregion
        #region "Métodos"
        public List<Auto> ListaDeAutos()
        { return _lAutos; }
        public int CantidadDeAutos()
        { return _lAutos.Count; ; }
        public decimal ValorAutos() { return _lAutos.Sum(x => x.Precio); }

        public void AsignaAuto(Auto pAuto) { _lAutos.Add(pAuto); }
        public void BorraAuto(Auto pAuto) { _lAutos.Remove(pAuto); }
        #endregion
        #region "Destructor"
        ~Persona() { _lAutos = null;MessageBox.Show($"El DNI de la persona es: {DNI}"); }
	
        #endregion
    }
    public class Auto
    {
        #region "Campos"
        Persona _duexo;
        #endregion
        #region "Contructores"
        public Auto() { _duexo = null; }
        public Auto(string pPatente,string pMarca,string pModelo,string pAxo,decimal pPrecio) : this()
            { Patente = pPatente;Marca = pMarca;Modelo = pModelo;Axo = pAxo;Precio = pPrecio; }
        #endregion
        #region "Propiedades"
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Axo { get; set; }
        public decimal Precio { get; set; }
        #endregion
        #region "Métodos"
        public Persona Duexo() { return _duexo; }
        public void AsignaDuexo(Persona pDuexo) { _duexo=pDuexo; }
        #endregion
        #region "Destructor"
        ~Auto() { MessageBox.Show($"La patente del auto es: {this.Patente}"); }
        #endregion



    }

public class VistaAuto
{
    //Marca, Año, Modelo, Patente, DNI del dueño, “Apellido, Nombre”

    #region "Campos"
    List<VistaAuto> _listaVistaAuto;
    #endregion
    #region "Contructores"
    public VistaAuto() { _listaVistaAuto = new List<VistaAuto>(); }
    private VistaAuto(string pMarca,string pAxo,string pModelo,string pPatente,string pDNI, string pApellidoNomnre) 
            { Marca = pMarca;Axo = pAxo;Modelo = pModelo;Patente = pPatente;DNI = pDNI;Apellido_Nombre = pApellidoNomnre; }
    #endregion
    #region "Propiedades"
    public string Marca { get; set; }
    public string Axo { get; set; }
    public string Modelo { get; set; }
    public string Patente { get; set; }
    public string DNI { get; set; }
    public string  Apellido_Nombre { get; set; }
    #endregion
    #region "Métodos"
    public List<VistaAuto> RetornaVistaAuto(List<Auto> pListaAuto)
    {
        _listaVistaAuto.Clear();
        foreach (Auto _a in pListaAuto)
        {
            _listaVistaAuto.Add(new VistaAuto(_a.Marca, _a.Axo, _a.Modelo, _a.Patente, (_a.Duexo() is null?"":_a.Duexo().DNI), $"{( _a.Duexo() is null ? "": _a.Duexo().Apellido)}{ (_a.Duexo() is null ? "":",")} {(_a.Duexo() is null ? "" : _a.Duexo().Nombre)}"));
        }
        return _listaVistaAuto;
    }
    #endregion
    #region "Destructor"

    #endregion


}

