using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;
using WAppServer.Framework.Data;

namespace WAppServer.Objects.Forecasts
{
    public class Forecast : Entity
    {
        private ForecastDetailsManager _forecastDetailsManager = null;
        private ForecastTextManager _forecastTextManager = null;

        public Forecast(SqlConnection sqlConnection)
        {
            _forecastDetailsManager = new ForecastDetailsManager(sqlConnection);
            _forecastTextManager = new ForecastTextManager(sqlConnection);
        }

        public int ID;
        public int ForecastOfficeID; //ForecastOffice

        List<ForecastDetails> _dailyMinTemp;
        public List<ForecastDetails> DailyMinTemp //ForecastDetailsID
        {
            get
            {
                if (_dailyMinTemp == null)
                    _dailyMinTemp = GetForecastDetails(ForecastDetails.Detail.DailyMinTemp);
                return _dailyMinTemp;
            }
            set
            {
                if (_dailyMinTemp != null)
                    SetForecastDetails(_dailyMinTemp);
            }
        }

        List<ForecastDetails> _dailyMaxTemp;
        public List<ForecastDetails> DailyMaxTemp //ForecastDetailsID
        {
            get
            {
                if (_dailyMaxTemp == null)
                    _dailyMaxTemp = GetForecastDetails(ForecastDetails.Detail.DailyMaxTemp);
                return _dailyMaxTemp;
            }
            set
            {
                if (_dailyMaxTemp != null)
                    SetForecastDetails(_dailyMaxTemp);
            }
        }

        List<ForecastDetails> _hourlyProbPrecip;
        public List<ForecastDetails> HourlyProbPrecip //ForecastDetailsID
        {
            get
            {
                if (_hourlyProbPrecip == null)
                    _hourlyProbPrecip = GetForecastDetails(ForecastDetails.Detail.HourlyProbPrecip);
                return _hourlyProbPrecip;
            }
            set
            {
                if (_hourlyProbPrecip != null)
                    SetForecastDetails(_hourlyProbPrecip);
            }
        }

        List<ForecastText> _weatherType;
        public List<ForecastText> WeatherType //ForecastTextID
        {
            get
            {
                if (_weatherType == null)
                    _weatherType = GetForecastText(Forecasts.ForecastText.Text.WeatherType);
                return _weatherType;
            }
            set
            {
                if (_weatherType != null)
                    SetForecastText(_weatherType);
            }
        }

        List<ForecastText> _forecastText;
        public List<ForecastText> ForecastText //ForecastTextID
        {
            get
            {
                if (_forecastText == null)
                    _forecastText = GetForecastText(Forecasts.ForecastText.Text.ForecastText);
                return _forecastText;
            }
            set
            {
                if (_forecastText != null)
                    SetForecastText(_forecastText);
            }
        }

        public DateTime DateStamp;

        private List<ForecastDetails> GetForecastDetails(ForecastDetails.Detail detailType)
        {
            return (List<ForecastDetails>)_forecastDetailsManager.GetList($"[DetailType] = {detailType}", " [ID} Asc ");
        }
        private int SetForecastDetails(List<ForecastDetails> forecastDetails)
        {
            return _forecastDetailsManager.UpdateList(forecastDetails);
        }

        private List<ForecastText> GetForecastText(ForecastText.Text textType)
        {
            return (List<ForecastText>)_forecastTextManager.GetList($"[TextType] = {textType}", " [ID} Asc ");
        }
        private int SetForecastText(List<ForecastText> forecastTexts)
        {
            return _forecastTextManager.UpdateList(forecastTexts);
        }
    }
}
