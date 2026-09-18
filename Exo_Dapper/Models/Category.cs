using System;
using System.Collections.Generic;
using System.Text;

namespace Exo_Dapper.Models
{
    public class Category
    {
        public int category_id {  get; set; }
        public string category_titre {  get; set; }
        public string category_desciption { get; set; }
        public DateTime category_createat {  get; set; }
    }
}
