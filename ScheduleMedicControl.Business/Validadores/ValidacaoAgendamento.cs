using FluentValidation;
using ScheduleMedicControl.Business.Models;
using System;


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
            RuleFor(entidade => entidade.Agendamentos).Custom((list, context) =>
            {
                if (list == null)
                {
                    context.AddFailure("The list must contain 10 items or fewer");
                }
            });
        }
    }
}
