using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DoctusTest.Bussiness;
using DoctusTest.Entities.Entities;
using DoctusTest.Services;
using DoctusTest.Views;
using Xamarin.Forms;

namespace DoctusTest.ViewModels
{
    public class TipsViewModel : BaseViewModel, IBackAsync
    {
        private readonly INavigationService navigationService;
        private readonly ITipsBussines tipsBussines;
        ObservableCollection<Tip> tips;

        public ICommand AddTipCommand { get; set; }
        public ICommand SeeTipCommand { get; set; }
        public ICommand DeleteTipCommand { get; set; }

        public ObservableCollection<Tip> Tips
        {
            get => tips;
            set => SetProperty(ref tips, value);
        }

        public TipsViewModel(INavigationService navigationService, ITipsBussines tipsBussines)
        {
            this.navigationService = navigationService;
            this.tipsBussines = tipsBussines;
            _= LoadTipsAsync();

            AddTipCommand = new Command(async () => await AddTipAsync());
            SeeTipCommand = new Command<Tip>(async (tip) => await SeeTipAsync(tip));
            DeleteTipCommand = new Command<Tip>(async (tip) => await DeleteTipAsync(tip));
        }

        private async Task DeleteTipAsync(Tip tip)
        {
            await tipsBussines.DeleteTipAsync(tip);
            await LoadTipsAsync();
        }

        private async Task SeeTipAsync(Tip tip)
        {
            await navigationService.NavigateAsync<TipDetailView>(new NavigationParameters().Add("tip", tip));
        }

        private async Task AddTipAsync()
        {
            await navigationService.NavigateAsync<AddTipView>();
        }

        private async Task LoadTipsAsync()
        {
            var tips = await tipsBussines.GetAllTipsAsync();
            Tips = new ObservableCollection<Tip>(tips.OrderBy(tip=> tip.Date));
        }

        public async Task BackAsync()
        {
            await LoadTipsAsync();
        }
    }
}
