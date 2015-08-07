namespace GiTracker.Models
{
    public interface IIssue
    {
        int Id { get; }
        int Number { get; }
        string Url { get; }
        string Title { get; }
        string Body { get; }
    }
}
