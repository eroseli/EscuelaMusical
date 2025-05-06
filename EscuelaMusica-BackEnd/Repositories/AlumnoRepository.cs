using System;
using System.Data;
using EscuelaMusica_BackEnd.Domain.Interfaces;
using EscuelaMusica_BackEnd.Infrastructure.Data;
using EscuelaMusica_BackEnd.Models;
using MySql.Data.MySqlClient;

namespace EscuelaMusica_BackEnd.Repositories
{
	public class AlumnoRepository : IAumnoRepository
	{
        enum configuracion
        {
            crear = 1,
            consultar = 2,
            actualizar = 3,
            eliminar = 4
        }

        private readonly MySQLConnection _mySQLConnection;

        public AlumnoRepository(MySQLConnection mySQLConnection)
        {
            this._mySQLConnection = mySQLConnection;

        }

        public async Task<Boolean>  Actualizar(Alumno alumno)
        {
            throw new NotImplementedException();
        }

        public async Task<Boolean> Agregar(Alumno alumno)
        {
            throw new NotImplementedException();
        }

        public async Task<Boolean> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Alumno>> Obtener()
        {
            throw new NotImplementedException();
        }

        public async Task<Alumno?>  ObtenerId(int id)
        {
            
            using var connection = _mySQLConnection.CreateConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "SPCRUDALUMNOS";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new MySqlParameter("@Param_IdAlumno", id));
            command.Parameters.Add(new MySqlParameter("@Param_Nombre", ""));
            command.Parameters.Add(new MySqlParameter("@Param_APaterno", ""));
            command.Parameters.Add(new MySqlParameter("@Param_AMaterno", ""));
            command.Parameters.Add(new MySqlParameter("@Param_FechaNacimiento", null));
            command.Parameters.Add(new MySqlParameter("@Param_Config", configuracion.consultar));


            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new Alumno
                {
                    IdAlumno = Convert.ToInt32(reader["Id_Alumno"]),
                    Nombre = reader["Nombre"].ToString()!,
                    APaterno = reader["A_Paterno"].ToString()!,
                    AMaterno = reader["A_Materno"].ToString()!,
                    FechaNacimiento = Convert.ToDateTime( reader["Fecha_Nacimiento"].ToString()!)
                };
            }

            return null;

        }
    }
}

