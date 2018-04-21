using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tasky.Models;
using Tasky.Resx;
using Xamarin.Forms;

namespace Tasky.ViewModel
{
    /*
     * Author: Tamer H. Almurshidi
     */
    public class TaskyVM : INotifyPropertyChanged
    {
        public ObservableCollection<TaskyModel> TaskyList { get; set; }
        public List<TaskyModel> TaskyListTemp { get; set; }
        public TaskyVM()
        {
            TaskyList = new ObservableCollection<TaskyModel>();
            GetAllTasksAsync();
        }

        public async Task GetAllTasksAsync()
        {
            TaskyList.Clear();
            TaskyListTemp = await App.Database.GetItemsAsync();
            ListToOC();
            ChechDataAvailable();
        }

        public async Task UpdateTaskAsync( TaskyModel taskyModel )
        {
            if( taskyModel.ID == 0 )
            {
                int IsInserted = await App.Database.InsertItemAsync( taskyModel );
                if( IsInserted == 1 )
                {
                    UserDialogs.Instance.Toast( AppResources.Saved_Successfully, TimeSpan.FromSeconds( 3 ) );
                    TaskyList.Add( taskyModel );
                }
                else
                {
                    UserDialogs.Instance.Toast( AppResources.Saved_Failed, TimeSpan.FromSeconds( 3 ) );
                }
                ChechDataAvailable();
            }
            else
            {
                int IsInserted = await App.Database.UpdateItemAsync( taskyModel );
                if( IsInserted == 1 )
                {
                    UserDialogs.Instance.Toast( AppResources.Updated_Successfully, TimeSpan.FromSeconds( 3 ) );
                }
                else
                {
                    UserDialogs.Instance.Toast( AppResources.Updated_Failed, TimeSpan.FromSeconds( 3 ) );
                }
            }
        }

        public async Task DeleteTaskAsync( TaskyModel taskyModel )
        {
            bool confirmation = await DeleteConfirmationMessage();
            if( confirmation )
            {
                int isDeleted = await App.Database.DeleteItemAsync( taskyModel );

                if( isDeleted == 1 )
                {
                    TaskyList.Remove( taskyModel );
                    UserDialogs.Instance.Toast( AppResources.Deleted_Successfully, TimeSpan.FromSeconds( 3 ) );
                }
                else
                {
                    UserDialogs.Instance.Toast( AppResources.Deleted_Failed, TimeSpan.FromSeconds( 3 ) );
                }
                ChechDataAvailable();
            }
        }

        public Command DeleteTaskCommand
        {
            get
            {
                return new Command( async val =>
                {
                    bool confirmation = await DeleteConfirmationMessage();
                    if( confirmation )
                    {
                        var item = TaskyList.Where( i => i.ID == (int)val ).FirstOrDefault();
                        int isDeleted = await App.Database.DeleteItemAsync( item );

                        if( isDeleted == 1 )
                        {
                            TaskyList.Remove( item );
                            UserDialogs.Instance.Toast( AppResources.Deleted_Successfully, TimeSpan.FromSeconds( 3 ) );
                        }
                        else
                        {
                            UserDialogs.Instance.Toast( AppResources.Deleted_Failed, TimeSpan.FromSeconds( 3 ) );
                        }
                        ChechDataAvailable();
                    }
                } );
            }
        }

        public async Task<bool> DeleteConfirmationMessage()
        {
            return await App.Current.MainPage.DisplayAlert( AppResources.DELETE_CONFIRM, AppResources.ARE_YOU_SURE_DELETE, AppResources.OK, AppResources.CANCEL );
        }
        private void ListToOC()
        {
            foreach( var item in TaskyListTemp )
            {
                TaskyList.Add( item );
            }
        }

        private void ChechDataAvailable()
        {
            if( TaskyList.Count == 0 )
            {
                ShowNoDataAvailable = true;
            }
            else
            {
                ShowNoDataAvailable = false;
            }
        }
        public bool ShowNoDataAvailable { get; set; } = false;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
