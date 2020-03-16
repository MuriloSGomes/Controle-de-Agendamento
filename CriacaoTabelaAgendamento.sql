create Table Agendamento (
	atendimentoId int not null auto_increment,
    atendimentoSituacao char(1),
    atendimentoData date,
    primary key (atendimentoId)
);