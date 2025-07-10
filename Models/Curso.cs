namespace EXAMEN_PARCIAL.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string NombreCurso { get; set; }  // Asumiendo que 'Curso' es de tipo string.
        public int Creditos { get; set; }
        public int HorasSemanal { get; set; }
        public string Ciclo { get; set; }  // Asegúrate de que sea tipo string
        public int IdDocente { get; set; }
    }

}
