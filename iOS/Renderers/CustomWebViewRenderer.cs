using System;
using System.IO;
using System.Net;

using UIKit;
using WebKit;
using Foundation;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using Utility.Views;
using Utility.iOS;


[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace Utility.iOS
{
    // UIWebView
    //public class CustomWebViewRenderer : ViewRenderer<CustomWebView, UIWebView>
    //{
    //    protected override void OnElementChanged(ElementChangedEventArgs<CustomWebView> e)
    //    {
    //        base.OnElementChanged(e);

    //        if (Control == null)
    //        {
    //            SetNativeControl(new UIWebView());
    //        }
    //        if (e.OldElement != null)
    //        {
    //            // Cleanup
    //        }
    //        if (e.NewElement != null)
    //        {
    //            var customWebView = Element as CustomWebView;
    //            string fileName = Path.Combine(NSBundle.MainBundle.BundlePath, string.Format("Content/{0}", WebUtility.UrlEncode(customWebView.Uri)));
    //            Control.LoadRequest(new NSUrlRequest(new NSUrl(fileName, false)));
    //            Control.ScalesPageToFit = true;
    //        }
    //    }
    //}

    // WKWebView
    public class CustomWebViewRenderer : ViewRenderer<CustomWebView, WKWebView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CustomWebView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new WKWebView(Frame, new WKWebViewConfiguration()));
            }
            if (e.OldElement != null)
            {
                // Cleanup
            }
            if (e.NewElement != null)
            {
                var customWebView = Element as CustomWebView;
                string fileName = Path.Combine(NSBundle.MainBundle.BundlePath, string.Format("Content/{0}", WebUtility.UrlEncode(customWebView.Uri)));
                File.OpenRead(fileName);
                Control.LoadRequest(new NSUrlRequest(new NSUrl(fileName, false)));
                //Control.ScalesPageToFit = true;

            }
        }
    }
}
