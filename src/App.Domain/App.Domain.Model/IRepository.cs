using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace App.Domain.Model
{
    public interface IRepository
    {
        T Create<T>(T entity) where T : class, ICreatable;
        IEnumerable<T> Read<T>(string[] children = null) where T : class, IReadable;
        IEnumerable<T> Read<T>(Expression<Func<T, bool>> filter, string[] children = null) where T : class, IReadable;
        void Update<T>(T entity) where T : class, IUpdatable;
        void Delete<T>(T entity) where T : class, IDeletable;
        void Delete<T>() where T : class, IDeletable;
        void Commit();
    }

    public interface ICreatable { }
    public interface IReadable { }
    public interface IUpdatable { }
    public interface IDeletable { }

    public interface HasID
    {
        int ID { get; set; }
    }
}