using System;
using System.Threading.Tasks;
using System.Windows.Input;
using DoctusTest.Bussiness;
using DoctusTest.Entities.Entities;
using DoctusTest.Services;
using Xamarin.Forms;

namespace DoctusTest.ViewModels
{
    public class AddTipViewModel : BaseViewModel
    {
        DateTime date;
        string title;
        string description;
        private readonly INavigationService navigationService;
        private readonly ITipsBussines tipsBussines;

        public DateTime Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public ICommand SaveCommand { get; set; }

        public AddTipViewModel(INavigationService navigationService, ITipsBussines tipsBussines)
        {
            SaveCommand = new Command(async () => await SaveAsync());
            this.navigationService = navigationService;
            this.tipsBussines = tipsBussines;
        }

        private async Task SaveAsync()
        {
            Tip tip = new Tip
            {
                Title = Title,
                Description = Description,
                Date = Date
            };

            await tipsBussines.SaveTipAsync(tip);
            await navigationService.BackAsync();
        }
    }
}
