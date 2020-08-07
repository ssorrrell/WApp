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
    public partial class RadarPage : ContentPage
    {
        RadarViewModel viewModel;
        public RadarPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new RadarViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}