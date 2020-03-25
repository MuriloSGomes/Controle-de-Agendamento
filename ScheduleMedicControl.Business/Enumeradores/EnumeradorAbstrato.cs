using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ScheduleMedicControl.Business.Enumeradores
{
    public abstract class EnumeradorAbstrato : IComparable
    {
        public string Descricao { get; private set; }

        public int Id { get; private set; }

        protected EnumeradorAbstrato(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public override string ToString() => Descricao;

        public static IEnumerable<T> ObtenhaTodos<T>() where T : EnumeradorAbstrato
        {
            var fields = typeof(T).GetFields(BindingFlags.Public |
                                             BindingFlags.Static |
                                             BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public static T ObtenhaPorId<T>(int codigoSituacao) where T : EnumeradorAbstrato
        {
            var todos = ObtenhaTodos<T>();

            var test = todos.Where(x => x.Id == codigoSituacao).FirstOrDefault();

            return test;
        }

        public override bool Equals(object enumeradorHerdado)
        {
            var enumerador = enumeradorHerdado as EnumeradorAbstrato;

            if (enumerador == null)
                return false;

            var ehTipoEnumerador = GetType().Equals(enumeradorHerdado.GetType());
            var verificaId = Id.Equals(enumerador.Id);

            return ehTipoEnumerador && verificaId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object enumeradorId) => Id.CompareTo(((EnumeradorAbstrato)enumeradorId).Id);

    }
}
