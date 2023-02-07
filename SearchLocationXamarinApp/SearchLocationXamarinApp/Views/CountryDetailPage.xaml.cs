using SearchLocationXamarinApp.Helper;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SearchLocationXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountryDetailPage : ContentView
    {
        public static readonly BindableProperty Country_nameProperty = BindableProperty.Create(nameof(Country_name), typeof(string), typeof(CountryDetailPage), string.Empty);
        public static readonly BindableProperty CapitalProperty = BindableProperty.Create(nameof(Capital), typeof(string), typeof(CountryDetailPage), string.Empty);
        public static readonly BindableProperty RegionProperty = BindableProperty.Create("Region", typeof(string), typeof(CountryDetailPage), string.Empty);

        public string Country_name
        {
            get => (string)GetValue(CountryDetailPage.Country_nameProperty);
            set => SetValue(CountryDetailPage.Country_nameProperty, value);
        }
        public string Capital
        {
            get => (string)GetValue(CountryDetailPage.CapitalProperty);
            set => SetValue(CountryDetailPage.CapitalProperty, value);
        }
        public string Region
        {
            get => (string)GetValue(CountryDetailPage.RegionProperty);
            set => SetValue(CountryDetailPage.RegionProperty, value);
        }

        public CountryDetailPage()
        {
            InitializeComponent();
            Content.BindingContext = this;
        }

        public ICommand GoMapCommand => new Command(() =>
        {
            _ = MapHelper.OpenMap(Country_name);
        });
    }
}