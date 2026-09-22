using Dapper;
using Exo_Dapper.Models;
using Microsoft.Data.SqlClient;

namespace Exo_Dapper.Dal_Dapper
{
    public class ReposCategory
    {
        string connectionString = @"Server=GOS-VDI410\TFTIC;Database=CatalogueDB;Trusted_connection=True;TrustServerCertificate=True";

        public IEnumerable<Category> GetCategory()
        {
            using SqlConnection conn = new SqlConnection(connectionString);

            return conn.Query<Category>("select * from category");
        }

        public Category? GetById(int id)
        {
            using SqlConnection conn = new SqlConnection(connectionString);

            return conn.QueryFirstOrDefault<Category>($"select* from category where category_id = @Id", new { Id = id });
        }

        public Category? AddCategory(CreateCategory newcategory)
        {
            using SqlConnection conn = new SqlConnection(connectionString);

            int result = conn.ExecuteScalar<int>("insert into category(category_titre, category_description) output inserted.category_id values (@category_titre, @category_description)", newcategory);

            Category? categorycreate = GetById(result);

            return categorycreate;
        }
        public Category? UpdateCategory(UpdateCategory updatecategory, int id)
        {
            using SqlConnection conn = new SqlConnection(connectionString);

            int rows = conn.Execute("update category set category_titre = @category_titre, category_description = @category_description where category_id = @Id",
                 new {category_titre = updatecategory.category_titre, category_description = updatecategory.category_description, id = id});
            if(rows != 0)
            {
                return GetById(id);
            }
            else
            {
                return null;
            }
        }
    }
}
