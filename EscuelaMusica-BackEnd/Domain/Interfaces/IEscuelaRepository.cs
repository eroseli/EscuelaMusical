using System;
using EscuelaMusica_BackEnd.Models;

namespace EscuelaMusica_BackEnd.Domain.Interfaces
{
	public interface IEscuelaRepository
	{
        Task<Escuela?> ObtenerId(int id);
        Task<IEnumerable<Escuela>> Obtener();
        Task<Boolean> Agregar(Escuela escuela);
        Task<Boolean> Actualizar(Escuela escuela);
        Task<Boolean> Eliminar(int id);
    }
}

