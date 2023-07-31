using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Bills.BaseViewModels;
using Bills.Models;
using Microsoft.EntityFrameworkCore;

namespace Bills.ViewModels;
    public class MainWindowViewModel : NotifyPropertyChangedBase
    {
        private BillsDataContext context;
        public MainWindowViewModel()
        {
            AllResources = new List<CommunalResource>();
            context = new BillsDataContext();
            Task.Run(() => { LoadData(); });
        }
        private List<CommunalResource> AllResources;
        private List<Tariff> AllTariffs;
        private async void LoadData()
        {
            AllResources = await context.Resources.ToListAsync();
            OnPropertyChanged(nameof(Resources));

            AllTariffs = await context.Tariffs.ToListAsync();
            OnPropertyChanged(nameof(Tariffs));
        }
        private CommunalResourceViewModel? _selectedTariff;
        public CommunalResourceViewModel? SelectedTariff
        {
            get => _selectedTariff;
            set { _selectedTariff = value; OnPropertyChanged(nameof(SelectedTariff)); }
        }
        private CommunalResourceViewModel? _selectedResource;
        public CommunalResourceViewModel? SelectedResource
        {
            get => _selectedResource;
            set { _selectedResource = value; OnPropertyChanged(nameof(SelectedResource)); }
        }
        public ObservableCollection<CommunalResourceViewModel> Resources
        {
            get { return new ObservableCollection<CommunalResourceViewModel>(
                AllResources.Select(r => new CommunalResourceViewModel(r))); }
        }
        public ObservableCollection<TariffViewModel> Tariffs
        {
            get
            {
                return new ObservableCollection<TariffViewModel>(
                AllTariffs.Select(r => new TariffViewModel(r)));
            }
        }
        public ICommand AddResource => new RelayCommand(x =>
        {
            var resource = new CommunalResource() { Title = "New Resource" };
            AllResources.Add(resource);
            context.Resources.Add(resource);
            OnPropertyChanged(nameof(Resources));
        },x => true);
        public ICommand Save => new RelayCommand(x =>
        {
            context.SaveChangesAsync().ContinueWith(t => 
            {
                MessageBox.Show("Saved");
                LoadData();
                OnPropertyChanged(nameof(Resources));
            });
        }, x => true);

    }
