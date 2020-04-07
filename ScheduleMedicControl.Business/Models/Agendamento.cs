using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ScheduleMedicControl.Business.Models
{
    public class Agendamento : EntidadeDeNegocio
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Cadastramento")]
        [Required(ErrorMessage ="Selecione a data do agendamento")]
        public DateTime Data { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Selecione pelo menos 1 cliente")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Selecione pelo menos 1 clinica")]
        [Display(Name = "Clinica")]
        public int ClinicaId { get; set; }

        public List<Agendamento> Agendamentos { get; set; }

        [Display(Name = "Situação")]
        [Required(ErrorMessage = "Selecione situação")]
        public EnumeradorSituacaoAgendamento Situacao { get; set; }

        public SelectList MyProperty { get; set; }
    }
}
