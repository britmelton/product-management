using Dapper;
using System.Data.SqlClient;

namespace Warehouse.Infrastructure.Read
{
    public class WarehouseReadService : IWarehouseReadService
    {
        public Product Find(Guid id)
        {
            using var connection = new SqlConnection("Server=SUGA;Database=ShopTest;Integrated Security=true;TrustServerCertificate=true;");
                connection.Open();

                return connection.QuerySingle<Product>(@"SELECT * FROM Product WHERE id = @id", new {id});
        }
    }
}