using System;
using UIKit;
using Utility.iOS.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

// ResolutionGroupName is only once per project
[assembly: ResolutionGroupName("Effects")]
[assembly: ExportEffect(typeof(SwitchColorEffect), "SwitchColorEffect")]
namespace Utility.iOS.Effects
{
    public class SwitchColorEffect : PlatformEffect
    {
        UISwitch control;

        public SwitchColorEffect()
        {
        }

        protected override void OnAttached()
        {
            control = (UISwitch)Control;

            control.OnTintColor = Utility.Effects.SwitchColorEffect.GetColor(Element).ToUIColor();
        }

        protected override void OnDetached()
        {
            
        }
    }
}
