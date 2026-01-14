using System;
using System.Collections.Generic;

namespace Statistics.com.business
{

    public class Statistics : DataWareHouse
    {
        public Double Average()
        {
            double sum = 0;
            foreach (double item in this.GetItems())
            {
                sum += item;
            }

            return sum / this.GetItems().Count;
        }
    }
}

