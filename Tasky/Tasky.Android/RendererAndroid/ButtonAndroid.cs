using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Tasky.Controlls;
using Tasky.Droid.RendererAndroid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer( typeof( ButtonControl ), typeof( ButtonAndroid ) )]
namespace Tasky.Droid.RendererAndroid
{
    public class ButtonAndroid : ButtonRenderer
    {
        public ButtonAndroid( Context context ) : base( context )
        {

        }
    }
}