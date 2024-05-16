using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrainingApp
{
    public partial class App : Application
    {
        public const string DBFILENAME = "Trainingapp.db";

        public App()
        {
            InitializeComponent();

            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(DBFILENAME);
            using (var db = new ApplicationContext(dbPath))
            {
                // Создаем бд, если она отсутствует
                db.Database.EnsureCreated();
                if (db..Count() == 0)
                {
                    db.Sport.Add(new Sport { Name = "Табата", CyclesCount="4", TimeOfTraining="100 ", TimeOfChill="50", TotalTime="150" });
                    db.Sport.Add(new Sport { Name = "CrossFit", CyclesCount = "4", TimeOfTraining = "100 ", TimeOfChill = "50", TotalTime = "150" });
                    db.SaveChanges();
                }
            }
            MainPage = new NavigationPage(new MainPage());
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
