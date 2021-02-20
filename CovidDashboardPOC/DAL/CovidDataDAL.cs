using CovidDashboardPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidDashboardPOC.DAL
{
    public class CovidDataDAL
    {
        /// <summary>
        /// GetLocationData
        /// </summary>
        /// <returns></returns>
        public List<LocationDataViewModel> GetLocationData()
        {
            List<LocationDataViewModel> objList = new List<LocationDataViewModel>() {
                new LocationDataViewModel{
                    LocationId = 1,
                    LocationName = "China"
                },
                new LocationDataViewModel{
                    LocationId = 2,
                    LocationName = "US"
                },
                new LocationDataViewModel{
                    LocationId = 3,
                    LocationName = "India"
                },
                new LocationDataViewModel{
                    LocationId = 4,
                    LocationName = "UK"
                }
            };
           
            return objList;
              
        }

        /// <summary>
        /// GetCovidDataByLocation
        /// </summary>
        /// <returns></returns>
        public List<CovidDataModel> GetCovidDataByLocation()
        {
            List<CovidDataModel> objList = new List<CovidDataModel>() {
                new CovidDataModel{
                    LocationId = 1,
                    ActiveCases = 5000,
                    Deaths=5000,
                    DischargedCases=12000,
                    Date = DateTime.Now
                },
                new CovidDataModel{
                    LocationId = 2,
                    ActiveCases = 10000,
                    Deaths=5000,
                    DischargedCases=12000,
                    Date = DateTime.Now
                },
                new CovidDataModel{
                    LocationId = 3,
                    ActiveCases = 10080,
                    Deaths=5000,
                    DischargedCases=12000,
                    Date = DateTime.Now
                },
                new CovidDataModel{
                    LocationId = 4,
                    ActiveCases = 10000,
                    Deaths=5000,
                    DischargedCases=12000,
                    Date = DateTime.Now
                },
                new CovidDataModel{
                    LocationId = 1,
                    ActiveCases = 9000,
                    Deaths=5000,
                    DischargedCases=12000,
                    Date = DateTime.Now.AddDays(-1)
                },
                new CovidDataModel{
                    LocationId = 2,
                    ActiveCases = 10000,
                    Deaths=5000,
                    DischargedCases=12000,
                    Date = DateTime.Now.AddDays(-1)
                },
                new CovidDataModel{
                    LocationId = 3,
                    ActiveCases = 10060,
                    Deaths=5000,
                    DischargedCases=12000,
                    Date = DateTime.Now.AddDays(-1)
                },
                new CovidDataModel{
                    LocationId = 4,
                    ActiveCases = 10000,
                    Deaths=5000,
                    DischargedCases=12000,
                    Date = DateTime.Now.AddDays(-1)
                },
                new CovidDataModel{
                    LocationId = 1,
                    ActiveCases = 8000,
                    Deaths=5000,
                    DischargedCases=12000,
                    Date = DateTime.Now.AddDays(-2)
                },
                new CovidDataModel{
                    LocationId = 2,
                    ActiveCases = 10000,
                    Deaths=5000,
                    DischargedCases=12000,
                    Date = DateTime.Now.AddDays(-2)
                },
                new CovidDataModel{
                    LocationId = 3,
                    ActiveCases = 10040,
                    Deaths=5000,
                    DischargedCases=12000,
                    Date = DateTime.Now.AddDays(-2)
                },
                new CovidDataModel{
                    LocationId = 4,
                    ActiveCases = 8000,
                    Deaths=5000,
                    DischargedCases=12000,
                    Date = DateTime.Now.AddDays(-2)
                }
            };

            return objList;

        }


        /// <summary>
        /// GetCovidDataByDate
        /// </summary>
        /// <returns></returns>
        public List<CovidDataViewModel> GetCovidDataByDate( string date)
        {
            return this.GetLocationData()
             .Join(
                 this.GetCovidDataByLocation(),
                 x => x.LocationId,
                 y => y.LocationId, (x, y) => new { loc = x, data = y }
              )
              .Where(y=>y.data.Date.ToShortDateString() == date)
             .Select(y => new CovidDataViewModel
             {
                 Date = y.data.Date,
                 LocationId = y.loc.LocationId,
                 LocationName = y.loc.LocationName,
                 ActiveCases = y.data.ActiveCases,
                 DischargedCases = y.data.DischargedCases,
                 Deaths = y.data.Deaths,
                 Indicator = this.compareActiveCases(y.loc.LocationId,date,y.data.ActiveCases)
             })
             .ToList();
        }

        /// <summary>
        /// compareActiveCases
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private decimal compareActiveCases(decimal locationId, string date,decimal activeCases)
        {
            decimal firstDay = this.GetCovidDataByLocation()
                .Where(
                    x => x.Date.ToShortDateString() == Convert.ToDateTime(date).AddDays(-1).ToShortDateString() && 
                    x.LocationId==locationId
                 )
                .Select(x=>x.ActiveCases)
                .FirstOrDefault();
            decimal secondDay = this.GetCovidDataByLocation()
                .Where(
                    x => x.Date.ToShortDateString() == Convert.ToDateTime(date).AddDays(-2).ToShortDateString() && 
                    x.LocationId==locationId
                 )
                .Select(x => x.ActiveCases)
                .FirstOrDefault();
            if (activeCases > firstDay && activeCases > secondDay)
                return (int)Indicators.Up;
            if (activeCases < firstDay && activeCases < secondDay)
                return (int)Indicators.Down;
            if (activeCases == firstDay && activeCases == secondDay)
                return (int)Indicators.Equal;
                return (int)Indicators.UnEven;
        }


        /// <summary>
        /// GetHighestThreeByDate
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        internal List<CovidDataViewModel> GetHighestThreeByDate(string date)
        {
            return this.GetLocationData()
             .Join(
                 this.GetCovidDataByLocation(),
                 x => x.LocationId,
                 y => y.LocationId, (x, y) => new { loc = x, data = y }
              )
              .Where(y => y.data.Date.ToShortDateString() == date)
             .Select(y => new CovidDataViewModel
             {
                 Date = y.data.Date,
                 LocationId = y.loc.LocationId,
                 LocationName = y.loc.LocationName,
                 ActiveCases = y.data.ActiveCases,
                 DischargedCases = y.data.DischargedCases,
                 Deaths = y.data.Deaths,
                 Indicator = this.compareActiveCases(y.loc.LocationId, date, y.data.ActiveCases)
             })
             .OrderByDescending(x=>x.ActiveCases)
             .Take(3)
             .ToList();
        }
    }
}