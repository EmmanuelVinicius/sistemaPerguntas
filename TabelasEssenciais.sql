create database AutoEscola;
use AutoEscola;
drop database AutoEscola;

create table Alunos
(
IDAluno int not null auto_increment,
Etapa int not null,
NomeCompleto varchar(50) not null,
DataInscricao datetime not null,
Telefone varchar(11),
Endereco varchar(50),
Email varchar(50),
Idade int,
Sexo bit,
constraint pk_Alunos primary key(IDAluno),
constraint fk_Etapa foreign key(Etapa) references Etapas(IDEtapa)
);

create table Usuarios
(
IDAluno INT NOT NULL,
Tipo varchar(20) not null,
Email varchar(50) not null,
Senha varchar(128) not null,
constraint fk_Usuario foreign key(IDAluno) references Alunos(IDAluno)
);
alter table Alunos drop IDUsuario;

create table Etapas
(
IDEtapa int not null AUTO_INCREMENT,
Descricao varchar(50) not null,
constraint pk_Etapas primary key(IDEtapa)
);
insert into Etapas(Descricao) values('Abrir a pauta');
insert into Etapas(Descricao) values('Exame médico');
insert into Etapas(Descricao) values('Aulas de Legislação');
insert into Etapas(Descricao) values('Prova de Legislação');
insert into Etapas(Descricao) values('Licensa de Aprendizagem');
insert into Etapas(Descricao) values('Aulas de Direção');
insert into Etapas(Descricao) values('Exame de Direção');
insert into Etapas(Descricao) values('Habilitado');

create table AulasLegislacao
(
IDAulaLegislacao int not null auto_increment,
Descricao varchar(25) not null,
Quantidade int not null,
constraint pk_AulasLegislacao primary key (IDAulaLegislacao)
);
create table AlunosEmLegislacao
(
IDAluno int not null,
IDAulaLegislacao int not null,
NumeroAulaLegislacao int not null,
ComentarioLegislacao varchar(100),
NotaAula int not null,
constraint pk_AlunosEmLegislacao primary key(IDAluno,IDAulaLegislacao),
constraint fk_AlunosEmLegislacao foreign key (IDAluno) references Alunos(IDAluno),
constraint fk_AulaLegislacao foreign key (IDAulaLegislacao) references AulasLegislacao(IDAulaLegislacao)
);

create table Legislacao
(
IDLegislacao int not null auto_increment,
Descricao varchar (100),
QuantidadeAulas int,
constraint pk_Legislacao primary key (IDLegislacao),
);
INSERT INTO Legislacao(Descricao, QuantidadeAulas) VALUES ('Legislação de Trânsito', 15);
INSERT INTO Legislacao(Descricao, QuantidadeAulas) VALUES ('Direção Defensiva', 15);
INSERT INTO Legislacao(Descricao, QuantidadeAulas) VALUES ('Meio Ambiente', 9);
INSERT INTO Legislacao(Descricao, QuantidadeAulas) VALUES ('Mecânica', 6);

create table Direcao
(
NumeroAulaDirecao int not null AUTO_INCREMENT,
IDAluno int not null,
ComentarioDirecao varchar(100),
NotaAula int not null,
constraint pk_Direcao primary key (NumeroAulaDirecao),
constraint fk_Direcao foreign key (IDAluno) references Alunos(IDAluno)
);

SELECT A.IDAluno, A.NomeCompleto FROM Usuarios U INNER JOIN Alunos A ON U.IDAluno = A.IDAluno WHERE U.Email = 'adm@cfctriunfo.com.br' AND U.Senha = 'b8495e00b5b4b0ba3a1234d085f4c4ccdfaf06c75431b1b7ec747980e5255e9a4869481b857195325c07f9598586dc12e783d736dd45d8975b7d6a73cc125856';

insert into Alunos values(1,1, 'Administrador','04/08/18','33814411', 'Rua Barao de monte alto', 'adm@cfctriunfo.com.br',19,1);
insert into Usuarios values(1,'ADM','adm@cfctriunfo.com.br','b8495e00b5b4b0ba3a1234d085f4c4ccdfaf06c75431b1b7ec747980e5255e9a4869481b857195325c07f9598586dc12e783d736dd45d8975b7d6a73cc125856');