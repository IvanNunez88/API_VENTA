using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace DAL
{
    public class Contexto
    {
        public static async Task<DataTable> Funcion_StoreDB(String cadena, String P_Sentencia, object P_Parametro)
        {
            DataTable Dt = new();
            try
            {
                using SqlConnection conn = new(cadena);
                var lst = await conn.ExecuteReaderAsync(P_Sentencia, P_Parametro, commandType: CommandType.StoredProcedure);
                Dt.Load(lst);
            }
            catch (SqlException)
            {
                throw;
            }

            return Dt;
        }

        public static async  void Procedimiento_StoreDB(String cadena, String P_Sentencia, object P_Parametro)
        {
            try
            {
                using SqlConnection conn = new(cadena);
                await conn.ExecuteAsync(P_Sentencia, P_Parametro, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public static async Task<DataTable> Funcion_ScriptDB(String cadena, String P_Sentencia, object P_Parametro)
        {
            DataTable Dt = new();
            try
            {
                using SqlConnection conn = new(cadena);
                var lst = await conn.ExecuteReaderAsync(P_Sentencia, P_Parametro, commandType: CommandType.Text);
                Dt.Load(lst);
            }
            catch (SqlException)
            {
                throw;
            }
            return Dt;
        }

        public static async void Procedimiento_ScriptDB(String cadena, String P_Sentencia, object P_Parametro)
        {
            try
            {
                using SqlConnection conn = new(cadena);
                await conn.ExecuteAsync(P_Sentencia, P_Parametro, commandType: CommandType.Text);
            }
            catch (SqlException)
            {
                throw;
            }
        }

    }
}
