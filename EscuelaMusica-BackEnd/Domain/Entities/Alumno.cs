using System;
namespace EscuelaMusica_BackEnd.Models
{
    public class Alumno
    {
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}

