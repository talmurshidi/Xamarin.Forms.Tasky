using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tasky.Models
{
    public class TaskyModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool IsDone { get; set; }
    }
}
