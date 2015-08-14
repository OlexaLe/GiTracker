using GiTracker.Droid.Injections;
using GiTracker.Services.Database;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency (typeof(SQLiteDroid))]

namespace GiTracker.Droid.Injections
{
    public class SQLiteDroid : ISQLite
    {
        public SQLite.SQLiteConnection GetConnection ()
        {
            var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
            var path = Path.Combine (documentsPath, Constants.DatabaseName);
            return new SQLite.SQLiteConnection (path);
        }
    }
}

