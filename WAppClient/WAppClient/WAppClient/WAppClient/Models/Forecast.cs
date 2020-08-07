using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace WAppClient.Models
{
    public class Forecast
    {
        public ObservableCollection<ForecastHalfDay> ForecastHalfDays;
        public DateTime DateStamp;
    }
}
