# Exercice Dapper

#### Mini catalogue : Product Category

- Fk dans Product de Category

- Product
```c#
public int Id { get; set; }
public string Titre { get; set; }
public string Description { get; set; }
public int Stock { get; set; }
public DateTime CreatedAt { get; set; }
public int CategoryId { get; set; }
```

- Category
```c#
public int Id { get; set; }
public string Titre { get; set; }
public string Description { get; set; }
public DateTime CreatedAt { get; set; }
```

#### 1 : Création de la base de données

- Implémenter la table Category et Product


- Implémentation d'un "Repository" Product
	- Product
		- Ajout d'un produit V
		- Affichage des produits V
		- Affichage d'un produit V
		- Modifier un produit V
		- Suprimer un produit V

- Implémentation d'un "Repository" Category
	- Category
		- Ajout d'une Categorie V
		- Affichage des Categorie V
		- Affichage d'une Categorie V
		- Modifier une Categorie V
		- Suprimer une Categorie V

- Implémentation d'une interface dans la console 

	- Permet de gérer les actions du repository 