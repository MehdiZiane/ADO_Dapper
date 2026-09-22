using System;
using System.Collections.Generic;
using System.Text;

namespace Exo_Dapper.Models
{
    public class UpdateCategory
    {
        public UpdateCategory(string titre, string description) 
        {
            this.category_titre = titre;
            this.category_description = description;
        }
        public string category_titre { get; set; } 
        public string category_description { get; set; }
    }
}
