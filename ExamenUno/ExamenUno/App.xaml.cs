
using ExamenUno.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExamenUno
{
    
    public partial class App : Application
    {

        static Class2 db;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        public static Class2 SQLiteBD
        {
            get
            {
                if (db==null )
                {
                    db=new Class2(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Base de datos"));
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
