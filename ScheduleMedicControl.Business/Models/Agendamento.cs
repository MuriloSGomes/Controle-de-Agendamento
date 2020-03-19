using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMedicControl.Business.Models
{
    public class Agendamento : EntidadeDeNegocio
    {

        [Display(Name = "Situação do Agendamento")]
        [Required(ErrorMessage = "Selecione ao menos uma situação")]
        public EnumeradorSituacaoAgendamento SituacaoAgendamento { get; set; }

        [Display(Name = "Data")]
        [Required(ErrorMessage ="Selecione a data do agendamento")]
        public DateTime Data { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Selecione pelo menos 1 cliente")]
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "Selecione pelo menos 1 clinica")]
        [Display(Name = "Clinica")]
        public Clinica Clinica { get; set; }

        public IEnumerable<EnumeradorSituacaoAgendamento> temp()
        {
            return EnumeradorSituacaoAgendamento.ObtenhaTodos<EnumeradorSituacaoAgendamento>();
        }
    }
}
