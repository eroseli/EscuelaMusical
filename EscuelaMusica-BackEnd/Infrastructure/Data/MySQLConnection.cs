using System;
using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;


namespace EscuelaMusica_BackEnd.Infrastructure.Data
{
	public class MySQLConnection
	{
        
        private readonly string _connectionString;

        public  MySQLConnection(String  connectionString)
        {
            _connectionString = connectionString; 
        }

        public MySqlConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }
        
    
	}
}

