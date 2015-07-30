using System;
using System.Collections.Generic;
using SQLite;

namespace GiTracker.Database
{
    public class DatabaseService : IDatabaseService
    {
        readonly ISQLite _sqliteProvider = Xamarin.Forms.DependencyService.Get<ISQLite> ();

        public DatabaseService ()
        {
            CreateTables ();
        }

        public void Insert<T> (T entity)
        {
            using (var db = GetConnection ()) {
                db.Insert (entity);
            }
        }

        public void InsertAll<T> (IEnumerable<T> entities)
        {
            if (entities == null)
                return;

            using (var db = GetConnection ()) {
                db.InsertAll (entities);
            }
        }

        public void Update<T> (T entity)
        {
            using (var db = GetConnection ()) {
                db.Update (entity);
            }
        }

        public T Get<T> (int key) where T : new()
        {
            using (var db = GetConnection ()) {
                return db.Get<T> (key);
            }
        }

        public IEnumerable<T> GetAll<T> () where T : new()
        {
            using (var db = GetConnection ()) {
                return db.Table<T> ();
            }
        }

        public IEnumerable<T> Find<T> (System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : new()
        {
            using (var db = GetConnection ()) {
                return db.Table<T> ().Where (predicate);
            }
        }

        public T FirstOrDefault<T> () where T : new()
        {
            using (var db = GetConnection ()) {
                return db.Table<T> ().FirstOrDefault ();
            }
        }

        public T FirstOrDefault<T> (Func<T, bool> predicate) where T : new()
        {
            using (var db = GetConnection ()) {
                return db.Table<T> ().FirstOrDefault (predicate);
            }
        }

        public void Delete<T> (T entity)
        {
            using (var db = GetConnection ()) {
                db.Delete (entity);
            }
        }

        public void DropAndCreateDatabase ()
        {
            DropDatabase ();
            CreateTables ();
        }

        public T LastEntity<T> (System.Linq.Expressions.Expression<Func<T, object>> orderFunc) where T : new()
        {
            using (var db = GetConnection ()) {
                return db.Table<T> ().OrderByDescending (orderFunc).Take (1).FirstOrDefault ();
            }
        }

        public void DeleteAll<T> ()
        {
            using (var db = GetConnection ()) {
                db.DeleteAll<T> ();
            }
        }

        public void ReplaceAll<T> (IEnumerable<T> entities)
        {
            DeleteAll<T> ();
            InsertAll (entities);
        }

        public void Delete<T> (int id)
        {
            using (var db = GetConnection ()) {
                db.Delete<T> (id);
            }
        }

        private SQLiteConnection GetConnection ()
        {
            return _sqliteProvider.GetConnection ();
        }

        private void CreateTables ()
        {
            using (var db = GetConnection ()) {
                
            }
        }

        private void DropDatabase ()
        {
            using (var db = GetConnection ()) {
                
            }
        }
    }
}

