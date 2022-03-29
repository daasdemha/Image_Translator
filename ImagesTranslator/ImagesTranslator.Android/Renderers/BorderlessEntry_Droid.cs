using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using ImagesTranslator.Droid.Renderers;
using ImagesTranslator.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntry_Droid))]
namespace ImagesTranslator.Droid.Renderers
{
    public class BorderlessEntry_Droid : EntryRenderer
    {
        public BorderlessEntry_Droid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;
                Control.SetTextColor(global::Android.Graphics.Color.Black);
            }
        }
    }
}