using GiTracker.Models;
using Xamarin.Forms;

namespace GiTracker.Controls
{
    public partial class IssueStatusControl : ContentView
    {
        public static readonly BindableProperty IssueStatusProperty =
            BindableProperty.Create<IssueStatusControl, IssueStatus>(p => p.IssueStatus, IssueStatus.None);

        public IssueStatusControl()
        {
            InitializeComponent();
        }

        public IssueStatus IssueStatus
        {
            get { return (IssueStatus) GetValue(IssueStatusProperty); }
            set { SetValue(IssueStatusProperty, value); }
        }
    }
}