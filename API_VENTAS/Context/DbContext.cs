namespace API_VENTAS.Context
{
    public class DbContext(IConfiguration _Config)
    {
        public string ConnectionSQL() => _Config.GetConnectionString("ProdSQL");
    }
}
