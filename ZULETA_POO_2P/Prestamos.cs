using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ZULETA_POO_2P
{
    public class Prestamos
    {
        public List<Prestamo> ListPrestamos { get; set; }
        public Prestamos()
        {
            ListPrestamos = new List<Prestamo>();
        }

        string IdString;
        double capital;
        double tasainteres;
        DateTime fechaAdjudicada;
        DateTime fecDevolucion;


        internal void NuevoPresPesos()
        {            
            try
            {
                CargaDeValores();
                // Generamos el préstamo
                PrestamoPesos pres = new PrestamoPesos
                {
                    Id = IdString,
                    CapitalSolicitado = capital,
                    FechaAdjudicada = fechaAdjudicada,
                    FechaDevolucion = fecDevolucion,
                    TasaDeInteres = tasainteres
                };
                ListPrestamos.Add(pres);
            }
            catch (ExIdRepetido ex)
            {
                throw new ExIdRepetido(ex._value);
            }
            catch (ExFormatoPrestamoInvalido ex)
            {
                throw ex;
            }
        }

        // hice esta función que es aplicable a ambos tipos de préstamos
        private void CargaDeValores()
        {
            // Intentamos buscar el formato solicitado con regex
            IdString = Interaction.InputBox("Ingrese el id del préstamo con el siguiente formato [AAAA-000000]: ");
            Regex rgx = new Regex("^([A-Z]{4})-([0-9]{6})$");
            // tiramos exception de prestamo
            if (!(rgx.IsMatch(IdString))) { throw new ExFormatoPrestamoInvalido(); }
            if (ListPrestamos.Exists(x => x.Id == IdString)) { throw new ExIdRepetido(IdString); }
            capital = double.Parse(Interaction.InputBox("Ingrese el capital solicitado: "));
            tasainteres = (double.Parse(Interaction.InputBox("Ingrese la tasa de interes expresado en porcentaje (ej: 50): "))) / 100;
            fechaAdjudicada = DateTime.Parse(Interaction.InputBox("Fecha adjudicada del préstamo: "));
            fecDevolucion = DateTime.Parse(Interaction.InputBox("Fecha de devolución del capital: "));
            if (fechaAdjudicada >= fecDevolucion) { throw new Exception("La fecha adjudicada es mayor a la fecha de devolución."); }
        }

        internal void NuevoPresDolares()
        {
            try
            {
                CargaDeValores();
                // Generamos el préstamo
                PrestamoDolares pres = new PrestamoDolares
                {
                    Id = IdString,
                    // Esto es una conversión en pesos
                    CapitalSolicitado = capital * 100,
                    FechaAdjudicada = fechaAdjudicada,
                    FechaDevolucion = fecDevolucion,
                    TasaDeInteres = tasainteres
                };
                ListPrestamos.Add(pres);
            }
            catch (ExIdRepetido ex)
            {
                throw new ExIdRepetido(ex._value);
            }
            catch (ExFormatoPrestamoInvalido ex)
            {
                throw ex;
            }
        }

        internal void Baja(Prestamo prestamo)
        {
            try
            {
                // Implementamos esta funcion lambda para encontrar al Prestamo
                Prestamo auxPrestamo = ListPrestamos.Find(x => x.Id == prestamo.Id);
                //Borramos todos los prestamos que están anexados a un cliente si es que hay
                if (auxPrestamo.cliente != null)
                {
                    auxPrestamo.cliente.BajaPrestamo(auxPrestamo);
                }

                //Finalmente borramos el cliente
                ListPrestamos.Remove(auxPrestamo);
            }
            catch (Exception) { throw new Exception("Esa persona no existe"); }
        }

        internal void Modificar(Prestamo aux)
        {
            try
            {
                // Primero ingresamos el id del prestamo, que es el que más validaciones tiene
                CargaDeValores();
                aux.Id = IdString;
                aux.FechaDevolucion = fecDevolucion;
                aux.CapitalSolicitado = capital;
            }
            catch (ExFormatoPrestamoInvalido ex) { throw ex; }
            catch (ExIdRepetido ex) { throw new ExIdRepetido(ex._value); }
            catch (Exception) { throw new Exception("Esa persona no existe"); }
        }
    }
}