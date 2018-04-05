using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasky.Resx;
using Tasky.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasky.Views.EnView
{
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class TaskyListView : ContentPage
    {
        TaskyVM taskyVM { get; set; }
        public TaskyListView()
        {
            InitializeComponent();
            this.Title = AppResources.MY_TASK;
            BindingContext = taskyVM = new TaskyVM();
        }
    }
}