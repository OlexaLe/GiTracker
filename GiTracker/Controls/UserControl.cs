using System;
using Xamarin.Forms;

namespace GiTracker.Controls
{
    public class UserControl : Grid
    {
        public static readonly BindableProperty ImageUrlProperty =
            BindableProperty.Create<UserControl, string>(p => p.ImageUrl, null, propertyChanged: OnImageUrlPropertyChanged);

        public string ImageUrl
        {
            get { return (string)GetValue(ImageUrlProperty); }
            set { SetValue(ImageUrlProperty, value); }
        }

        static void OnImageUrlPropertyChanged(BindableObject bindable, string oldvalue, string newvalue)
        {
            var control = bindable as UserControl;
            control._image.Source = new UriImageSource { Uri = new Uri(newvalue) };
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create<UserControl, string>(p => p.Text, null, propertyChanged: OnTextPropertyChanged);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        static void OnTextPropertyChanged(BindableObject bindable, string oldvalue, string newvalue)
        {
            var control = bindable as UserControl;
            control._label.Text = newvalue;
        }

        public static readonly BindableProperty LabelStyleProperty =
            BindableProperty.Create<UserControl, Style>(p => p.LabelStyle, null, propertyChanged: OnLabelStylePropertyChanged);

        public Style LabelStyle
        {
            get { return (Style)GetValue(LabelStyleProperty); }
            set { SetValue(LabelStyleProperty, value); }
        }

        static void OnLabelStylePropertyChanged(BindableObject bindable, Style oldvalue, Style newvalue)
        {
            var control = bindable as UserControl;
            control._label.Style = newvalue;
        }

        private readonly Image _image;
        private readonly Label _label;

        public UserControl()
        {
            _image = new Image { Style = (Style)Application.Current.Resources["AvatarStyle"] };
            _label = new Label { Style = (Style)Application.Current.Resources["SmallSimpleLabelStyle"], YAlign = TextAlignment.Center};

            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            Children.Add(_image);
            Children.Add(_label);

            SetColumn(_label, 1);
        }
    }
}