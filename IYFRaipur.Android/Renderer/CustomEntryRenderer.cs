using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Text;
using CustomRenderer.Android;
using IYFRaipur;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

#pragma warning disable CS0612 // Type or member is obsolete
[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
#pragma warning restore CS0612 // Type or member is obsolete
[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace CustomRenderer.Android
{
    [System.Obsolete]
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(global::Android.Graphics.Color.Transparent);
                this.Control.SetBackgroundDrawable(gd);
                this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.LightGray));
            }
        }
    }
    public class CustomEditorRenderer : EditorRenderer
    {
        public CustomEditorRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(global::Android.Graphics.Color.Transparent);
                this.Control.SetBackgroundDrawable(gd);
                this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Black));
            }
        }
    }
}