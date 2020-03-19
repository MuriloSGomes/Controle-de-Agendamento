using ScheduleMedicControl.Business.Enumeradores;

namespace ScheduleMedicControl.Business
{
    public class EnumeradorSituacaoAgendamento : EnumeradorAbstrato
    {
        public static EnumeradorSituacaoAgendamento AguardandoAtendimento = new EnumeradorSituacaoAgendamento(1, "Aguardando Atendimento");
        public static EnumeradorSituacaoAgendamento Atendido = new EnumeradorSituacaoAgendamento(2, "Atendido");
        public static EnumeradorSituacaoAgendamento NaoCompareceu = new EnumeradorSituacaoAgendamento(3, "Não Compareceu");
        public static EnumeradorSituacaoAgendamento CanceladoPeloUsuario = new EnumeradorSituacaoAgendamento(4, "Cancelado pelo Usuário");
        public static EnumeradorSituacaoAgendamento CanceladoPelaClinica = new EnumeradorSituacaoAgendamento(5, "Cancelado pela Clínica");

        public EnumeradorSituacaoAgendamento(int id, string descricao) : base(id, descricao)
        {
        }
    }
}
