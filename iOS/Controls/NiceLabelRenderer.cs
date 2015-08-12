using GiTracker.Controls;
using System.ComponentModel;
using GiTracker.iOS.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NiceLabel), typeof(NiceLabelRenderer))]
namespace GiTracker.iOS.Controls
{
    public class NiceLabelRenderer : LabelRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(NiceLabel.IsUnderlined))
                Underline();
        }

        void Underline()
        {
            if (Control == null || (Element as NiceLabel) == null) return;
        }
    }
}