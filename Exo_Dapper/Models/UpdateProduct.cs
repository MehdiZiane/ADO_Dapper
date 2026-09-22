using System;
using System.Collections.Generic;
using System.Text;

namespace Exo_Dapper.Models
{
    public class UpdateProduct
    {
        public UpdateProduct(string name, string description, int stock, int categoryid)
        {
            this.product_titre = name;
            this.product_description= description;
            this.product_stock = stock;
            this.category_id = categoryid;
        }
        public string product_titre { get; set; }
        public string product_description { get; set; } 
        public int product_stock { get; set;} 
        public int category_id { get; set; }
    }
}
