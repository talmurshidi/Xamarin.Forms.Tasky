using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasky.Models;
using Tasky.Resx;
using Tasky.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasky.Views.EnView
{
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class TaskyListView : ContentPage
    {
        private TaskyVM taskyVM { get; set; }
        public TaskyListView()
        {
            InitializeComponent();
            this.Title = AppResources.MY_TASK;
            BindingContext = taskyVM = new TaskyVM();
        }

        async void OnToolBarItemRefresh_Clicked( object sender, EventArgs eventArgs )
        {
            await taskyVM.GetAllTasksAsync();
        }

        async void OnToolBarItemAdd_Clicked( object sender, EventArgs eventArgs )
        {
            await Navigation.PushAsync( new ManageTaskyView( taskyVM, new TaskyModel() ) { Title = AppResources.ADD } );
        }

        async void OnTaskListRefresh( object sender, EventArgs eventArgs )
        {
            //MyTaskyList.BeginRefresh();
            await taskyVM.GetAllTasksAsync();
            MyTaskyList.EndRefresh();
        }

        async void OnTask_Selected( object sender, SelectedItemChangedEventArgs eventArgs )
        {
            var item = eventArgs.SelectedItem as TaskyModel;
            if( item != null )
            {
                MyTaskyList.SelectedItem = null;
                await Navigation.PushAsync( new ManageTaskyView( taskyVM, item ) { Title = AppResources.EDIT } );
            }
        }
    }
}