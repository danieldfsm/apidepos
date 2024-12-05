using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using UsuariosApi.models;
using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.models
{
    public class UsuarioContext : DbContext
    {
       
        private readonly string _connectionString;

        public UsuarioContext(IConfiguration configuration)
        {
            // Obtén la cadena de conexión del archivo appsettings.json
            _connectionString = configuration.GetConnectionString("DefaultConnection") 
                                ?? throw new ArgumentNullException("La cadena de conexión no está configurada.");
        }

        public async Task<List<Usuario>> EjecutarSPPOSLEConexion(string usuario, string password)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var parametros = new DynamicParameters();
            parametros.Add("@Usuario", usuario, DbType.String);
            parametros.Add("@PASSWD", password, DbType.String);

            var resultado = await connection.QueryAsync<Usuario>(
                "SPPOSLE_Conexion",
                parametros,
                commandType: CommandType.StoredProcedure
            );

            return resultado.ToList();
        }

        public async Task<List<Grupos>> EjecutarSPPOSLE_Grupo()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var parametros = new DynamicParameters();
           
            var resultado = await connection.QueryAsync<Grupos>(
                "SPPOSLE_Grupo",              
                commandType: CommandType.StoredProcedure
            );

            return resultado.ToList();
        }
        public async Task<List<Productos>> EjecutarSPPOSLE_Productos_Select(string Codigo_Grupo)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var parametros = new DynamicParameters();
            parametros.Add("@Codigo_Grupo", Codigo_Grupo, DbType.String);
           
            var resultado = await connection.QueryAsync<Productos>(
                "SPPOSLE_Productos_Select",     
                 parametros,         
                commandType: CommandType.StoredProcedure
            );

            return resultado.ToList();
        }
    }
    
}