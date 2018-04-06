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
            TaskyList.Add( new TaskyModel { IsDone = false, Name = "Task1", Notes = "Notes", ID = 1 } );
            TaskyList.Add( new TaskyModel { IsDone = true, Name = "Task2", Notes = "Notes", ID = 2 } );
            TaskyList.Add( new TaskyModel { IsDone = false, Name = "Task3", Notes = "Notes", ID = 3 } );
            if( TaskyList.Count == 0 )
            {
                ShowNoDataAvailable = true;
            }
            else
            {
                ShowNoDataAvailable = false;
            }
        }

        public async Task UpdateTaskAsync( TaskyModel taskyModel )
        {
            if( taskyModel.ID == 0 )
            {
                await App.Database.InsertItemAsync( taskyModel );
                TaskyList.Add( taskyModel );
            }
            else
            {
                await App.Database.UpdateItemAsync( taskyModel );
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
                    UserDialogs.Instance.Toast( "Deleted Successfully", TimeSpan.FromSeconds( 3 ) );
                }
                else
                {
                    UserDialogs.Instance.Toast( "Deleted Failed", TimeSpan.FromSeconds( 3 ) );
                }
            }
        }

        public Command DeleteTaskCommand
        {
            get
            {
                return new Command( async val =>
                {
                    var item = TaskyList.Where( i => i.ID == (int)val ).FirstOrDefault();
                    await DeleteTaskAsync( item );
                } );
            }
        }

        private async Task<bool> DeleteConfirmationMessage()
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
        public bool ShowNoDataAvailable { get; set; } = false;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
