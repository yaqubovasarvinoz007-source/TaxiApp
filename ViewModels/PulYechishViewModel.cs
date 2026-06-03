using System;
using System.Collections.ObjectModel;
using ReactiveUI;
using TaxiApp.Models;

namespace TaxiApp.ViewModels
{
    public class PulYechishViewModel : ReactiveObject
    {
        private decimal _summa;
        private string _holati = "Kutilmoqda";
        private ObservableCollection<PulYechish> _yechishlar;

        public decimal Summa
        {
            get => _summa;
            set => this.RaiseAndSetIfChanged(ref _summa, value);
        }

        public string Holati
        {
            get => _holati;
            set => this.RaiseAndSetIfChanged(ref _holati, value);
        }

        public ObservableCollection<PulYechish> Yechishlar
        {
            get => _yechishlar;
            set => this.RaiseAndSetIfChanged(ref _yechishlar, value);
        }

        public PulYechishViewModel()
        {
            Yechishlar = new ObservableCollection<PulYechish>();
            Summa = 0;
        }

        public void YechishSoroviBer(int haydovchiId, decimal summa)
        {
            // TODO: Database'ga sorovi qo'shish
        }

        public void YechishlariYuklash(int haydovchiId)
        {
            // TODO: Database'dan yechishlari yuklash
        }
    }
}
