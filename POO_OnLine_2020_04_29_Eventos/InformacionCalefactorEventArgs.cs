using System;
using System.Drawing;

namespace POO_OnLine_2020_04_29_Eventos
{
    public class InformacionCalefactorEventArgs : EventArgs
    {
        private int _temp; private Color _color;
        public InformacionCalefactorEventArgs(int pTemp, Color pColor)
        { _temp = pTemp;_color = pColor; }
        public int TemperaturaActual { get { return _temp; } }
        public Color Color { get { return _color; } } 

    }

}
