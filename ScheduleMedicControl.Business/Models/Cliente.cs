using System;
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

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Adicione um telefone")]
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string  Email { get; set; }
        public bool TemConvenio { get; set; }

        [Display(Name = "Numero do convênio")]
        public string NumeroConvenio { get; set; }

        [Display(Name = "Nome do convênio")]
        public string NomeConvenio { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}
