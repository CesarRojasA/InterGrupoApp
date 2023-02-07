using Acr.UserDialogs;
using SearchLocApp.Interfaces;
using SearchLocApp.Models;
using SearchLocApp.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SearchLocApp.ViewModels
{
    public class CountryViewModel : BaseViewModel
    {
        #region Private attributes
        private readonly IContryService _service;
        private readonly ICountryRepository _repository;
        private ObservableCollection<Country> countries;
        private double progressValue;
        private string processLabel;
        private bool isVisibleListView;
        #endregion
        #region Public attributes
        public ObservableCollection<Country> Countries
        {
            get => countries;
            set
            {
                countries = value;
                OnPropertyChanged();
            }
        }
        public bool IsVisibleListView
        {
            get => isVisibleListView;
            set
            {
                isVisibleListView = value;
                OnPropertyChanged();
            }
        }
        public string ProcessLabel
        {
            get => processLabel;
            set
            {
                processLabel = value;
                OnPropertyChanged();
            }
        }
        public double ProgressValue
        {
            get => progressValue;
            set
            {
                progressValue = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        public ICommand SearchCommand => new Command((text) =>
        {
            Country item = text as Country;
            _ = SearchCountry(item);
        });
        #endregion
        #region Constructors
        public CountryViewModel(IContryService contryService, ICountryRepository countryRepository)
        {
            _service = contryService;
            _repository = countryRepository;
            Countries = new ObservableCollection<Country>();
            IsVisibleListView = false;
            _ = LoadAllCountries();
        }
        #endregion
        #region Private Methods
        private async Task SearchCountry(Country country)
        {
            IsBusy = true;

            Countries = await _repository.GetAllCountriesAsync();
            if (country != null)
            {
                List<Country> TempFiltered = Countries.Where(x => x.Country_name == country.Country_name).ToList();

                Countries.Clear();
                foreach (Country countryFiltered in TempFiltered)
                {
                    if (!Countries.Contains(countryFiltered))
                    {
                        Countries.Add(countryFiltered);
                    }
                }
            }
            IsBusy = false;
        }
        private void ProcessHandlerAsync(string processText, int delay, double progress)
        {
            ProgressValue = progress;
            ProcessLabel = processText;
            Task.Delay(delay).Wait();
        }
        private async Task SaveCountriesSQLiteAsync()
        {
            bool res = _repository.SaveCountriesListAsync(Countries);
            if (res)
            {
                ProcessHandlerAsync(CountryResource.InformationSavedText, 0, 1.0);
                await UserDialogs.Instance.AlertAsync(CountryResource.MsgInfoSaved, CountryResource.SavedInformationTitle, CountryResource.OKButton);
            }
        }
        #endregion
        #region Public Methods
        public async Task LoadAllCountries()
        {
            try
            {
                IsBusy = true;
                ProcessHandlerAsync(CountryResource.CheckdbText, 0, 0.3);
                Countries = await _repository.GetAllCountriesAsync();
                if (!Countries.Any())   
                {
                    ProcessHandlerAsync(CountryResource.DownloadingInfoText, 0, 0.5);
                    await UserDialogs.Instance.AlertAsync(CountryResource.MsgInfoLoaded, CountryResource.LoadInformationTitle, CountryResource.OKButton);
                    Countries = await _service.GetAllCountriesAsync();
                    
                    if (Countries == null)
                    {
                        ProcessHandlerAsync(CountryResource.FailedQueryAPIText, 0, 0.0);
                        await UserDialogs.Instance.AlertAsync(CountryResource.MsgFailedQueryAPI, CountryResource.ApiErrorTitle, CountryResource.OKButton);
                        return;
                    }
                    ProcessHandlerAsync(CountryResource.CountriesDownloadedText, 700, 0.7);
                    await SaveCountriesSQLiteAsync();
                }
                IsVisibleListView = true;
                IsBusy = false; 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
        #endregion
    }
}
