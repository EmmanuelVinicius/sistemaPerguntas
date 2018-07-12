create database [banco]
use [banco]

create table Perguntas(
ID int not null identity,
Corpo varchar(100) not null,
OpcaoA varchar(50) not null,
OpcaoB varchar(50) not null,
OpcaoC varchar(50) not null,
OpcaoD varchar(50) not null,
Certo char not null,
Constraint pk_Perguntas primary key(ID)
);
select * from Perguntas