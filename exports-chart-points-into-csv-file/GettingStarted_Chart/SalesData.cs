using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStarted_Chart
{
    public class SalesData
    {
        private string year;

        private double sales;

        public string Year
        {
            get { return year; }

            set { year = value; }
        }
        public double Sales
        {
            get { return sales; }

            set { sales = value; }
        }

        public SalesData(string year, double sales)
        {
            this.year = year;

            this.sales = sales;
        }
    }
}