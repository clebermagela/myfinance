create database myfinance;

use myfinance;

create table PLANOCONTA(
	id int not null identity(1,1),
	nome varchar(50) not null,
	tipo char(1) not null,
	primary key(id)
);

create table TRANSACAO(
	id int not null identity(1,1),
	data datetime not null,
	valor decimal(9,2) not null,
	historico varchar(100),
	tipo char(1) not null,
	planocontaid int not null,
	primary key(id),
	foreign key(planocontaid) references PLANOCONTA(id)
);

--Exame especial
CREATE TABLE Pessoa (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL
);

ALTER TABLE Transacao
ADD IdPessoa INT NOT NULL;

ALTER TABLE Transacao
ADD CONSTRAINT FK_Transacao_Pessoa FOREIGN KEY (IdPessoa) REFERENCES Pessoa(Id);

insert into PLANOCONTA(nome, tipo) values ('Combustível','D');
insert into PLANOCONTA(nome, tipo) values ('Alimentação','D');
insert into PLANOCONTA(nome, tipo) values ('Aluguel','D');
insert into PLANOCONTA(nome, tipo) values ('Água','D');
insert into PLANOCONTA(nome, tipo) values ('Luz','D');
insert into PLANOCONTA(nome, tipo) values ('Internet','D');
insert into PLANOCONTA(nome, tipo) values ('Salario','R');
insert into PLANOCONTA(nome, tipo) values ('Crédito de dividendos','R');

insert into TRANSACAO(data, valor, historico, tipo, planocontaid)
values(getdate(), 458, 'Gasolina da Blazer', 'D', 1);

insert into TRANSACAO(data, valor, historico, tipo, planocontaid)
values('2024-11-03 13:05', 128.58, 'Almoço de domingo', 'D', 2);

insert into TRANSACAO(data, valor, historico, tipo, planocontaid)
values('2024-10-01', 25, 'Padaria', 'D', 2);

insert into TRANSACAO(data, valor, tipo, planocontaid)
values('2024-11-05', 1000, 'R', 7);

insert into TRANSACAO(data, valor, historico, tipo, planocontaid)
values('2024-10-31', 868.32, 'Dividendos Itaú', 'R', 8);

insert into TRANSACAO(data, valor, historico, tipo, planocontaid)
values('2024-10-31', 57.89, 'Dividendos Itaú', 'R', 8);