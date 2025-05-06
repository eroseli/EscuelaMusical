using System;
using EscuelaMusica_BackEnd.Models;

namespace EscuelaMusica_BackEnd.Domain.Interfaces
{
	public interface IAumnoRepository
	{
        Task<Alumno?> ObtenerId(int id);
        Task<IEnumerable<Alumno>> Obtener();
        Task<Boolean> Agregar(Alumno escuela);
        Task<Boolean> Actualizar(Alumno escuela);
        Task<Boolean> Eliminar(int id);
    }
}

