using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMedicControl.Business.Interfaces
{
    public interface IValidador<T> where T : class
    {
        void Valide(T instancia);
    }
}
