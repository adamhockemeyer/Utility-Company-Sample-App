using System;
using Android.Support.V7.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Effects")]
[assembly: ExportEffect(typeof(Utility.Droid.Effects.SwitchColorEffect), "SwitchColorEffect")]
namespace Utility.Droid.Effects
{

    /// <summary>
    /// Note: An alternative to changing the color with an effect on Android is to edit the styles.xml under Resources/values/styles.xml.
    /// </summary>
    public class SwitchColorEffect : PlatformEffect
    {
        SwitchCompat control;

        public SwitchColorEffect()
        {
        }


        protected override void OnAttached()
        {
            control = (SwitchCompat)Control;

            control.CheckedChange += Control_CheckedChange;

            var color = Utility.Effects.SwitchColorEffect.GetColor(Element).ToAndroid();

            control.ThumbDrawable.SetColorFilter(color, Android.Graphics.PorterDuff.Mode.Multiply);
            control.TrackDrawable.SetColorFilter(color, Android.Graphics.PorterDuff.Mode.Multiply);
        }



        protected override void OnDetached()
        {
            control.CheckedChange -= Control_CheckedChange;
        }

        void Control_CheckedChange(object sender, Android.Widget.CompoundButton.CheckedChangeEventArgs e)
        {
            var color = Utility.Effects.SwitchColorEffect.GetColor(Element);

            if(e.IsChecked)
            {
              
                control.TrackDrawable.SetColorFilter(color.ToAndroid(), Android.Graphics.PorterDuff.Mode.Multiply);
            }
            else
            {
                control.TrackDrawable.SetColorFilter(color.AddLuminosity(-0.25).ToAndroid(), Android.Graphics.PorterDuff.Mode.Multiply);
            }
        }

    }
}
