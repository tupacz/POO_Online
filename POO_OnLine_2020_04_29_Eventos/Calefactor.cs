using System;
using System.Drawing;

namespace POO_OnLine_2020_04_29_Eventos
{
    public class Calefactor
    {
        private int _temp;
        public event EventHandler<InformacionCalefactorEventArgs> AltaTemperatura;
        public event EventHandler<InformacionCalefactorEventArgs> BajaTemperatura;
        public Color TemperaturaAlta { get; set; }
        public Color TemperaturaBaja { get; set; }
        public int Temperatura
        {
            get { return _temp; }
            set 
            { 
                _temp = value;
                //if (_temp > 100) { if (!(AltaTemperatura == null)) { AltaTemperatura(this, new EventArgs()); } }
                if (_temp > 100) { AltaTemperatura?.Invoke(this, new InformacionCalefactorEventArgs(_temp,TemperaturaAlta)); }
                else { BajaTemperatura?.Invoke(this, new InformacionCalefactorEventArgs(_temp,TemperaturaBaja)); }
            }
        }
    }

}
