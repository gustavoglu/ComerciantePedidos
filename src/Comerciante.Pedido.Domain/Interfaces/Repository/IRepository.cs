using Comerciante.Pedido.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Comerciante.Pedido.Domain.Interfaces.Repository
{
    public interface IRepository<T> where T : Entity
    {
        void Criar(T obj);

        void Criar(ICollection<T> obj);

        void Atualizar(T obj);

        int Deletar(Guid id);

        T TrazerPorId(Guid id);

        IEnumerable<T> TrazerTodos();

        IEnumerable<T> TrazerAtivos();

        IEnumerable<T> TrazerDeletados();

        IEnumerable<T> Pesquisar(Expression<Func<T,bool>> predicate);

        IEnumerable<T> PesquisarAtivos(Expression<Func<T, bool>> predicate);

        IEnumerable<T> PesquisarDeletados(Expression<Func<T, bool>> predicate);
    }
}
