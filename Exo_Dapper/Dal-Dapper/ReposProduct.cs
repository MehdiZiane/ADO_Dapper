using Dapper;
using Exo_Dapper.Models;
using Microsoft.Data.SqlClient;

namespace Exo_Dapper.Dal_Dapper
{
    public class ReposProduct
    {
        string connectionString = @"Server=GOS-VDI410\TFTIC;Database=CatalogueDB;Trusted_connection=True;TrustServerCertificate=True";

        public IEnumerable<Product> GetProduct()
        {
            using SqlConnection conn = new SqlConnection(connectionString);

            return conn.Query<Product>("select * from product");
        }

        public Product? GetById(int id)
        {
            using SqlConnection conn = new SqlConnection(connectionString);

            return conn.QueryFirstOrDefault<Product>($"select * from product where product_id = @Id", new { Id = id });
        }
    }
}
