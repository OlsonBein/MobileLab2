using Plugin.Multilingual;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Change localization
            CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo("fr");

            MainPage = new NavigationPage(new Lab2.MainPage());
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
