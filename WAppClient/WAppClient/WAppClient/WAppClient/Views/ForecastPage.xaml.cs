using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using WAppClient.Models;
using WAppClient.Views;
using WAppClient.ViewModels;

namespace WAppClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForecastPage : ContentPage
    {
        ForecastViewModel viewModel;
        public ForecastPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ForecastViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            /*if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;*/
        }

        async void OnItemSelected(object sender, EventArgs args)
        {   //tap item in list
            var s = sender as Frame;
            ForecastHalfDay item = s.BindingContext as ForecastHalfDay;
            item.DisplayWeather = !item.DisplayWeather;

            if (item.DisplayWeather)
            {
                s.HeightRequest = s.HeightRequest / 2;
            }
            else
            {
                s.HeightRequest = s.HeightRequest * 2;
            }

            s.ForceLayout();
        }
    }
}