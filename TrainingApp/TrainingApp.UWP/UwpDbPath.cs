using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.UWP;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(UwpDbPath))]
namespace TrainingApp.UWP
{
    public class UwpDbPath : IPath
    {
        public string GetDatabasePath(string sqliteFilename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
        }
    }
}