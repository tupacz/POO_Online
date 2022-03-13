using System;
using System.Collections.Generic;

namespace ZULETA_POO_2P
{
    public class VistaPrestamoTodos : VistaPrestamo
    {
        private List<Prestamo> listPrestamos { get; set; }
        private Prestamo prestamoOriginal;

        public VistaPrestamoTodos(List<Prestamo> listPrestamos)
        {
            this.listPrestamos = listPrestamos;
        }

        public VistaPrestamoTodos(Prestamo prest)
        {
            try
            {
                Id = prest.Id;
                CapitalSolicitado = prest.CapitalSolicitado;
                PlazoMeses = prest.PlazoMeses;
                DineroARetornar = prest.DineroARetornar();
                TasaDeInteres = prest.TasaDeInteres;
                InteresTotal = prest.InteresTotal();

                if (prest.cliente != null)
                {
                    Nombre = prest.cliente.Nombre;
                    Apellido = prest.cliente.Apellido;
                    Dni = prest.cliente.Dni;
                }
                prestamoOriginal = prest;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }

        internal object ReturnVista()
        {
            List<VistaPrestamoTodos> vp = new List<VistaPrestamoTodos>();
            foreach (var prest in listPrestamos)
            {
                vp.Add(new VistaPrestamoTodos(prest));
            }
            return vp;
        }

        internal Prestamo ReturnOriginal()
        {
            return prestamoOriginal;
        }
    }
}