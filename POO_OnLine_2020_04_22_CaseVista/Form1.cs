using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace POO_OnLine_2020_04_22_CaseVista
{
    public partial class Form1 : Form
    {
        
     
        public Form1()
        {
            InitializeComponent();
        }
        List<Alumno> L;
        AlumnoVista AV;
        Alumno AlumnoSeleccionado;
        private void Form1_Load(object sender, EventArgs e)
        {
            L = new List<Alumno>();
            dataGridView1.DataSource = null;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            AV = new AlumnoVista();
            AlumnoSeleccionado = null;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                L.Add(new Alumno(int.Parse(Interaction.InputBox("Legajo:")),
                                  Interaction.InputBox("Nombre: "),
                                  Interaction.InputBox("Apellido: "),
                                  DateTime.Parse(Interaction.InputBox("Fecha de Alta: ")),
                                  byte.Parse(Interaction.InputBox("Edad: "))));
                Mostar(dataGridView1,L);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }         
        }
        private void Mostar(DataGridView DGV, Object pO)
        {
            DGV.DataSource = null;
            DGV.DataSource = AV.RetornaListaAlumnoVista((List<Alumno>)pO);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                L.Remove(AlumnoSeleccionado);
                Mostar(dataGridView1, L);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                AlumnoSeleccionado = ((AlumnoVista)dataGridView1.SelectedRows[0].DataBoundItem).RetornaAlumnoOrigen();
            }
            catch (Exception) { }
            
        }
    }
    public class AlumnoVista
    {
        private List<AlumnoVista> LV;
        private Alumno AlumnoOrigen;
        public AlumnoVista() {LV = new List<AlumnoVista>();}
        public AlumnoVista(string pA, int pL, Alumno pAlu) { Apellido_Nombre = pA;Legajo = pL;AlumnoOrigen = pAlu;}
        public string Apellido_Nombre { get; set; }
        public int Legajo { get; set; }
        public Alumno RetornaAlumnoOrigen() { return AlumnoOrigen; }
        public List<AlumnoVista> RetornaListaAlumnoVista(List<Alumno> pLA)
        {
            LV.Clear();
            foreach (Alumno A in pLA)
            {
                LV.Add(new AlumnoVista($"{A.Apellido}, {A.Nombre}", A.Legajo,A));
            }
            return LV;
        }

    }
    public class Alumno
    {
        public Alumno(int pL, string pN, string pA, DateTime pF, byte pE)
        { Legajo = pL;Nombre = pN;Apellido = pA;FechaIng = pF;Edad = pE; }
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaIng { get; set; }
        public byte Edad { get; set; }
    }

}
