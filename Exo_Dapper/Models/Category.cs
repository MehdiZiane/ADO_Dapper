using System;
using System.Collections.Generic;
using System.Text;

namespace Exo_Dapper.Models
{
    public class Category
    {
        public int category_id {  get; set; }
        public string category_titre {  get; set; }
        public string category_description { get; set; }
        public DateTime category_createat {  get; set; }


        public override string ToString()
        {
            return $" id          : {this.category_id}\n" +
                   $" titre       : {this.category_titre}\n" +
                   $" description : {this.category_description}\n" +
                   $" créé le     : {this.category_createat.ToShortDateString()}\n";
        }
    }
}
