using System;
using Xamarin.Forms;

namespace Utility.Effects
{
    public class SwitchColorEffect : RoutingEffect
    {
        public static readonly BindableProperty ColorProperty =
            BindableProperty.CreateAttached("Color", typeof(Color), typeof(SwitchColorEffect), Color.Default);

        public static Color GetColor(BindableObject view)
        {
            return (Color)view.GetValue(ColorProperty);
        }

        public static void SetColor(BindableObject view, Color value)
        {
            view.SetValue(ColorProperty, value);
        }

        public SwitchColorEffect() : base("Effects.SwitchColorEffect")
        {

        }
    }
}
