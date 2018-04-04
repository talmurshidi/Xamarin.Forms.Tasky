using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Tasky.Controlls
{
    public class ListViewControl : ListView
    {
        public ListViewControl() : base( ListViewCachingStrategy.RecycleElement )
        {

        }
    }
}
