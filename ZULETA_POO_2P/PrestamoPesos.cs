using System;

namespace ZULETA_POO_2P
{
    public class PrestamoPesos : Prestamo
    {
        override public double GastosAdministrativos()
        {
            //El prestam en pesos tiene un gasto de 2% + 1%
            return 0.03;
        }

        override public double InteresTotal()
        {
            return CapitalSolicitado * (Math.Pow((1 + ((TasaDeInteres / PlazoMeses) / 100)),PlazoMeses) - 1);
        }

        override public double DineroARetornar()
        {
            // El dinero a retornar incluye gastos administrativos
            return (CapitalSolicitado + InteresTotal()) * (1 + GastosAdministrativos());
        }


    }
}