use mvcteste
go

select * from usuario
go

create table Perfil
(
	IdPerfil integer not null identity (1,1),
	Descricao varchar(50) not null,
	constraint PK_Perfil primary key (IdPerfil)
)
go

insert into perfil values ('Administrador'), ('Usuário')
go

create table PerfilUsuario
(
	IdPerfil integer not null,
	IdUsuario integer not null,
	DataAutorizacao datetime not null,
	constraint PK_PerfilUsuario primary key (IdPerfil, IdUsuario),
	constraint FK_PerfilUsuario_Usuario foreign key (IdUsuario)
		references Usuario (IdUsuario),
	constraint FK_PerfilUsuario_Perfil foreign key (IdPerfil)
		references Perfil (IdPerfil)
)
go

insert into usuario values ('admin', 'admin'), ('user', 'user')
go

insert into perfilusuario values 
(1, 1, getdate()), (2, 1, getdate()),
(1, 2, getdate()), (2, 3, getdate())
go