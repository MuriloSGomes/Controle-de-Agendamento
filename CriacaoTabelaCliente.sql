create Table Cliente (
    clienteId int not null auto_increment,
    clienteNome varchar(100),
    clienteTelefone varchar(12),
    clienteCpf varchar(11),
    clienteEmail varchar(50),
    clienteTemConvenio bool,
    clienteNumeroConvenio varchar(100),
    clienteNomeConvenio varchar(50),
    primary key (clienteid),
    foreign key (clienteId) references agendamento(agendamentoId)
);
