using System;
using System.Collections.ObjectModel;
using ReactiveUI;
using TaxiApp.Models;

namespace TaxiApp.ViewModels
{
    public class MijozSharhlariViewModel : ViewModelBase
    {
        private ObservableCollection<MijozSharhı> _sharhlari;
        private double _ortaReyting;
        private int _jami Sharh;

        public ObservableCollection<MijozSharhı> Sharhlari
        {
            get => _sharhlari;
            set => this.RaiseAndSetIfChanged(ref _sharhlari, value);
        }

        public double OrtaReyting
        {
            get => _ortaReyting;
            set => this.RaiseAndSetIfChanged(ref _ortaReyting, value);
        }

        public int JamiSharh
        {
            get => _jami Sharh;
            set => this.RaiseAndSetIfChanged(ref _jami Sharh, value);
        }

        public MijozSharhlariViewModel()
        {
            Sharhlari = new ObservableCollection<MijozSharhı>();
            OrtaReyting = 5.0;
            JamiSharh = 0;
        }

        public void SharhlariYuklash(int haydovchiId)
        {
            // TODO: Database'dan sharhlarni yuklash
        }

        public void HisoblashOrtaReyting()
        {
            // TODO: O'rtacha reytingni hisoblash
        }
    }
}
