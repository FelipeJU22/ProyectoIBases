namespace LabCE_MODEL.Modelos
{
    public class Registro
    {
        public string CorreoOperador {  get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set;}
        public DateTime Fecha {  get; set;}
        public Operador Operador { get; set;}
    }
}