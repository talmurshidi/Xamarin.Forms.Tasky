using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasky.SQLiteDatabase;
using Tasky.Helpers;
using Xamarin.Forms;
using Tasky.Views.EnView;
using Xamarin.Forms.Xaml;

namespace Tasky
{
    /*
     * Author: Tamer H. Almurshidi
     */
    [XamlCompilation( XamlCompilationOptions.Compile )]
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new TaskyListView() );
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        static TaskyDatabase database;

        public static TaskyDatabase Database
        {
            get
            {
                if( database == null )
                {
                    database = new TaskyDatabase( DependencyService.Get<IFileHelper>().GetLocalFilePath( "TaskySQLite.db3" ) );
                }
                return database;
            }
        }
    }
}
