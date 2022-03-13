namespace ZULETA_POO_2P
{
    public abstract class VistaPrestamo
    {
        public string Id { get; set; }
        public double CapitalSolicitado { get; set; }
        public int PlazoMeses { get; set; }
        public double DineroARetornar { get; set; }
        public double TasaDeInteres { get; set; }
        public double InteresTotal { get; set; }
    }
}