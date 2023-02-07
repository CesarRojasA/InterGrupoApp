using Microsoft.Extensions.DependencyInjection;
using SearchLocApp.Data;
using SearchLocApp.Interfaces;
using SearchLocApp.Repository;
using SearchLocApp.Services;
using SearchLocApp.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SearchLocApp
{
    public partial class App : Application
    {
        protected static IServiceProvider ServiceProvider { get; set; }

        private static CountryDatabase database;
        public static CountryDatabase Database
        {
            get 
            {
                if (database == null)
                    database = new CountryDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("countrydb.db3"));
                return database;
            }
        }

        public App(Action<IServiceCollection> addPlatformServices = null)
        {
            _ = GetAuthTokenAsync();
            InitializeComponent();

            SetupServices(addPlatformServices);
            MainPage = new NavigationPage(new CountryPage());
        }

        private void SetupServices(Action<IServiceCollection> addPlatformServices = null)
        {
            ServiceCollection services = new ServiceCollection();
            addPlatformServices?.Invoke(services);

            services.AddTransient<CountryViewModel>();

            services.AddSingleton<IApiService, ApiService>();
            services.AddSingleton<IContryService, CountryService>();
            services.AddSingleton<ICountryInfoService, CountryInfoService>();
            services.AddSingleton<ICountryRepository, CountryRepository>();


            ServiceProvider = services.BuildServiceProvider();
        }

        public static BaseViewModel GetViewModel<TViewModel>()
            where TViewModel : BaseViewModel
        {
            return ServiceProvider.GetService<TViewModel>();
        }

        private async Task GetAuthTokenAsync()
        {
             await AuthService.GetAuthTokenAsync("getaccesstoken");
                
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
