using System;
using System.Collections.Generic;
using System.Text;

namespace Tasky.Helpers
{
    public interface IFileHelper
    {
        string GetLocalFilePath( string filename );
    }
}
