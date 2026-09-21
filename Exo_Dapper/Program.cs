using Exo_Dapper.Dal_Dapper;
using Exo_Dapper.Models;

ReposProduct reposproduct = new ReposProduct();
ReposCategory reposcategory = new ReposCategory();

bool exit = false;

while (!exit)
{
    showmenu();

    string response = Console.ReadLine();

    switch (response)
    {
        case "1":
            ShowProduct();
            Console.ReadLine();
            break;

        case "2":
            ShowCategory();
            Console.ReadLine();
            break;
    }
}


void showmenu()
{
    Console.Clear();
    Console.WriteLine("entré 1 pour voir les different produit");
    Console.WriteLine("entré 2 pour voir les differente category");

}
void ShowProduct() 
{
    IEnumerable<Product> products = reposproduct.GetProduct();

    foreach(Product p in products)
    {
        Console.WriteLine($"id : {p.product_id} - titre : {p.product_titre} - description : {p.product_description}");
    }
}

void ShowCategory()
{
    IEnumerable<Category> categorys = reposcategory.GetCategory();

    foreach(Category c in categorys)
    {
        Console.WriteLine($"id : {c.category_id} - titre : {c.category_titre}");
    }
}