using Microsoft.VisualBasic;
using System;

namespace ZULETA_POO_2P
{
    public abstract class Prestamo : ICloneable
    {
        public string Id { get; set; }
        public double CapitalSolicitado { get; set; }
        public DateTime FechaSistema { get; set; }
        public DateTime FechaAdjudicada { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int PlazoMeses { 
            get {
                return Math.Abs((FechaAdjudicada.Month - FechaDevolucion.Month) + 12 * (FechaAdjudicada.Year - FechaDevolucion.Year));
            }
        }
        abstract public double DineroARetornar();
        public double TasaDeInteres { get; set; }
        abstract public double InteresTotal();
        abstract public double GastosAdministrativos();
        public Cliente cliente { get; set; }
        public bool EstaPagado { get; set; }
        public bool EstaVencido
        {
            get {
                if (EstaPagado) return false;
                if (Form1.FechaSistema > FechaDevolucion) return true;
                return false;
            }
        }

        public event EventHandler<PrestamoEventArgs> FechaSistemaCambiada;
        protected virtual void OnCambioFechaSistema(PrestamoEventArgs p)
        {
            FechaSistemaCambiada?.Invoke(this, p);
        }

        public void Update(DateTime fechasistema)
        {
            OnCambioFechaSistema(new PrestamoEventArgs(fechasistema));
        }

        public object Clone()
        {
            Prestamo _p = (Prestamo)this.MemberwiseClone();
            return _p;
        }


    }

    public class PrestamoEventArgs : EventArgs
    {
        public PrestamoEventArgs(DateTime fecha)
        {
            NuevaFecha = fecha;
        }

        public DateTime NuevaFecha { get; }
    }
}