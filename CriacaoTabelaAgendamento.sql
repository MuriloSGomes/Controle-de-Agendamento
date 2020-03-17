create Table Agendamento (
	agendamentoId int not null auto_increment,
    agendamentoSituacao char(1),
    agendamentoData date,
    primary key (agendamentoId),
	foreign key (agendamentoId) references cliente(clienteId),
	foreign key (agendamentoId) references clinica(clinicaId)
);
