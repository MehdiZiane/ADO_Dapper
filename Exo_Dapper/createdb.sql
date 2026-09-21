create table category(
category_id int identity (1,1) primary key,
category_titre nvarchar (100) not null,
category_desciption nvarchar (500) null,
category_createat datetime not null default getdate()
);


create table product(
product_id int identity (1,1) primary key,
product_titre nvarchar (100) not null, 
product_description nvarchar (500) null,
product_stock int not null default 0,
product_createat datetime not null default getdate(),
category_id int not null 

constraint fk_product_category foreign key (category_id)
	references category(category_id)
);

-- 1. ÉTAPE OBLIGATOIRE : Insérer les catégories d'abord
INSERT INTO category (category_titre, category_description)
VALUES 
(N'Écrans', N'Moniteurs PC pour la bureautique et le gaming'),
(N'Audio', N'Casques, écouteurs et haut-parleurs sans fil');

-- 2. ÉTAPE SUIVANTE : Insérer les produits liés
-- (On lie l'écran à la catégorie 1 et le casque à la catégorie 2)
INSERT INTO product (product_titre, product_description, product_stock, category_id)
VALUES 
(N'Écran Gaming 24"', N'Dalle IPS 144Hz 1ms avec ports HDMI', 15, 1),
(N'Casque Réduction de Bruit', N'Casque Bluetooth avec micro intégré', 42, 2);
