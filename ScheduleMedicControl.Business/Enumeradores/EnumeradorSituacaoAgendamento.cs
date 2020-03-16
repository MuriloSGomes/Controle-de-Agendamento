using ScheduleMedicControl.Business.Enumeradores;

namespace ScheduleMedicControl.Business
{
    public class EnumeradorSituacaoAgendamento : EnumeradorSeguro
    {
        public EnumeradorSituacaoAgendamento AguardandoAtendimento = new EnumeradorSituacaoAgendamento(1, "Aguardando Atendimento");
        public EnumeradorSituacaoAgendamento Atendido = new EnumeradorSituacaoAgendamento(2, "Atendido");
        public EnumeradorSituacaoAgendamento NaoCompareceu = new EnumeradorSituacaoAgendamento(3, "Não Compareceu");
        public EnumeradorSituacaoAgendamento CanceladoPeloUsuario = new EnumeradorSituacaoAgendamento(4, "Cancelado pelo Usuário");
        public EnumeradorSituacaoAgendamento CanceladoPelaClinica = new EnumeradorSituacaoAgendamento(5, "Cancelado pela Clínica");

        public EnumeradorSituacaoAgendamento(int id, string descricao) : base(id, descricao)
        {
        }
    }
}
