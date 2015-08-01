using SQLite;

namespace GiTracker.Database
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection ();
    }
}

