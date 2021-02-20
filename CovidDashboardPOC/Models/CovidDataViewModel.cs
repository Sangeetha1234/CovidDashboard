using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidDashboardPOC.Models
{
    /// <summary>
    /// CovidDataViewModel
    /// </summary>
    public class CovidDataViewModel
    {
        /// <summary>
        /// LocationId
        /// </summary>
        public decimal LocationId { get; set; }
        /// <summary>
        /// LocationName
        /// </summary>
        public string LocationName { get; set; }
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
        /// <summary>
        /// Indicator
        /// </summary>
        public decimal Indicator { get; set; }
        
    }
    /// <summary>
    /// Indicators
    /// </summary>
    public enum Indicators
    {
        Up = 1,
        Down = 2,
        Equal = 3,
        UnEven = 4
    }
}