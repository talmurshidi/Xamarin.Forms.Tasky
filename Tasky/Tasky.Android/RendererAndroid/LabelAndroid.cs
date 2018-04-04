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

[assembly: ExportRenderer(typeof(LabelControl),typeof(LabelAndroid))]
namespace Tasky.Droid.RendererAndroid
{
    public class LabelAndroid : LabelRenderer
    {
        public LabelAndroid( Context context ) : base( context )
        {

        }
    }
}