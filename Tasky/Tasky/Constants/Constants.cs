using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Tasky.Constants
{
    public class Constants
    {
        public static Color PRIMARY_COLOR = App.Current.Resources.ContainsKey( "PrimaryColor" ) ? (Color)App.Current.Resources["PrimaryColor"] : Color.DarkBlue;
        public static Color PRIMARY_DARK_COLOR = (Color)App.Current.Resources["PrimaryDarkColor"];
        public static Color PRIMARY_LIGHT_COLOR = (Color)App.Current.Resources["PrimaryLightColor"];
        public static Color ACCENT_COLOR = (Color)App.Current.Resources["AccentColor"];
        public static Color PRIMARY_TEXT_COLOR = (Color)App.Current.Resources["PrimaryTextColor"];
        public static Color TEXT_COLOR = (Color)App.Current.Resources["TextColor"];
        public static Color SECONDARY_TEXT_COLOR = (Color)App.Current.Resources["SecondaryTextColor"];
        public static Color DIVIDER_COLOR = (Color)App.Current.Resources["DividerColor"];
        public static Color CONTENT_PAGE_BACKGROUND_COLOR = (Color)App.Current.Resources["ContentPageBackgroundColor"];

        public static double LARGE_FONET_SIZE = (double)App.Current.Resources["LargeFontSize"];
        public static double MEDIUM_FONT_SIZE = (double)App.Current.Resources["MediumFontSize"];
        public static double SMALL_FONT_SIZE = (double)App.Current.Resources["SmallFontSize"];
        public static double MICRO_FONT_SIZE = (double)App.Current.Resources["MicroFontSize"];
    }
}
