namespace LabCE_MODEL.Modelos
{
    public class TipoActivo
    {
        public int Id { get; set; }
        public ICollection<Activo> Activos { get; set; }
    }
}