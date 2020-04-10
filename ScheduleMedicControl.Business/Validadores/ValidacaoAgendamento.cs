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

        public override void AssineRegrasInclusao()
        {
            RuleFor(cliente => cliente.Cliente).NotNull().WithMessage("temp");
        }
    }
}
