using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasky.Views.EnView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TaskyListView : ContentPage
	{
		public TaskyListView ()
		{
			InitializeComponent ();
		}
	}
}