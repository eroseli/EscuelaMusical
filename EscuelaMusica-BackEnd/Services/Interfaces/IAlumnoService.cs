using System;
using EscuelaMusica_BackEnd.Models;

namespace EscuelaMusica_BackEnd.Services.Interfaces
{
	public interface IAlumnoService
	{
		
        Task<Alumno?> ObtenerAlumnoId(int id);
        Task<Boolean> insertarAlumno(Alumno alumno);
        Task<Boolean> actualizarAlumno(Alumno alumno);
        Task<IEnumerable<Alumno>> obtenerAlumnos();
        Task<Boolean> eliminarAlumno(int id);
        
	}
}

