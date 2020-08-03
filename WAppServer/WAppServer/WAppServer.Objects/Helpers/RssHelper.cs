using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WAppServer.Objects.Helpers
{
    public class RssHelper
    {

        public static async Task<bool> GetStreamAsync(string uri, string filePath)
        {
            //get result from uri
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead))
                    using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                    {
                        string fileToWriteTo = filePath;
                        using (Stream streamToWriteTo = File.Open(fileToWriteTo, FileMode.Create))
                        {
                            await streamToReadFrom.CopyToAsync(streamToWriteTo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("GetStreamAsync Failed : {0}", ex.Message));
                return false;
            }
            return true;
        }

        public static XDocument GetXDocFromFile(string filePath)
        {
            //get result from uri
            XDocument doc = null;
            try
            {
                doc = XDocument.Load(filePath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("RssHelper.GetXDocFromFileAsync Error getting XDocument from File " + ex.Message);
            }
            return doc;
        }

        //*************************** XElement Functions ******************************************
        public static string GetStringFromValue(XElement from)
        {
            string result = "";
            if (from != null)
                result = from.Value.ToString();
            return result;
        }
        public static decimal GetDecimalFromValue(XElement from)
        {
            decimal result = 0;
            if (from != null)
                if (!string.IsNullOrEmpty(from.Value.ToString()))
                    result = Convert.ToDecimal(from.Value.ToString());
            return result;
        }
        public static int GetIntFromValue(XElement from)
        {
            int result = 0;
            if (from != null)
                result = Convert.ToInt32(from.Value.ToString());
            return result;
        }
        public static DateTime GetDateTimeFromValue(XElement from)
        {
            string dateString = "";
            if (from != null)
                dateString = from.Value.ToString();
            var cultureInfo = new CultureInfo("en-US");
            string format = "ddd, dd MMM yyyy HH:mm:ss K";
            var result = DateTime.ParseExact(dateString, format, cultureInfo);
            return result;
        }
        public static string GetStringValueFromAttribute(XElement from, string attributeName)
        {
            var value = "";
            var attributeList = from.Attributes();
            foreach (var a in attributeList)
            {
                if (a.Name == attributeName)
                {
                    value = a.Value;
                    break;
                }
            }
            return value;
        }
    }
}
