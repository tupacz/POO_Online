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

namespace PPO_OnLine_2020_Desacoplando_Obj
{
    public partial class Form1 : Form
    {
        Universidad _u;
        public Form1()
        {
            InitializeComponent();
            _u = new Universidad();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView2.MultiSelect = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                Alumno _a = new Alumno(int.Parse(Interaction.InputBox("Legajo: ")));
                if (!_u.ExisteAlumno(_a))
                {
                    _a.Nombre = Interaction.InputBox("Nombre: ");
                    _a.Apellido = Interaction.InputBox("Apellido: ");
                    _u.Agregar(_a);
                    Mostrar(dataGridView1, _u.ListaAlumnos());
                    Mostrar(dataGridView2, _u.ListaAlumnoApellido_Nombre());
                }
                else
                {
                    throw new Exception("El legajo del alumno ya existe");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
                
        }
        private void Mostrar(DataGridView pDGV, object pO)
        {
            pDGV.DataSource = null;pDGV.DataSource = pO;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Alumno _a = new Alumno(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                    _u.Borrar(_a);
                    Mostrar(dataGridView1, _u.ListaAlumnos());
                    Mostrar(dataGridView2, _u.ListaAlumnoApellido_Nombre());
                }
                else
                {
                    throw new Exception("No hay nada para borrar !!!!");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Alumno _a = new Alumno(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()),
                                                     dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), 
                                                     dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                    _a.Nombre = Interaction.InputBox("Nombre: ", "", _a.Nombre);
                    _a.Apellido = Interaction.InputBox("Apellido: ", "", _a.Apellido);
                    _u.Modificar(_a);
                    Mostrar(dataGridView1, _u.ListaAlumnos());
                    Mostrar(dataGridView2, _u.ListaAlumnoApellido_Nombre());
                }
                else
                {
                    throw new Exception("No hay nada para borrar !!!!");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

public class Universidad
{
    List<Alumno> _listaAlumno;
    public Universidad() { _listaAlumno = new List<Alumno>(); }

    public void Agregar(Alumno pAlumno)
    {
        try 
        {
            if (!ExisteAlumno(pAlumno))
            {
                _listaAlumno.Add(new Alumno(pAlumno.Legajo, pAlumno.Nombre, pAlumno.Apellido));
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }

    }
    public void Borrar(Alumno pAlumno)
    {
        try
        {
            if (ExisteAlumno(pAlumno))
            {
                Alumno _alumno= _listaAlumno.Find(x => x.Legajo==pAlumno.Legajo);
                _listaAlumno.Remove(_alumno);
            }
            else
            {
                throw new Exception("El alumno que intenta borrar no existe !!!!!");
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }
    public void Modificar(Alumno pAlumno)
    {
        try
        {
            if (ExisteAlumno(pAlumno))
            {
                Alumno _alumno = _listaAlumno.Find(x => x.Legajo == pAlumno.Legajo);
                _alumno.Nombre=pAlumno.Nombre;
                _alumno.Apellido = pAlumno.Apellido;
            }
            else
            {
                throw new Exception("El alumno que intenta modificar no existe !!!!!");
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }
    public bool ExisteAlumno(Alumno pAlumno)
    {
        bool _aux = true;
        try { _aux=_listaAlumno.Exists(x => x.Legajo == pAlumno.Legajo); }
        catch (Exception ex) { throw new Exception(ex.Message); }
        return _aux;
    }
    public List<Alumno> ListaAlumnos()
    {
        List<Alumno> _auxListaAlumno;
        try 
        {
             _auxListaAlumno = new List<Alumno>();
            foreach (Alumno _a in _listaAlumno)
            {
                _auxListaAlumno.Add(new Alumno(_a.Legajo, _a.Nombre, _a.Apellido));
            }      
        }
        catch (Exception ex) { throw new Exception(ex.Message); }  
        return _auxListaAlumno;
    }
    public List<VistaAlumno> ListaAlumnoApellido_Nombre()
    {
        List<VistaAlumno> _auxListaVistaAlumno;
        try
        {
            _auxListaVistaAlumno = new List<VistaAlumno>();
            foreach (Alumno _a in _listaAlumno)
            {
                _auxListaVistaAlumno.Add(new VistaAlumno(_a));
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
        return _auxListaVistaAlumno;

    }


}
public class VistaAlumno
{
    public VistaAlumno(Alumno pAlumno) { Apellido_Nombre = $"{pAlumno.Apellido}, {pAlumno.Nombre}";}
    public string Apellido_Nombre { get; set; }
}
public class Alumno
{
    public Alumno() { }
    public Alumno(int pLegajo) { Legajo = pLegajo; }
    public Alumno(int pLegajo,string pNombre, string pApellido) : this(pLegajo)
    { Nombre = pNombre;Apellido = pApellido; }

    public int Legajo { get; set; }
    public string Nombre {get;set;}
    public string Apellido { get; set; }
}

