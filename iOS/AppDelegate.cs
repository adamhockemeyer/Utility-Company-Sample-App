using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using ImageCircle.Forms.Plugin.iOS;

namespace Utility.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule());

            global::Xamarin.Forms.Forms.Init();

            ImageCircleRenderer.Init();

            FormsPlugin.Iconize.iOS.IconControls.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
