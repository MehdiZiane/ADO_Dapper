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

