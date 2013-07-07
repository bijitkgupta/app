using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Domain.Model;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;

namespace App.DAL.EF
{
    public class EFRepository : IRepository
    {
        private DbContext context = null;
        public EFRepository(string connectionString)
        {
            this.context = new AppDbContext(connectionString);
        }

        public T Create<T>(T entity) where T : class, ICreatable
        {
            return context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : class, IDeletable
        {
            context.Set<T>().Remove(entity);
        }

        public void Delete<T>() where T : class, IDeletable
        {
            foreach (var item in context.Set<T>())
            {
                context.Set<T>().Remove(item);
            }
        }

        public IEnumerable<T> Read<T>(string[] children = null) where T : class, IReadable
        {
            IEnumerable<T> result;
            var set = context.Set<T>();
            if (children == null || children.Length == 0)
                result = set.AsEnumerable<T>().ToList();
            else
            {
                IQueryable<T> setQuery = set;
                foreach (string child in children)
                {
                    setQuery = setQuery.Include(child);
                }
                var ret = set.AsEnumerable<T>();
                result = ret.ToList();
            }
            return result;
        }

        public IEnumerable<T> Read<T>(Expression<Func<T, bool>> filter, string[] children = null) where T : class, IReadable
        {
            var set = context.Set<T>().Where(filter);
            if (children == null || children.Length == 0)
                return set.AsEnumerable<T>();
            else
            {
                IQueryable<T> setQuery = set;
                foreach (string child in children)
                {
                    setQuery = setQuery.Include(child);
                }
                var ret = setQuery.AsEnumerable<T>();
                return ret;
            }
        }

        public void Update<T>(T entity) where T : class, IUpdatable
        {
            context.Entry<T>(entity).State = System.Data.EntityState.Modified;
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
