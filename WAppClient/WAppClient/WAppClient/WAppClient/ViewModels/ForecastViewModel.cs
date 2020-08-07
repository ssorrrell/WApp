﻿using System;
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

        Forecast _forecast = new Forecast() { DateStamp = DateTime.Now };
        public Forecast Forecast
        {
            get { return _forecast; }
            set { SetProperty(ref _forecast, value); }
        }

        public ForecastViewModel()
        {
            Title = "Forecast";
            Forecast = SeedData.GetForecastObject();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Forecast = SeedData.GetForecastObject();
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
    }
}