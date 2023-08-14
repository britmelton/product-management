using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace catalog.infrastructure.read
{
    public class ProductReadService : IProductReadService
    {
        public ProductDto Find(Guid id)
        {
            using var connection = new SqlConnection("Server=SUGA;Database=ShopTest;Integrated Security=true;TrustServerCertificate=true;");
            connection.Open();

            return connection.QuerySingle<ProductDto>(@"SELECT * FROM Product WHERE id = @id", new { id});
        }
    }
}
