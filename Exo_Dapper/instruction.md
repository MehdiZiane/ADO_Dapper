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
		- Ajout d'un produit
		- Affichage des produits
		- Affichage d'un produit
		- Modifier un produit
		- Suprimer un produit

- Implémentation d'un "Repository" Category
	- Category
		- Ajout d'une Categorie
		- Affichage des Categorie
		- Affichage d'une Categorie
		- Modifier une Categorie
		- Suprimer une Categorie

- Implémentation d'une interface dans la console 

	- Permet de gérer les actions du repository 