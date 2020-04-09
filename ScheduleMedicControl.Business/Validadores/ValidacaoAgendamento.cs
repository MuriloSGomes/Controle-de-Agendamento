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
            RuleFor(entidade=>entidade.ClienteId).Must
        }

        private bool PacienteAgendado(int codigo)
        {
            return new AgendamentoRepositorio
        }
    }
}
