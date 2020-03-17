﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace ScheduleMedicControl.DATA.Repositorio
{
    public abstract class RepositorioAbstrato<T, TKey>
    where T : class
    {
        protected string StringConnection { get; } = WebConfigurationManager.ConnectionStrings["controleagendamento"].ConnectionString;

        public abstract List<T> ObtenhaTodos();
        public abstract T ObtenhaPeloId(TKey id);
        public abstract void Insira(T entity);
        public abstract void Atualiza(T entity);
        public abstract void Delete(T entity);
        public abstract void DeletePorId(TKey id);
    }
}
