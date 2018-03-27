using System;
using System.IO;
using Tasky.Droid.Helpers;
using Tasky.Helpers;
using Xamarin.Forms;

[assembly: Dependency( typeof( FileHelper ) )]
namespace Tasky.Droid.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath( string filename )
        {
            string path = Environment.GetFolderPath( Environment.SpecialFolder.Personal );
            return Path.Combine( path, filename );
        }
    }
}