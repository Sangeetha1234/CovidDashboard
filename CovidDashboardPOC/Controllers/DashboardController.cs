using CovidDashboardPOC.DAL;
using CovidDashboardPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CovidDashboardPOC.Controllers
{
    public class DashboardController : Controller
    {
        CovidDataDAL objCovidDataDAL = new CovidDataDAL();
        // GET: /Dashboard/
        public ActionResult Index()
        {
            return View(this.getHighestThree());
        }

        /// <summary>
        /// getCovidDataByDate
        /// </summary>
        /// <returns></returns>
        public JsonResult getCovidDataByDate()
        {
            try
            {
                List<CovidDataViewModel> list = this.objCovidDataDAL.GetCovidDataByDate(DateTime.Now.ToShortDateString());
                return new JsonResult()
                {
                    Data = list,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        /// <summary>
        /// CovidDataViewModel
        /// </summary>
        /// <returns></returns>
        public List<CovidDataViewModel> getHighestThree()
        {
            return this.objCovidDataDAL.GetHighestThreeByDate(DateTime.Now.ToShortDateString());
        }
	}
}