﻿using Plugin.Multilingual;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasky.Helpers
{
    /*
     * Author: Tamer H. Almurshidi
     */
    [ContentProperty( "Text" )]
    public class Translate : IMarkupExtension
    {
        const string ResourceId = "Tasky.Resx.AppResources";

        static readonly Lazy<ResourceManager> resmgr = new Lazy<ResourceManager>( () => new ResourceManager( ResourceId, typeof( Translate ).GetTypeInfo().Assembly ) );

        public string Text { get; set; }

        public object ProvideValue( IServiceProvider serviceProvider )
        {
            if( Text == null )
                return "";

            var ci = CrossMultilingual.Current.CurrentCultureInfo;
            var translation = resmgr.Value.GetString( Text, ci );

            if( translation == null )
            {
#if DEBUG
                throw new ArgumentException(

                    String.Format( "Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name ),

                    "Text" );
#else
                translation = Text; // returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
    }
}
