using System;
using System.Reactive;
using ReactiveUI;
using TaxiApp.Models;

namespace TaxiApp.ViewModels
{
    public class HaydovchiDashboardViewModel : ViewModelBase
    {
        private Haydovchi? _haydovchi;
        private HaydovchiDaromadi? _daromadi;
        private decimal _bugunDaromad;
        private decimal _jamiDaromad;
        private decimal _hisobdagiPul;
        private double _reyting;
        private int _yo lovchiSoni;

        public Haydovchi? Haydovchi
        {
            get => _haydovchi;
            set => this.RaiseAndSetIfChanged(ref _haydovchi, value);
        }

        public HaydovchiDaromadi? Daromadi
        {
            get => _daromadi;
            set => this.RaiseAndSetIfChanged(ref _daromadi, value);
        }

        public decimal BugunDaromad
        {
            get => _bugunDaromad;
            set => this.RaiseAndSetIfChanged(ref _bugunDaromad, value);
        }

        public decimal JamiDaromad
        {
            get => _jamiDaromad;
            set => this.RaiseAndSetIfChanged(ref _jamiDaromad, value);
        }

        public decimal HisobdagiPul
        {
            get => _hisobdagiPul;
            set => this.RaiseAndSetIfChanged(ref _hisobdagiPul, value);
        }

        public double Reyting
        {
            get => _reyting;
            set => this.RaiseAndSetIfChanged(ref _reyting, value);
        }

        public int YolovchiSoni
        {
            get => _yo lovchiSoni;
            set => this.RaiseAndSetIfChanged(ref _yo lovchiSoni, value);
        }

        public HaydovchiDashboardViewModel()
        {
            // Default values
            BugunDaromad = 0;
            JamiDaromad = 0;
            HisobdagiPul = 0;
            Reyting = 5.0;
            YolovchiSoni = 0;
        }

        public void LoadDriverData(int driverId)
        {
            // TODO: Database'dan haydovchi ma'lumotlarini yuklash
        }

        public void RefreshEarnings()
        {
            // TODO: Bugungi daromadni yangilash
        }
    }
}
