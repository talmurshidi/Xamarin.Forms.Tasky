using System;
using System.Collections.Generic;
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
    /*
     * Author: Tamer H. Almurshidi
     */
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class ManageTaskyView : ContentPage
    {
        TaskyVM taskyVM { get; set; }
        public ManageTaskyView( TaskyVM taskyVM, TaskyModel taskyModel )
        {
            InitializeComponent();
            this.taskyVM = taskyVM;
            BindingContext = taskyModel;
        }

        async void OnButton_Clicked( object sender, EventArgs eventArgs )
        {
            var item = (Button)sender;
            if( item.Text.Equals( AppResources.SAVE ) )
            {
                await taskyVM.UpdateTaskAsync( (TaskyModel)BindingContext );
                await Navigation.PopAsync();
            }
            else if( item.Text.Equals( AppResources.DELETE ) )
            {
                await taskyVM.DeleteTaskAsync( (TaskyModel)BindingContext );
                await Navigation.PopAsync();
            }
            else if( item.Text.Equals( AppResources.CANCEL ) )
            {
                await Navigation.PopAsync();
            }
        }
    }
}