using Android.Graphics;
using GiTracker.Controls;
using GiTracker.Droid.Controls;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NiceLabel), typeof(NiceLabelRenderer))]
namespace GiTracker.Droid.Controls
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

            if (((NiceLabel) Element).IsUnderlined)
                Control.PaintFlags |= PaintFlags.UnderlineText;
        }
    }
}