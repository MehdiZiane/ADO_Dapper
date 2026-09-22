using System;
using System.Collections.Generic;
using System.Text;

namespace Exo_Dapper.Models
{
    public class CreateProduct
    {
        public CreateProduct(string titre, string description, int stock, int categoryId)
        {
            this.product_titre = titre;
            this.product_description = description;
            this.product_stock = stock;
            this.category_id = categoryId;
        }
        public string product_titre { get; set; }
        public string product_description { get; set; }
        public int product_stock { get; set; }
        public int category_id { get; set; }
    }
}
