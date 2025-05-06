using System;
using EscuelaMusica_BackEnd.Models;

namespace EscuelaMusica_BackEnd.Domain.Interfaces
{
	public interface IProfesorRepository
	{
        Task<Escuela?> ObtenerId(int id);
        Task<IEnumerable<Escuela>> Obtener();
        Task Agregar(Escuela escuela);
        Task Actualizar(Escuela escuela);
        Task Eliminar(int id);
    }

}

