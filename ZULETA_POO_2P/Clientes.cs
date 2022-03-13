using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZULETA_POO_2P
{
    public class Clientes
    {
        public List<Cliente> ListClientes { get; set; }

        public Clientes() {
            ListClientes = new List<Cliente>();
        }

        internal void Nuevo()
        {
            try
            {
                Cliente c = new Cliente
                {
                    Dni = int.Parse(Interaction.InputBox("Ingrese el DNI del nuevo cliente: ")),
                    Nombre = Interaction.InputBox("Ingrese el Nombre del nuevo cliente: "),
                    Apellido = Interaction.InputBox("Ingrese el Apellido del nuevo cliente: ")
                };
                if (ListClientes.Exists(x => x.Dni == c.Dni)) { throw new ExIdRepetido(c.Dni); } else
                {
                    ListClientes.Add(c);
                }

            }
            catch (ExIdRepetido ex)
            {
                throw new ExIdRepetido(ex._value);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal void Modificar(Cliente clienteSeleccionado)
        {
            try
            {
                // Implementamos esta funcion lambda para encontrar al Cliente
                Cliente aux = ListClientes.Find(x => x.Dni == clienteSeleccionado.Dni);
                aux.Dni = int.Parse(Interaction.InputBox("Ingrese el DNI del nuevo cliente: "));
                if (ListClientes.Exists(x => x.Dni == aux.Dni)) { throw new ExIdRepetido(aux.Dni); }
                aux.Nombre = Interaction.InputBox("Ingrese el Nombre del cliente: ");
                aux.Apellido = Interaction.InputBox("Ingrese el Apellido del cliente: ");

            }
            catch (ExIdRepetido ex) { throw new ExIdRepetido(ex._value); }
            catch (Exception) { throw new Exception("Esa persona no existe"); }
        }

        internal void Baja(Cliente clienteSeleccionado)
        {
            try {
                // Implementamos esta funcion lambda para encontrar al Cliente
                Cliente aux = ListClientes.Find(x => x.Dni == clienteSeleccionado.Dni);
                //Borramos todos los prestamos que están anexados al cliente si es que hay
                if (aux.ListPrestamos != null)
                {
                    aux.ListPrestamos.Clear();
                }
                
                //Finalmente borramos el cliente
                ListClientes.Remove(aux);
            }
            catch (Exception) { throw new Exception("Esa persona no existe"); }
        }
    }
}
