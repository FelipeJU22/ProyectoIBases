namespace LabCE_MODEL.Modelos
{
    public class RegistroAverias
    {
        public int IdSolicitud { get; set; }
        public string Detalle { get; set; }
        public SolicitudActivo SolicitudActivo { get; set; }
    }
}