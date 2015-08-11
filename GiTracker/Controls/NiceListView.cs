using System.Windows.Input;
using Xamarin.Forms;

namespace GiTracker.Controls
{
    public class NiceListView : ListView
    {
        public NiceListView() 
		{
			HasUnevenRows = true;
            IsPullToRefreshEnabled = true;
            ItemTapped += NiceListView_ItemTapped;
		}

        void NiceListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            SelectedItem = null;

            if (ItemClickedCommand != null && ItemClickedCommand.CanExecute(e.Item))
                ItemClickedCommand.Execute(e.Item);
        }

        public static readonly BindableProperty ItemClickedCommandProperty =
            BindableProperty.Create<NiceListView, ICommand>(p => p.ItemClickedCommand, null);

        public ICommand ItemClickedCommand
        {
            get { return (ICommand)GetValue(ItemClickedCommandProperty); }
            set { SetValue(ItemClickedCommandProperty, value); }
        }
    }
}
