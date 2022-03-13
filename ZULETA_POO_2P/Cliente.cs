using System;
using System.Collections.Generic;

namespace ZULETA_POO_2P
{
    public class Cliente
    {
        // Campos de acceso de cliente
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public List<Prestamo> ListPrestamos = new List<Prestamo>();

        internal void BajaPrestamo(Prestamo auxPrestamo)
        {
            try
            {
                Prestamo prestamoABorrar = null;
                if (ListPrestamos.Count > 0)
                {
                    prestamoABorrar = ListPrestamos.Find(x => x.Id == auxPrestamo.Id);
                }
                if (prestamoABorrar != null)
                {
                    ListPrestamos.Remove(prestamoABorrar);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal void AsignarPrestamo(Prestamo prestamoSeleccionado)
        {
            try
            {
                // chequeo si el prestamo no tenía cliente asignado
                if (prestamoSeleccionado.cliente != null)
                {
                    throw new Exception("El préstamo ya tiene un usuario asignado");
                }
                if (prestamoSeleccionado.EstaVencido) throw new Exception("El préstamo está vencido y no se puede asignar");

                //chequeo primero si el prestamoSeleccionado no existe ya para el usuario
                if (ListPrestamos.Find(x => x.Id == prestamoSeleccionado.Id) == null)
                {
                    ListPrestamos.Add(prestamoSeleccionado);
                    prestamoSeleccionado.cliente = this;
                } else {
                    throw new Exception("El préstamo ya se encontraba asignado a este usuario");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
