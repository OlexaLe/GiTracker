namespace GiTracker.Models
{
    public interface IUser
    {
        int Id { get; }
        string Login { get; }
        string AvatarUrl { get; }
        string Url { get; }
    }
}