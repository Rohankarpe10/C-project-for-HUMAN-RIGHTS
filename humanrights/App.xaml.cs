using humanrights.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows;

namespace humanrights
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    { 
        public static ObservableCollection<Quiz> _quiz;
        public static string _language;
        public static Maininformation maininformation = new Maininformation();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _language = humanrights.Properties.Settings.Default.lang;
            maininformation = introstorage.GetResourceXML<Maininformation>($"main {_language}.xml");

            _quiz = introstorage.GetResourceXML<ObservableCollection<Quiz>>($"quiz {_language}.xml");

            

            if (_quiz == null)
            {
                _quiz = new ObservableCollection<Quiz>();
            }
  
        }


        private void Application_Exit(object sender, ExitEventArgs e)
        { 

        }
    }
}
