using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NFL.Reports
{
    public class WRResults
    {
        // Aggregate ratings
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        // Aggregate counts
        public static double NumberSurveyed { get; set; } 

        public static double Catches { get; set; } 

        public static double NumberRewardsMembers { get; set; } 
    }
}
