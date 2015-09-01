using System;
using Xamarin.Forms;

namespace GiTracker.Controls
{
    public class ImageWithLabel : Grid
    {
        public static readonly BindableProperty ImageUrlProperty =
            BindableProperty.Create<ImageWithLabel, string>(p => p.ImageUrl, null,
                propertyChanged: OnImageUrlPropertyChanged);

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create<ImageWithLabel, string>(p => p.Text, null, propertyChanged: OnTextPropertyChanged);

        public static readonly BindableProperty SecondaryTextProperty =
            BindableProperty.Create<ImageWithLabel, string>(p => p.SecondaryText, null,
                propertyChanged: OnSecondaryTextPropertyChanged);

        public static readonly BindableProperty LabelStyleProperty =
            BindableProperty.Create<ImageWithLabel, Style>(p => p.LabelStyle, null,
                propertyChanged: OnLabelStylePropertyChanged);

        private readonly Image _image;
        private readonly Label _label, _secondaryLabel;

        public ImageWithLabel()
        {
            _image = new Image {Style = (Style) Application.Current.Resources["AvatarStyle"]};
            _label = new Label
            {
                Style = (Style) Application.Current.Resources["SmallSimpleLabelStyle"],
                YAlign = TextAlignment.Center
            };
            _secondaryLabel = new Label
            {
                Style = (Style) Application.Current.Resources["SmallSimpleLabelStyle"],
                YAlign = TextAlignment.Center
            };

            ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Auto});
            ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Auto});

            RowDefinitions.Add(new RowDefinition {Height = GridLength.Auto});
            RowDefinitions.Add(new RowDefinition {Height = GridLength.Auto});

            Children.Add(_image);
            Children.Add(_label);
            Children.Add(_secondaryLabel);

            SetColumn(_label, 1);
            SetColumn(_secondaryLabel, 1);
            SetRow(_secondaryLabel, 1);
            SetRowSpan(_image, 2);
        }

        public string ImageUrl
        {
            get { return (string) GetValue(ImageUrlProperty); }
            set { SetValue(ImageUrlProperty, value); }
        }

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string SecondaryText
        {
            get { return (string) GetValue(SecondaryTextProperty); }
            set { SetValue(SecondaryTextProperty, value); }
        }

        public Style LabelStyle
        {
            get { return (Style) GetValue(LabelStyleProperty); }
            set { SetValue(LabelStyleProperty, value); }
        }

        private static void OnImageUrlPropertyChanged(BindableObject bindable, string oldvalue, string newvalue)
        {
            var control = bindable as ImageWithLabel;
            control._image.Source = new UriImageSource {Uri = new Uri(newvalue)};
        }

        private static void OnTextPropertyChanged(BindableObject bindable, string oldvalue, string newvalue)
        {
            var control = bindable as ImageWithLabel;
            control._label.Text = newvalue;
        }

        private static void OnSecondaryTextPropertyChanged(BindableObject bindable, string oldvalue, string newvalue)
        {
            var control = bindable as ImageWithLabel;
            control._secondaryLabel.Text = newvalue;
        }

        private static void OnLabelStylePropertyChanged(BindableObject bindable, Style oldvalue, Style newvalue)
        {
            var control = bindable as ImageWithLabel;
            control._label.Style = newvalue;
            control._secondaryLabel.Style = newvalue;
        }
    }
}