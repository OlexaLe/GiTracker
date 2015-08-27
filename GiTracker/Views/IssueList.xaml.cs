using Xamarin.Forms;

namespace GiTracker.Views
{
    public partial class IssueList : TabbedPage
    {
        public IssueList()
        {
            InitializeComponent();


            //BasePage.SetTitleBinding(this);
            //SetBinding(ItemsSourceProperty, new Binding { Path = nameof(IssueListViewModel.Tabs) });
            //ItemTemplate = new DataTemplate(() => new IssueListTab());
        }
    }
}