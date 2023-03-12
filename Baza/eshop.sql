create database eshop
use eshop



create table proizvodi
(
	Id int Primary Key Identity(1,1),
	Naziv nvarchar(100),
	Proizvvodjac nvarchar (100),
	Cena decimal(8,2)
)