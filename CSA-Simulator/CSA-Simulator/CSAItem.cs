using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSA_Simulator
{
    public class CSAItem
    {
        private string name;
        private double percentage;

        public CSAItem(string inputName, double inputPercentage)
        {
            name = inputName;
            percentage = inputPercentage;
        }

        public double GetPercentage()
        {
            return percentage;
        }

        public string GetName()
        {
            return name;
        }
    }
}
