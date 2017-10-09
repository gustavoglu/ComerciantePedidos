using Comerciante.Pedido.Domain.Core.Models;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Comerciante.Pedido.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Comerciante.Pedido.Infra.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {

        private readonly ContextPedidos _db;
        private readonly DbSet<T> DbSet;

        public Repository(ContextPedidos db)
        {
            _db = db;
            DbSet = _db.Set<T>();
        }

        public void Atualizar(T obj)
        {
            DbSet.Update(obj);
            Save();
        }

        public void Criar(T obj)
        {
            DbSet.Add(obj);
            Save();
        }

        public void Criar(ICollection<T> obj)
        {
            foreach (var objeto in obj)
                DbSet.Add(objeto);

            Save();
        }

        public int Deletar(Guid id)
        {
            var obj = this.TrazerPorId(id);
            DbSet.Remove(obj);
            return Save();
        }

        public IEnumerable<T> Pesquisar(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IEnumerable<T> PesquisarAtivos(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(o => o.Deletado == false).Where(predicate);
        }

        public IEnumerable<T> PesquisarDeletados(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(o => o.Deletado == true).Where(predicate);
        }

        public IEnumerable<T> TrazerAtivos()
        {
            return DbSet.Where(o => o.Deletado == false);
        }

        public IEnumerable<T> TrazerDeletados()
        {
            return DbSet.Where(o => o.Deletado == true);
        }

        public T TrazerPorId(Guid id)
        {
            return DbSet.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<T> TrazerTodos()
        {
            return DbSet;
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        int Save()
        {
            return _db.SaveChanges();
        }
    }
}
