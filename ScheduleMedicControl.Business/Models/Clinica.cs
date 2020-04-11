using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMedicControl.Business.Models
{
    public class Clinica : EntidadeDeNegocio
    {
        [Display(Name = "Clinica")]
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public Agendamento Agendamento { get; set; }

        public int Vagas { get; set; }

        public override string ToString()
        {
            return Nome;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return (obj is Clinica) && ((Clinica)obj).Id.Equals(this.Id);
        }

    }
}
