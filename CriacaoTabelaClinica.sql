create Table Clinica (
	clinicaId int not null auto_increment,
    clinicaNome varchar(100),
    clinicaCnpj varchar(14),
    clinicaTelefone varchar(13),
    clinicaEndereco varchar(150),
    primary key (clinicaId)
);