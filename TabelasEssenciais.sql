create table Alunos
(
IDAluno int not null auto_increment,
DataInscricao datetime not null,
NomeCompleto varchar(50) not null,
Telefone varchar(10),
Endereco varchar(50),
Idade int,
AulasLegislacao int,
AulasDirecao int,
constraint pk_Alunos primary key(IDAluno)
);
create table Etapas
(
IDEtapa int not null AUTO_INCREMENT,
Descricao varchar(50) not null,
constraint pk_Etapas primary key(IDEtapa)
);
insert into Etapas values('Abrir a pauta');
insert into Etapas values('Exame médico');
insert into Etapas values('Aulas de Legislação');
insert into Etapas values('Prova de Legislação');
insert into Etapas values('Licensa de Aprendizagem');
insert into Etapas values('Aulas de Direção');
insert into Etapas values('Exame de Direção');

create table AlunosEmEtapas
(
IDAluno int not null,
IDEtapa int not null,
constraint pk_AlunoEtapa primary key (IDAluno, IDEtapa),
constraint fk_Aluno foreign key (IDAluno) references Alunos,
constraint fk_Etapas foreign key (IDEtapa) references Etapas
);

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
constraint pk_AlunosEmLegislacao primary key(IDAluno,IDAulaLegislacao),
constraint fk_Aluno foreign key (IDAluno) references Alunos,
constraint fk_AulaLegislacao foreign key (IDAulaLegislacao) references AulasLegislacao
);

create table Direcao
(
IDDirecao int not null AUTO_INCREMENT,
Materia varchar(25) not null,
DescricaoMateria(100) not null,
Quantidade int not null,
constraint pk_Direcao primary key (IDDirecao)
);
create table AlunosEmDirecao
(
IDAluno int not null,
IDDirecao int not null,
constraint pk_AlunosEmDirecao primary key (IDAluno, IDDirecao),
constraint fk_Alunos foreign key (IDAluno) references Alunos,
constraint fk_Direcao foreign key (IDDirecao) references Direcao
);