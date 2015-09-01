using Xamarin.Forms;

namespace GiTracker.Controls
{
    public class NiceLabel : Label
    {
        public static readonly BindableProperty IsUnderlinedProperty =
            BindableProperty.Create<NiceLabel, bool>(p => p.IsUnderlined, false);

        public bool IsUnderlined
        {
            get { return (bool) GetValue(IsUnderlinedProperty); }
            set { SetValue(IsUnderlinedProperty, value); }
        }
    }
}