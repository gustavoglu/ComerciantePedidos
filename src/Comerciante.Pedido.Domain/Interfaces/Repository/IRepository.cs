using Comerciante.Pedido.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Comerciante.Pedido.Domain.Interfaces.Repository
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        T Criar(T obj);

        IEnumerable<T> Criar(ICollection<T> obj);

        T Atualizar(T obj);

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
