using System;
using System.Collections.Generic;

namespace GiTracker.Services.Database
{
    public interface IDatabaseService
    {
        void Insert<T> (T entity);

        void InsertAll<T> (IEnumerable<T> entities);

        void Update<T> (T entity);

        T Get<T> (int key) where T : new();

        IEnumerable<T> GetAll<T> () where T : new();

        IEnumerable<T> Find<T> (System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : new();

        T FirstOrDefault<T> () where T : new();

        T FirstOrDefault<T> (System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : new();

        void Delete<T> (T entity);

        void Delete<T> (int id);

        void DropAndCreateDatabase ();

        T LastEntity<T> (System.Linq.Expressions.Expression<Func<T, object>> orderFunc) where T : new();

        void DeleteAll<T> ();

        void ReplaceAll<T> (IEnumerable<T> entities);
    }
}

