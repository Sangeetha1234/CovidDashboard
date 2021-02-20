using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidDashboardPOC.Models
{
    /// <summary>
    /// CovidDataModel
    /// </summary>
    public class CovidDataModel
    {
        /// <summary>
        /// LocationId
        /// </summary>
        public decimal LocationId { get; set; }

        /// <summary>
        /// ActiveCases
        /// </summary>
        public decimal ActiveCases { get; set; }

        /// <summary>
        /// DischargedCases
        /// </summary>
        public decimal DischargedCases { get; set; }

        /// <summary>
        /// Deaths
        /// </summary>
        public decimal Deaths { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get; set; }


    }
}