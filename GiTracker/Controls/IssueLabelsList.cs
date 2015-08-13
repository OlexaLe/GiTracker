using System.Collections.Generic;
using GiTracker.Models;
using Xamarin.Forms;

namespace GiTracker.Controls
{
    public class IssueLabelsList : Label
    {
        public IssueLabelsList()
        {
            // TODO: make some line spacing
            Style = (Style) Application.Current.Resources["SmallSimpleLabelStyle"];
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create<IssueLabelsList, IEnumerable<ILabel>>(p => p.ItemsSource, null, propertyChanged: OnItemsSourcePropertyChanged);
        
        public IEnumerable<ILabel> ItemsSource
        {
            get { return (IEnumerable<ILabel>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        static void OnItemsSourcePropertyChanged(BindableObject bindable, IEnumerable<ILabel> oldvalue, IEnumerable<ILabel> newvalue)
        {
            var control = bindable as Label;
            control.FormattedText = null;

            if (newvalue == null) return;

            var formattedString = new FormattedString();
            foreach (var label in newvalue)
            {
                var color = Color.FromHex(label.Color);

                formattedString.Spans.Add(new Span
                {
                    Text = $"\u00A0{label.Name}\u00A0",
                    ForegroundColor = (Color)Application.Current.Resources[(color.Hue > 0 ? "LightTextColor" : "DarkTextColor")],
                    BackgroundColor = color,
                });
                formattedString.Spans.Add(new Span
                {
                    Text = " ",
                });
            }

            control.FormattedText = formattedString;
        }
    }
}