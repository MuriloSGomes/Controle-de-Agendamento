using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ScheduleMedicControl.Business.Enumeradores
{
    public abstract class EnumeradorSeguro : IComparable
    {
        public string Descricao { get; private set; }

        public int Id { get; private set; }

        protected EnumeradorSeguro(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public override string ToString() => Descricao;

        public static IEnumerable<T> ObtenhaTodos<T>() where T : EnumeradorSeguro
        {
            var fields = typeof(T).GetFields(BindingFlags.Public |
                                             BindingFlags.Static |
                                             BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object enumeradorHerdado)
        {
            var enumerador = enumeradorHerdado as EnumeradorSeguro;

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

        public int CompareTo(object enumeradorId) => Id.CompareTo(((EnumeradorSeguro)enumeradorId).Id);

    }
}
