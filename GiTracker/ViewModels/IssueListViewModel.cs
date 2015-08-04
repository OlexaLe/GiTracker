using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiTracker.Services.Api;

namespace GiTracker.ViewModels
{
    public class IssueListViewModel : BaseViewModel
    {
        readonly IGitApiService _gitApiService;

        public IssueListViewModel(IGitApiServiceFactory gitApiServiceFactory)
        {
            _gitApiService = gitApiServiceFactory.GetApiService();
        }

    }
}
