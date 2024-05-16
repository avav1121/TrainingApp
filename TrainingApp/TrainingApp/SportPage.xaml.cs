using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrainingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SportPage : ContentPage
    {
        string dbPath;

        public SportPage()
        {
            InitializeComponent();
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
        }
        private void SaveSport(object sender, EventArgs e)
        {
            var sport = (Sport)BindingContext;
            if (!String.IsNullOrEmpty(sport.Name))
            {
                using (ApplicationContext db = new ApplicationContext(dbPath))
                {
                    if (sport.Id == 0)
                        db.Sport.Add(sport);
                    else
                    {
                        db.Sport.Update(sport);
                    }
                    db.SaveChanges();
                }
            }
            this.Navigation.PopAsync();
        }
        private void DeleteSport(object sender, EventArgs e)
        {
            var sport = (Sport)BindingContext;
            using (ApplicationContext db = new ApplicationContext(dbPath))
            {
                db.Sport.Remove(sport);
                db.SaveChanges();
            }
            this.Navigation.PopAsync();
        }
    }
}
