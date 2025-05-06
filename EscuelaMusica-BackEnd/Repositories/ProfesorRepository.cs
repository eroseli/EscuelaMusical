using System;
using EscuelaMusica_BackEnd.Domain.Interfaces;
using EscuelaMusica_BackEnd.Models;

namespace EscuelaMusica_BackEnd.Repositories
{
	public class ProfesorRepository : IProfesorRepository
	{
		public ProfesorRepository()
		{
		}

        public Task Actualizar(Escuela escuela)
        {
            throw new NotImplementedException();
        }

        public Task Agregar(Escuela escuela)
        {
            throw new NotImplementedException();
        }

        public Task Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Escuela>> Obtener()
        {
            throw new NotImplementedException();
        }

        public Task<Escuela?> ObtenerId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

