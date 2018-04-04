using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Tasky.Constants
{
    public class Constants
    {
        public static Color PRIMARY_COLOR = (Color)App.Current.Resources["PrimaryColor"];
        public static Color PRIMARY_DARK_COLOR = (Color)App.Current.Resources["PrimaryDarkColor"];
        public static Color PRIMARY_LIGHT_COLOR = (Color)App.Current.Resources["PrimaryLightColor"];
        public static Color ACCENT_COLOR = (Color)App.Current.Resources["AccentColor"];
        public static Color PRIMARY_TEXT_COLOR = (Color)App.Current.Resources["PrimaryTextColor"];
        public static Color TEXT_COLOR = (Color)App.Current.Resources["TextColor"];
        public static Color SECONDARY_TEXT_COLOR = (Color)App.Current.Resources["SecondaryTextColor"];
        public static Color DIVIDER_COLOR = (Color)App.Current.Resources["DividerColor"];
        public static Color CONTENT_PAGE_BACKGROUND_COLOR = (Color)App.Current.Resources["ContentPageBackgroundColor"];

        public const double LARGE_FONET_SIZE = 18;
        public const double MEDIUM_FONT_SIZE = 16;
        public const double SMALL_FONT_SIZE = 14;
        public const double MICRO_FONT_SIZE = 12;
    }
}
