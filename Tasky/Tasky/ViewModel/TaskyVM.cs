using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Tasky.Models;

namespace Tasky.ViewModel
{
    public class TaskyVM : INotifyPropertyChanged
    {
        public List<TaskyModel> TaskyList { get; set; }
        public TaskyVM()
        {
            TaskyList = new List<TaskyModel>();
            GetAllTasksAsync();
        }

        public async Task GetAllTasksAsync()
        {
            TaskyList.Clear();
            TaskyList = await App.Database.GetItemsAsync();
            TaskyList.Add( new TaskyModel { IsDone = false, Name = "Task1", Notes = "Notes" } );
            TaskyList.Add( new TaskyModel { IsDone = false, Name = "Task2", Notes = "Notes" } );
            TaskyList.Add( new TaskyModel { IsDone = false, Name = "Task3", Notes = "Notes" } );
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
            }
            else
            {
                await App.Database.UpdateItemAsync( taskyModel );
            }
        }

        public bool ShowNoDataAvailable { get; set; } = false;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
