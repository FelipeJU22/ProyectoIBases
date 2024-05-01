namespace LabCE_MODEL.Modelos
{
    public class SolicitudActivo
    {
        public int Id { get; set; }
        public string? NombreEstudiante { get; set; }
        public string? Apellido1Estudiante { get; set; }
        public string? Apellido2Estudiante { get; set; }
        public string? CorreoEstudiante { get; set; }
        public bool Aprobado { get; set; }
        public DateTime Hora { get; set; }
        public DateTime Fecha { get; set;}
        public bool Finalizado { get; set; }
        public string PlacaActivo { get; set; }
        public string CorreoProfesor {  get; set; }
        public string CorreoOperador { get; set; }

        public Activo Activo { get; set; }
        public Profesor Profesor { get; set; }
        public Operador Operador { get; set; }
        public RegistroAverias RegistroAverias { get; set; }
    }
}