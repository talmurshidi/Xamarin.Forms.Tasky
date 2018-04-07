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
using Tasky.Controls;
using Tasky.Droid.RendererAndroid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer( typeof( EntryControl ), typeof( EntryAndroid ) )]
namespace Tasky.Droid.RendererAndroid
{
    public class EntryAndroid : EntryRenderer
    {
        public EntryAndroid( Context context ) : base( context )
        {

        }
    }
}