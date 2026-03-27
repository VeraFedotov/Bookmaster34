using Bookmaster34.Models;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Bookmaster34
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Bookmaster34Context context;

        public static Bookmaster34Context GetContext()
        {
            if (context == null)
            {
                context = new Bookmaster34Context();
            }
            return context;
        }

    }

}
