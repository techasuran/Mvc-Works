using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChartAssignment.Models;

namespace ChartAssignment.Controllers
{
    public class AjaxdataController : Controller
    {
        //
        // GET: /Ajaxdata/

        public ActionResult Index()
        {

            return View();
        }
        public JsonResult GetMyJson(string fromDate, string toDate)
        {
             List<Chart> chartList =  Helper.GetChartData();         
            var list = Helper.GetChartData();
            if (fromDate != null && fromDate != "")
            {
                DateTime fromDateDt = DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime toDateDt = DateTime.ParseExact(toDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                list = (from chart in chartList
                       where (DateTime.ParseExact(chart.MyDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) >= fromDateDt) &&
                        DateTime.ParseExact(chart.MyDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)<=toDateDt
                       select chart).ToList<Chart>();

            }

            JsonResult js = Json(list);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}
