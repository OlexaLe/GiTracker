using GiTracker.Helpers;
using GiTracker.Resources.Strings;

namespace GiTracker.Models
{
    public enum IssueStatus
    {
        [EnumDescription("IssueStatusOpen", typeof(Enums))]
        Open,

        [EnumDescription("IssueStatusClosed", typeof(Enums))]
        Closed
    }
}