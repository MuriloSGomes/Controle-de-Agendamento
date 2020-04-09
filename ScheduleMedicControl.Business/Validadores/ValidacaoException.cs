using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMedicControl.Business.Validadores
{
    public class ValidacaoException : ApplicationException
    {
        public IList<ValidationFailure> Errors { get; private set; }

        public ValidacaoException(ValidationResult validationResult)
        {
            Errors = validationResult.Errors;
        }

    }
}
