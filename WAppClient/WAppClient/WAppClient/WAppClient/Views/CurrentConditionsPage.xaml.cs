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
    public partial class CurrentConditionsPage : ContentPage
    {
        CurrentConditionsViewModel viewModel;

        public CurrentConditionsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CurrentConditionsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.CurrentCondition == null)
                viewModel.IsBusy = true;
        }
    }
}