using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMedicControl.Business.Models
{
    public class Clinica
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }
}
