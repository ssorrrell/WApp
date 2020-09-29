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
using System.Runtime.CompilerServices;

namespace WAppClient.ViewModels
{
    public class ForecastViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; set; }

        /*Forecast _forecast = new Forecast() { DateStamp = DateTime.Now };
        public Forecast Forecast
        {
            get { return _forecast; }
            set { SetProperty(ref _forecast, value); }
        }*/

        public ObservableCollection<ForecastHalfDay> ForecastHalfDays { get; set; }

        DateTime _dateStamp = DateTime.Now;
        public DateTime DateStamp
        {
            get { return _dateStamp; }
            set { SetProperty(ref _dateStamp, value); }
        }

        private Dictionary<string, bool> _expandedItems = new Dictionary<string, bool>();
        public Dictionary<string, bool> ExpandedItems
        {
            get { return _expandedItems; }
            set { SetProperty(ref _expandedItems, value);  }
        }

        public ForecastViewModel()
        {
            Title = "Forecast";
            //Forecast = SeedData.GetForecastObject();
            //ForecastHalfDays = SeedData.GetForecastHalfDays();
            ForecastHalfDays = SeedData.GetForecastHalfDays();
            InitializeExpandedItems();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                //Forecast = SeedData.GetForecastObject();
                DateStamp = DateTime.Now;
                ForecastHalfDays = SeedData.GetForecastHalfDays();
                InitializeExpandedItems();
                /*Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
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

        public async Task ToggleExpander(string name)
        {
            if (ExpandedItems.ContainsKey(name))
            {
                ExpandedItems[name] = !ExpandedItems[name];
            }
        }

        private void InitializeExpandedItems()
        {
            ExpandedItems.Clear();
            foreach(var item in ForecastHalfDays)
            {
                ExpandedItems.Add(item.Name, false);
            }
        }
    }
}
