using Dapper;
using System.Data.SqlClient;

namespace Warehouse.Infrastructure.Read
{
    public class WarehouseReadService : IWarehouseReadService
    {
        public Product Find(string sku)
        {
            using var connection = new SqlConnection("Server=SUGA;Database=ShopTest;Integrated Security=true;TrustServerCertificate=true;");
                connection.Open();

            //return connection.QuerySingle<Product>(@"SELECT * FROM Product WHERE sku = @sku", new {sku});
            return connection.QueryFirst<Product>(@"SELECT * FROM Product WHERE sku = @sku", new { sku });
        }
    }
}