namespace Exo_Dapper.Models
{
    public class Product
    {
        public int product_id { get; set; }
        public string product_titre { get; set; }
        public string product_description { get; set; }
        public int product_stock { get; set; }
        public DateTime product_createat { get; set; }
        public int category_id { get; set; }

        
        public override string ToString()
        {
            return $" id          : {this.product_id}\n" +
                   $" titre       : {this.product_titre}\n" +
                   $" description : {this.product_description}\n" +
                   $" stock       : {this.product_stock}\n" +
                   $" créé le     : {this.product_createat.ToShortDateString()}\n";
        }
    }
}
