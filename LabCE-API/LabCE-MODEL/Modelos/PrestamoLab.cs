namespace LabCE_MODEL.Modelos
{
    public class PrestamoLab
    {
        public int Id { get; set; }
        public int CarnetEstudiante { get; set; }
        public string CorreoEstudiante { get; set; }
        public string NombreEstudiante { get; set; }
        public string Apellido1Estudiante{ get; set;}
        public string Apellido2Estudiante { get;set;}
        public DateTime Fecha { get; set;}
        public DateTime HoraInicio { get; set;}
        public DateTime HoraFinal {  get; set;}
        public string CorreoProfesor {  get; set;}
        public string NombreLab {  get; set;}
        public Profesor Profesor { get; set;}  
    }
}