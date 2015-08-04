using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiTracker.Models
{
    interface IIssue
    {
        int Id { get; }
        int Number { get; }
        string Url { get; }
        string Title { get; }
        string Body { get; }
    }
}
