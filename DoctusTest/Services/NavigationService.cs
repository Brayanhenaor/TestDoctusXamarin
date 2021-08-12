using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DoctusTest.Services
{
    public class NavigationService : INavigationService
    {
        public async Task BackAsync()
        {
            if(Application.Current.MainPage.Navigation.NavigationStack.Count> 1)
            {
                var lastPage = Application.Current.MainPage.Navigation.NavigationStack[Application.Current.MainPage.Navigation.NavigationStack.Count-2];
                if (lastPage.BindingContext is IBackAsync context)
                {
                    await context.BackAsync();
                }
            }
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async Task NavigateAsync<T>(INavigationParameters parameters) where T : Page, new()
        {
            Page page = new T();

            if(page.BindingContext is INavigated context)
            {
                context.Navigated(parameters);
            }

            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task NavigateAsync<T>() where T : Page, new()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new T());
        }
    }
}
