using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMedicControl.Business.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public EnumeradorSituacaoAgendamento SituacaoAgendamento { get; set; }
        public DateTime Data { get; set; }
        public Cliente Cliente { get; set; }
        public Clinica Clinica { get; set; }
    }
}
