using System;
using EscuelaMusica_BackEnd.Models;

namespace EscuelaMusica_BackEnd.Services.Interfaces
{
	public interface IEscuelaService
	{
        Task<Escuela?> ObtenerEscuelaId(int id);
        Task<Boolean> insertarEscuela(Escuela escuela);
        Task<Boolean> actualizarEscuela(Escuela escuela);
        Task<IEnumerable<Escuela>> obtenerEscuelas();
        Task<Boolean> eliminarEscuela(int id);
     }
}

