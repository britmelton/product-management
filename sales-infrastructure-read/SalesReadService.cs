using System.Data.SqlClient;
using Dapper;

namespace Sales.Infrastructure.Read
{
    public class SalesReadService : ISalesReadService
    {
        public Product Find(Guid id)
        {
            using var connection = new SqlConnection("Server=SUGA;Database=ShopTest;Integrated Security=true;TrustServerCertificate=true;");
            connection.Open();

            return connection.QuerySingle<Product>(@"SELECT * FROM Product WHERE sku = @sku", new { id });
        }
    }
}
