using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExamenTercerParcial.Database;

namespace ExamenTercerParcial
{
    public partial class App : Application
    {
        static SQLitebsd db;
        public App()
        {
            InitializeComponent();
            MainPage = MainPage = new NavigationPage(new MainPage());
            //MainPage = new MainPage();
        }

        public static SQLitebsd SQLiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new SQLitebsd(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "examen3.db3"));
                }
                return db;
            }

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
