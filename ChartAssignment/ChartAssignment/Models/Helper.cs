using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChartAssignment.Models
{
    public class Helper
    {
        public static List<Chart> GetChartData()
        {
            var chartList = new List<Chart>();


            string appDataPath = HttpContext.Current.Server.MapPath("~/App_Data/Charts.xml");

            var charts = from nodes in System.Xml.Linq.XElement.Load(appDataPath).Elements("chart") select nodes;

            if (charts != null)
            {



                foreach (var chartNode in charts)
                {
                    string strMyDate = chartNode.Element("Date").Value.Trim();
                    string strMicrosft = chartNode.Element("Microsoft").Value.Trim();
                    string strApple = chartNode.Element("Apple").Value.Trim();

                    var chart = new Chart()
                    {
                        MyDate = strMyDate,
                        Microsft = strMicrosft,
                        Apple = strApple
                    };
                    chartList.Add(chart);

                }

            }

            return chartList;
        }
    }
}