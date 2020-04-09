using ScheduleMedicControl.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMedicControl.Business.Validadores
{
    public abstract class ValidacaoCadastro<T> : ValidacaoAbstrato<T>, IValidador<T>
         where T : class
    {
        public abstract void AssineRegrasInclusao();
        public abstract void AssineRegrasAtualizacao();
    }
}
