using System;
using DoctusTest.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoctusTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TipsView());
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
