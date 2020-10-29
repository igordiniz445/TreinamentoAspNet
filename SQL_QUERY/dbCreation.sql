create database treinamento;

use treinamento;

create table veiculos(
	id int IDENTITY(1,1) PRIMARY KEY,
	modelo varchar(65) not null,
	ano int not null,
	valor decimal not null,
);

create table compra(
	idCompra int IDENTITY(1,1) PRIMARY KEY,
	idVeiculo int not null,
	cpf varchar(11) not null,
	nomeComprador varchar(45) not null,
	dataCompra DateTime,
	placa varchar(7) unique not null,
);

alter table compra  add constraint FK_Veiculos foreign key (idVeiculo) references veiculos (id);



