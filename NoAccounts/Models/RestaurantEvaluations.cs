using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NoAccounts.Models
{
    public class RestaurantGrade
    {
        public int RestaurantGradeID { get; set; }
        [ScaffoldColumn(false)]
        public string Camis { get; set; }
        [Display(Name ="Restaurant Name")]
        public string Dba { get; set; }
        public string Boro { get; set; }
        public string Building { get; set; }
        public string Street { get; set; }
        [Display(Name ="ZIP")]
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        [Display(Name ="Cuisine")]
        public string CuisineType { get; set; }
        [Display(Name ="Inspection Date")]
        public string InspectionDate { get; set; }
        [Display(Name ="Violation Code")]
        public string ViolationCode { get; set; }
        public string Score { get; set; }
        public string Grade { get; set; }
    }
}