create database controleAgendamento;

use controleAgendamento;

create Table Cliente (
    clienteId int not null auto_increment,
    clienteNome varchar(100),
    clienteTelefone varchar(12),
    clienteCpf varchar(11),
    clienteEmail varchar(50),
    clienteTemConvenio bool,
    clienteNumeroConvenio varchar(100),
    clienteNomeConvenio varchar(50),
    primary key (clienteid)
);


create Table Clinica (
    clinicaId int not null auto_increment,
    clinicaNome varchar(100),
    clinicaCnpj varchar(14),
    clinicaTelefone varchar(13),
    clinicaEndereco varchar(150),
    primary key (clinicaId)
);


create Table Agendamento (
	agendamentoId int not null auto_increment,
        agendamentoSituacao char(1),
        agendamentoData date,
        agendamentoClinicaId int,
        agendamentoClienteId int,
        primary key (agendamentoId),
	foreign key (agendamentoClienteId) references cliente(clienteId),
	foreign key (agendamentoClinicaId) references clinica(clinicaId)
);
