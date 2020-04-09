using FluentValidation;
using ScheduleMedicControl.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMedicControl.Business.Validadores
{
    public abstract class ValidacaoAbstrato<T> : AbstractValidator<T>, IValidador<T> where T : class
    {
        public void Valide(T instancia)
        {
            var validationResult = Validate(instancia);
            if (!validationResult.IsValid)
            {
                throw new ValidacaoException(validationResult);
            }
        }
    }
}
