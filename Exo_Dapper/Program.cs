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
        case "5":
            CreateProduct newproduct = GetNewProduct();
            Product? productcreate = reposproduct.AddProduct(newproduct);

            if(productcreate is not null)
            {
                Console.WriteLine($"nouveaux produit: id : {productcreate.product_id} - nom : {productcreate.product_titre} ");
            }
            else
            {
                Console.WriteLine("erreur lors de l ajout");
            }
            Console.ReadLine();
            break;
        case "6":
            CreateCategory newcategory = getNewCategory();
            Category? categorycreate = reposcategory.AddCategory(newcategory);

            if(categorycreate is not null)
            {
                Console.WriteLine($"nouvelle category: id : {categorycreate.category_id} - nom : {categorycreate.category_titre}");
            }
            else
            {
                Console.WriteLine("errreur lors de l ajout");
            }
            Console.ReadLine ();
            break;
        case "7":
            ShowProduct();
            int idupdatepro = GetInt("id du produit a modifié");

            Product? producttoUpdate = reposproduct.GetById(idupdatepro);

            if(producttoUpdate is not null)
            {
                UpdateProduct updateProduct = GetUpdateProduct(producttoUpdate);
                Product? productupdate = reposproduct.Updateproduct(updateProduct, idupdatepro);

                if(updateProduct is not null)
                {
                    Console.WriteLine($"le produit : {producttoUpdate.category_id} a été mis a jour : nom : {producttoUpdate.product_titre}");
                }
                else
                {
                    Console.WriteLine("erreur lors de la modification");
                }
            }
            else
            {
                Console.WriteLine("aucun produit ne correspond a cette id");
            }
            Console.ReadLine () ;
            break;
        case "8":
            ShowCategory();
            int idupdatecat = GetInt("id de la tache a modifié");

            Category? categorytoUpdate = reposcategory.GetById(idupdatecat);

            if( categorytoUpdate is not null)
            {
                UpdateCategory updateCategory = GetUpdateCategory(categorytoUpdate);

                Category? categoryupdate = reposcategory.UpdateCategory(updateCategory, idupdatecat);
                if (updateCategory is not null)
                {
                    Console.WriteLine($"la category : {categorytoUpdate.category_id} a été mis a jour : nom : {categorytoUpdate.category_titre}");
                }
                else
                {
                    Console.WriteLine("erreur lors de la modification");
                }
            }
            else
            {
                Console.WriteLine("aucune category ne correspond a cette id");
            }
            Console.ReadLine () ;
            break;
        case "9":
            ShowProduct();

            int idfordeletepro = GetInt("id du produit a supprimé");

            bool resultpro = reposproduct.DeleteProduit(idfordeletepro);
            if (resultpro)
            {
                Console.WriteLine($"le produit avec l id : {idfordeletepro} a été supprimé");
            }
            else
            {
                Console.WriteLine("erreur lors de la suppression");
            }
            Console.ReadLine ();
            break;
        case "10":
            ShowCategory();

            int idfordelete = GetInt("id de la tache a supprimé");

            bool result = reposcategory.DeleteCategory(idfordelete);

            if (result)
            {
                Console.WriteLine($"la categorie avec l id : {idfordelete} a bien été supprimé");
            }
            else
            {
                Console.WriteLine("une erreur lors de la suppression");
            }
            Console.ReadLine();
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
    Console.WriteLine("entré 5 pour ajouté un produit");
    Console.WriteLine("entré 6 pour ajouté une category");
    Console.WriteLine("entré 7 pour modifié un produit");
    Console.WriteLine("entré 8 pour modifié une categorie");
    Console.WriteLine("entré 9 pour supprimé un produit");
    Console.WriteLine("entré 10 pour supprimé une categorie");

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

CreateProduct GetNewProduct()
{
    Console.WriteLine("entre le nom du produit: ");
    string name = Console.ReadLine();

    Console.WriteLine("entre la description du produit: ");
    string description = Console.ReadLine();

    Console.WriteLine("entré le stock du produit: ");
    int stock = GetInt(Console.ReadLine());

    Console.WriteLine("entre le numero de la category associé au produit: ");
    int categoryid = GetInt(Console.ReadLine());

    CreateProduct newproduct = new(name, description, stock, categoryid);

    return newproduct;
}

CreateCategory getNewCategory()
{
    Console.WriteLine("entre le nom de la category: ");
    string name = Console.ReadLine();
    Console.WriteLine("entre la description de la category: ");
    string description = Console.ReadLine();

    CreateCategory newcategory = new(name, description);

    return newcategory;
}

UpdateProduct GetUpdateProduct(Product producttoUpdate)
{
    Console.WriteLine($"nom du produit : {producttoUpdate.product_titre}");
    string titleforupdate =  Console.ReadLine();

    Console.WriteLine($"description du produit : {producttoUpdate.product_description}");
    string descriptionforupdate = Console.ReadLine();

    Console.WriteLine($"stock present du produit : {producttoUpdate.product_stock}");
    int stock = GetInt(Console.ReadLine());

    Console.WriteLine($"id de la category associé : {producttoUpdate.category_id}");
    int categoryid = GetInt(Console.ReadLine());

    UpdateProduct updateProduct = new(titleforupdate, descriptionforupdate, stock, categoryid);
    return updateProduct;
}

UpdateCategory GetUpdateCategory(Category categorytoUpdate)
{
    Console.WriteLine($" nom de la category : {categorytoUpdate.category_titre}");
    string titleforupdate = Console.ReadLine();

    Console.WriteLine($" description de la category : {categorytoUpdate.category_description}");
    string descriptionforupdate = Console.ReadLine();

    UpdateCategory updateCategory = new(titleforupdate, descriptionforupdate);
    return updateCategory;
}