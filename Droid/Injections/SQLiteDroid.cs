using System;
using Xamarin.Forms;
using GiTracker.Droid.Injections;
using GiTracker.Database;
using System.IO;

[assembly: Dependency (typeof(SQLiteDroid))]

namespace GiTracker.Droid.Injections
{
    public class SQLiteDroid : ISQLite
    {
        public SQLite.SQLiteConnection GetConnection ()
        {
            var documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);
            var path = Path.Combine (documentsPath, Constants.DatabaseName);
            return new SQLite.SQLiteConnection (path);
        }
    }
}

