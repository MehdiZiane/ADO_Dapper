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

        public Product? AddProduct(CreateProduct newproduct)
        {
            using SqlConnection conn = new SqlConnection(connectionString);

            int result = conn.ExecuteScalar<int>("insert into product(product_titre, product_description, product_stock, category_id) output inserted.product_id values (@product_titre, @product_description, @product_stock, @category_id)", newproduct);

            Product? productcreate = GetById(result);

            return productcreate;
        }

        public Product? Updateproduct(UpdateProduct updateproduct, int id)
        {
            using SqlConnection conn = new SqlConnection(connectionString);

            int rows = conn.Execute("update product set product_titre = @product_titre, product_description = @product_description, product_stock = @product_stock, category_id = @category_id where product_id = @id",
                    new {product_titre = updateproduct.product_titre, product_description = updateproduct.product_description, product_stock = updateproduct.product_stock, category_id = updateproduct.category_id, id = id});
            if(rows != 0)
            {
                return GetById(id);
            }
            else
            {
                return null;
            }
        }

        public bool DeleteProduit(int id)
        {
            using SqlConnection conn = new SqlConnection(connectionString);

            int rows = conn.Execute("delete from product where product_id = @id", new { id = id });

            return rows > 0;
        }
    }
}
