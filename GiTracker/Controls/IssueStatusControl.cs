using GiTracker.Converters;
using GiTracker.Models;
using Xamarin.Forms;

namespace GiTracker.Controls
{
    public class IssueStatusControl : Grid
    {
        public static readonly BindableProperty IssueStatusProperty =
            BindableProperty.Create<IssueStatusControl, IssueStatus>(p => p.IssueStatus, IssueStatus.None);

        private readonly Image _image;
        private readonly Label _label;

        public IssueStatusControl()
        {
            Padding = 6;

            _image = new Image {HeightRequest = 20, WidthRequest = 20};
            _label = new Label
            {
                TextColor = Color.White,
                Style = (Style) Application.Current.Resources["SmallSimpleLabelStyle"],
                YAlign = TextAlignment.Center
            };

            ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Auto});
            ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Auto});

            Children.Add(_image);
            Children.Add(_label);
            SetColumn(_label, 1);

            SetBindings();
        }

        public IssueStatus IssueStatus
        {
            get { return (IssueStatus) GetValue(IssueStatusProperty); }
            set { SetValue(IssueStatusProperty, value); }
        }

        private void SetBindings()
        {
            SetBinding(BackgroundColorProperty, new Binding
            {
                Source = this,
                Path = nameof(IssueStatus),
                Converter = new IssueStatusToColorConverter()
            });

            _label.SetBinding(Label.TextProperty, new Binding
            {
                Source = this,
                Path = nameof(IssueStatus),
                Converter = new IssueStatusToTextConverter()
            });

            _image.SetBinding(Image.SourceProperty, new Binding
            {
                Source = this,
                Path = nameof(IssueStatus),
                Converter = new IssueStatusToIconConverter(),
                ConverterParameter = "White"
            });
        }
    }
}