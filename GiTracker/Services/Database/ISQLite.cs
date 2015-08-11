using SQLite;

namespace GiTracker.Services.Database
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection ();
    }
}

