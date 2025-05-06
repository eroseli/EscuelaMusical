using System;
using System.Data;
using EscuelaMusica_BackEnd.Domain.Interfaces;
using EscuelaMusica_BackEnd.Infrastructure.Data;
using EscuelaMusica_BackEnd.Models;
using Microsoft.AspNetCore.Connections;
using MySql.Data.MySqlClient;

enum configuracion
{
    crear =1,
    consultar =2,
    actualizar = 3,
    eliminar = 4
}

namespace EscuelaMusica_BackEnd.Repositories
{
	public class EscuelaRepository : IEscuelaRepository
	{
        private readonly MySQLConnection _mySQLConnection;


        public EscuelaRepository(MySQLConnection mySQLConnection)
		{
            this._mySQLConnection = mySQLConnection;
		}

        public async Task<Boolean> Actualizar(Escuela escuela)
        {
            using var connection = _mySQLConnection.CreateConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "SPCRUDESCUELA";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new MySqlParameter("@Param_Config", configuracion.actualizar));
            command.Parameters.Add(new MySqlParameter("@Param_Id", escuela.IdEscuela));
            command.Parameters.Add(new MySqlParameter("@Param_Nombre", escuela.Nombre));
            command.Parameters.Add(new MySqlParameter("@Param_Direccion", escuela.Direccion));
            command.Parameters.Add(new MySqlParameter("@Param_Telefono", escuela.Telefono));

            using var reader = await command.ExecuteReaderAsync();

            
            return true;

        }

        public async Task<Boolean> Agregar(Escuela escuela)
        {
            using var connection = _mySQLConnection.CreateConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "SPCRUDESCUELA";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new MySqlParameter("@Param_Config", configuracion.crear));
            command.Parameters.Add(new MySqlParameter("@Param_Id", 0));
            command.Parameters.Add(new MySqlParameter("@Param_Nombre", escuela.Nombre));
            command.Parameters.Add(new MySqlParameter("@Param_Direccion", escuela.Direccion));
            command.Parameters.Add(new MySqlParameter("@Param_Telefono", escuela.Telefono));

            using var reader = await command.ExecuteReaderAsync();

            return true;
        }

        public async Task<Boolean> Eliminar(int id)
        {
            using var connection = _mySQLConnection.CreateConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "SPCRUDESCUELA";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new MySqlParameter("@Param_Config", configuracion.eliminar));
            command.Parameters.Add(new MySqlParameter("@Param_Id", id));
            command.Parameters.Add(new MySqlParameter("@Param_Nombre", ""));
            command.Parameters.Add(new MySqlParameter("@Param_Direccion", ""));
            command.Parameters.Add(new MySqlParameter("@Param_Telefono", ""));

            using var reader = await command.ExecuteReaderAsync();

            return true;

        }

        public async Task<IEnumerable<Escuela>> Obtener()
        {
            List<Escuela> escuelas = new List<Escuela>();
            using var connection = _mySQLConnection.CreateConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "SPCRUDESCUELA";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new MySqlParameter("@Param_Config", configuracion.consultar));
            command.Parameters.Add(new MySqlParameter("@Param_Id", 0));
            command.Parameters.Add(new MySqlParameter("@Param_Nombre", ""));
            command.Parameters.Add(new MySqlParameter("@Param_Direccion", ""));
            command.Parameters.Add(new MySqlParameter("@Param_Telefono", ""));

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                escuelas.Add(new Escuela
                {
                    IdEscuela = Convert.ToInt32(reader["Id_Escuela"]),
                    Nombre = reader["Nombre"].ToString()!,
                    Direccion = reader["Direccion"].ToString()!,
                    Telefono = reader["Telefono"].ToString()!
                });
            }

            return escuelas;
        }

        public async Task<Escuela?> ObtenerId(int id)
        {
            using var connection = _mySQLConnection.CreateConnection();
            await connection.OpenAsync(); 

            using var command = connection.CreateCommand();
            command.CommandText = "SPCRUDESCUELA";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new MySqlParameter("@Param_Config", configuracion.consultar));
            command.Parameters.Add(new MySqlParameter("@Param_Id", 1));
            command.Parameters.Add(new MySqlParameter("@Param_Nombre", ""));
            command.Parameters.Add(new MySqlParameter("@Param_Direccion", ""));
            command.Parameters.Add(new MySqlParameter("@Param_Telefono", ""));

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new Escuela
                {
                    IdEscuela = Convert.ToInt32(reader["Id_Escuela"]),
                    Nombre = reader["Nombre"].ToString()!,
                    Direccion = reader["Direccion"].ToString()!,
                    Telefono = reader["Telefono"].ToString()!
                };
            }

            return null;

        }
    }
}

