using System;

namespace ZULETA_POO_2P
{
    public class ExFormatoPrestamoInvalido : Exception
    {
        // Es un mensaje específico para cuando el formato es incorrecto
        public override string Message => "El id que ingresó no es válido. Debe ser [ABCD-123456]. Los primeros 4 caracteres son letras en mayúsculas, un guión ( - ) en el medio, 6 digitos del 0 al 9";
    }
}
