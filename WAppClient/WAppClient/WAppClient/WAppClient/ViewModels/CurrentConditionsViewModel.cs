using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;

using WAppClient.Models;
using WAppClient.Models.Seed;
using WAppClient.Views;


namespace WAppClient.ViewModels
{
    public class CurrentConditionsViewModel : BaseViewModel
    {
        CurrentCondition _currentCondition = new CurrentCondition() { TempF = 74.0m, DewPointF = 50m };
        public CurrentCondition CurrentCondition
        {
            get { return _currentCondition; }
            set { SetProperty(ref _currentCondition, value); }
        }
        string _windString = "test";
        public string WindString
        {
            get { return _windString; }
            set { SetProperty(ref _windString, value); }
        }

        public Command LoadItemsCommand { get; set; }

        public CurrentConditionsViewModel()
        {
            Title = "Current Conditions";
            WindString = "Test";
            CurrentCondition = SeedData.GetCurrentCondition();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {

                CurrentCondition = SeedData.GetCurrentCondition();
                /*var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    CurrentCondition.Add(item);
                }*/
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
