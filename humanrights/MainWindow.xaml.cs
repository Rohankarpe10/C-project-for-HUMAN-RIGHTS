using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace humanrights
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        



        public MainWindow()
        {
            var lang = Properties.Settings.Default.lang;
            CultureInfo CurrentCulture = new CultureInfo(App._language);
            CultureInfo CurrentUICulture = new CultureInfo(App._language);
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.initializePage();
            CoBc_Lng.ItemsSource = new List<string> { "en", "de" };

            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Main_Frame.Content = new intropage();
            this.initializePage();


        }

        private void initializePage()
        {
            Lbx_test.Visibility = Visibility.Visible;
            Ty_test.Visibility = Visibility.Hidden;
            Un_test.Visibility = Visibility.Hidden;
            Tp_test.Visibility = Visibility.Hidden;
            Lbx_test.ItemsSource = App.maininformation.Intro;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Main_Frame.Content = new universaldeclaration();
            Lbx_test.Visibility = Visibility.Hidden;
            Ty_test.Visibility = Visibility.Hidden;
            Tp_test.Visibility = Visibility.Hidden;
            Un_test.Visibility = Visibility.Visible;
            Un_test.ItemsSource = App.maininformation.UniversalDeclaration;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Main_Frame.Content = new types();
            Lbx_test.Visibility = Visibility.Hidden;
            Ty_test.Visibility = Visibility.Visible;
            Un_test.Visibility = Visibility.Hidden;
            Tp_test.Visibility = Visibility.Hidden;
            Ty_test.ItemsSource = App.maininformation.Types;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
            var win = new QuizWindow();
            win.Owner = this;
            Visibility = Visibility.Collapsed;
            win.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Lbx_test.Visibility = Visibility.Hidden;
            Ty_test.Visibility = Visibility.Hidden;
            Un_test.Visibility = Visibility.Hidden;
            Tp_test.Visibility = Visibility.Visible;
            Tp_test.ItemsSource = App.maininformation.Htypes;
        }

  

        private void CoBc_Lng_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.lang = (sender as ComboBox).SelectedItem.ToString();
            Properties.Settings.Default.Save();
            Process.Start(Application.ResourceAssembly.Location);

            App.Current.Shutdown();

        }
    }
}
