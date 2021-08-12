using System.Threading.Tasks;
using Xamarin.Forms;

namespace DoctusTest.Services
{
    public interface INavigationService
    {
        Task NavigateAsync<T>(INavigationParameters parameters) where T : Page, new();
        Task NavigateAsync<T>() where T : Page, new();
        Task BackAsync();
    }
}
