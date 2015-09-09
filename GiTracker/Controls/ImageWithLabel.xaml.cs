using Xamarin.Forms;

namespace GiTracker.Controls
{
    public partial class ImageWithLabel : ContentView
    {
        public static readonly BindableProperty ImageUrlProperty =
            BindableProperty.Create<ImageWithLabel, string>(p => p.ImageUrl, null);

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create<ImageWithLabel, string>(p => p.Text, null);

        public static readonly BindableProperty SecondaryTextProperty =
            BindableProperty.Create<ImageWithLabel, string>(p => p.SecondaryText, null);

        public ImageWithLabel()
        {
            InitializeComponent();
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
    }
}