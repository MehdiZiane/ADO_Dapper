namespace Exo_Dapper.Models
{
    public class Product
    {  
        public int product_id {  get; set; }
        public string product_titre {  get; set; }
        public string product_desciption {  get; set; }
        public int product_stock {  get; set; }
        public DateTime product_createat {  get; set; }
        public int category_id {  get; set; }

    }
}
