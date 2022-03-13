using System;

namespace ZULETA_POO_2P
{
    public class PrestamoDolares : Prestamo
    {
        override public double GastosAdministrativos()
        {
            //El prestamo en dolares tiene un gasto de 3% + 1%
            return 0.04;
        }

        override public double InteresTotal()
        {
            return CapitalSolicitado * TasaDeInteres * PlazoMeses;
        }

        override public double DineroARetornar()
        {
            return (CapitalSolicitado + InteresTotal()) * (1 + GastosAdministrativos());
        }
    }
}