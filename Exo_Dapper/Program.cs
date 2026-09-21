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

        case "3":
            ShowProduct();

            int idp = GetInt("Id du produit que vous voulez voir en detail");

            Product products = reposproduct.GetById(idp);
            if(products is not null)
            {
                Console.WriteLine(products);
            }
            else
            {
                Console.WriteLine($"aucun produit avec cette id : {idp}");
            }
            Console.ReadLine();  
            break;
        case "4":
            ShowCategory();

            int idc = GetInt("Id de la category que vous voulez voir en detail");

            Category categorys = reposcategory.GetById(idc);
            if(categorys is not null)
            {
                Console.WriteLine(categorys);
            }
            else
            {
                Console.WriteLine($"aucune category avec cette id : {idc}");
            }
            Console.ReadLine() ;
            break;
    }
}


void showmenu()
{
    Console.Clear();
    Console.WriteLine("entré 1 pour voir les different produit");
    Console.WriteLine("entré 2 pour voir les differente category");
    Console.WriteLine("entré 3 pour voir le detail d un produit");
    Console.WriteLine("entré 4 pour voir la detail d une category");

}
void ShowProduct() 
{
    IEnumerable<Product> products = reposproduct.GetProduct();

    foreach(Product p in products)
    {
        Console.WriteLine($"id : {p.product_id} - titre : {p.product_titre}");
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

int GetInt(string message)
{
    int result = 0;
    do
    {
        Console.WriteLine($"entrez la valeur pour : {message}");
    }
    while (!int.TryParse(Console.ReadLine(), out result));
    return result;
}