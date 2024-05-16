using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TrainingApp.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(IosDbPath))]
namespace TrainingApp.iOS
{
    public class IosDbPath : IPath
    {
        public string GetDatabasePath(string sqliteFilename)
        {
            // определяем путь к бд
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", sqliteFilename);
        }
    }
}