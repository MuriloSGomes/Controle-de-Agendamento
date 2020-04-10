﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMedicControl.Business.Models
{
    public class Cliente : EntidadeDeNegocio
    {
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string  Email { get; set; }
        public bool TemConvenio { get; set; }
        public string NumeroConvenio { get; set; }
        public string NomeConvenio { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}
