using FluentValidation;
using ScheduleMedicControl.Business.Interfaces;
using ScheduleMedicControl.Business.Models;
using System;
using System.Linq;

namespace ScheduleMedicControl.Business.Validadores
{
    public class ValidacaoAgendamento : ValidacaoCadastro<Agendamento>
    {
        public override void AssineRegrasAtualizacao()
        {
            throw new NotImplementedException();
        }

        public override void AssineRegrasInclusao(Agendamento agendamento)
        {
            if (agendamento.Agendamentos.Any())
            {
                RuleFor(cliente => cliente.Agendamentos).Must(x => x.Exists(y => y.Cliente.Id != agendamento.ClienteId)).WithMessage("Paciente ja possui cadastro nessa clinica");
            }
        }
    }
}
