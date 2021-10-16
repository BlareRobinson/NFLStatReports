using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NFL.Reports
{
    public class NFLStatReport
    {
        public static void Main(string[] args)
        {
            //Calculated Values
            double ballsCaught;

            ballsCaught = WRResults.Catches;

            Console.WriteLine($"Total Catches: {ballsCaught}");
        }
    }
}
