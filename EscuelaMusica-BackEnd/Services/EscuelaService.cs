using System;
using EscuelaMusica_BackEnd.Domain.Interfaces;
using EscuelaMusica_BackEnd.Models;
using EscuelaMusica_BackEnd.Services.Interfaces;

namespace EscuelaMusica_BackEnd.Services
{
	public class EscuelaService : IEscuelaService
	{

		private readonly IEscuelaRepository _EscuelaRepository;

        public EscuelaService(IEscuelaRepository EscuelaRepository)
		{
			this._EscuelaRepository = EscuelaRepository;

        }

        public async Task<Boolean> actualizarEscuela(Escuela escuela)
        {
            return await _EscuelaRepository.Actualizar(escuela);
        }

        public async Task<bool> eliminarEscuela(int id)
        {
            return await _EscuelaRepository.Eliminar(id);
        }

        public async Task<Boolean> insertarEscuela(Escuela escuela)
        {
            return await _EscuelaRepository.Agregar(escuela);

        }

        public async Task<Escuela?> ObtenerEscuelaId(int id)
        {
            // Aquí podrías validar si el ID es válido, etc.
            var escuela = await _EscuelaRepository.ObtenerId(id);

            if (escuela == null)
                return null;

            return escuela;

        }

        public Task<IEnumerable<Escuela>> obtenerEscuelas()
        {
            return _EscuelaRepository.Obtener();
        }
    }
}

