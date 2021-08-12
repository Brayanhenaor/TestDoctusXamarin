using System;
using System.Threading.Tasks;
using System.Windows.Input;
using DoctusTest.Bussiness;
using DoctusTest.Entities.Entities;
using DoctusTest.Services;
using Xamarin.Forms;

namespace DoctusTest.ViewModels
{
    public class TipDetailViewModel : BaseViewModel, INavigated
    {
        Tip tip;
        bool canEdit;
        private readonly INavigationService navigationService;
        private readonly ITipsBussines tipsBussines;

        public Tip Tip
        {
            get => tip;
            set => SetProperty(ref tip, value);
        }

        public bool CanEdit
        {
            get => canEdit;
            set => SetProperty(ref canEdit, value);
        }

        public ICommand EditDetailCommand { get; set; }
        public ICommand UpdateDetailCommand { get; set; }

        public TipDetailViewModel(INavigationService navigationService, ITipsBussines tipsBussines)
        {
            EditDetailCommand = new Command(() => CanEdit = true);
            UpdateDetailCommand = new Command(async () => await EditTipAsync());
            this.navigationService = navigationService;
            this.tipsBussines = tipsBussines;
        }

        private async Task EditTipAsync()
        {
            await tipsBussines.UpdateTipAsync(tip);
            await navigationService.BackAsync();
        }

        public void Navigated(INavigationParameters parameters)
        {
            Tip = parameters.GetValue<Tip>("tip");
        }
    }
}
