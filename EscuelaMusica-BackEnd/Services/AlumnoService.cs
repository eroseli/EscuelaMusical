using System;
using EscuelaMusica_BackEnd.Domain.Interfaces;
using EscuelaMusica_BackEnd.Models;
using EscuelaMusica_BackEnd.Services.Interfaces;

namespace EscuelaMusica_BackEnd.Services
{
	public class AlumnoService : IAlumnoService
	{

        private readonly IAumnoRepository _IalumnoRepository;

        public AlumnoService(IAumnoRepository IalumnoRepository) { 
            this._IalumnoRepository = IalumnoRepository;

        }

        public Task<bool> actualizarAlumno(Alumno alumno)
        {
            throw new NotImplementedException();
        }

        public Task<bool> eliminarAlumno(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> insertarAlumno(Alumno alumno)
        {
            throw new NotImplementedException();
        }

        public Task<Alumno?> ObtenerAlumnoId(int id)
        {
            return _IalumnoRepository.ObtenerId(id);
        }

        public Task<IEnumerable<Alumno>> obtenerAlumnos()
        {
            throw new NotImplementedException();
        }
    }
}

