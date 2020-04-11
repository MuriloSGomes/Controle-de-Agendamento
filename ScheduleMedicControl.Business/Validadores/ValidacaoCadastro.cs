using ScheduleMedicControl.Business.Interfaces;


namespace ScheduleMedicControl.Business.Validadores
{
    public abstract class ValidacaoCadastro<T> : ValidacaoAbstrato<T>, IValidador<T>
         where T : class
    {
        public abstract void AssineRegrasInclusao(T model);
        public abstract void AssineRegrasAtualizacao();
    }
}
