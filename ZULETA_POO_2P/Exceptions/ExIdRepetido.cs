using System;

namespace ZULETA_POO_2P
{
    // Se implementa esta excepción para que pueda ser utilizado tanto por Clientes y Prestamos
    public class ExIdRepetido : Exception
    {
        public object _value { get; set; }
        public ExIdRepetido(object idIngresado)
        {
            _value = idIngresado;
        }
        public override string Message => "El id que usted ingresó (" + _value +") ya se encuentra en la lista.";
    }
}
