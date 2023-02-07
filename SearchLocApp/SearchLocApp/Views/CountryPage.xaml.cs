using SearchLocApp.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SearchLocApp
{
    public partial class CountryPage : ContentPage
    {
        public CountryViewModel ViewModel { get; set; }

        public CountryPage()
        {
            InitializeComponent();
            ViewModel = (CountryViewModel)App.GetViewModel<CountryViewModel>();
            this.BindingContext = ViewModel;
        }

        private async void ViewCell_Appearing(object sender, EventArgs e)
        {
            var cell = sender as ViewCell;  
            var view = cell.View;

            view.TranslationX = -100;
            view.Opacity = 0;

            await Task.WhenAny<bool>
            (
                view.TranslateTo(0, 0, 500, Easing.SinIn),
                view.FadeTo(1, 500, Easing.SinIn)
            );
        }
    }
}
