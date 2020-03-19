using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMedicControl.Business.Models
{
    public class EntidadeDeNegocio
    {
        public int Id { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return (obj is EntidadeDeNegocio) && ((EntidadeDeNegocio)obj).Id.Equals(Id);
        }
    }
}
