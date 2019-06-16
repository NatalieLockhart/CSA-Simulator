using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSA_Simulator
{
    public class CSASimulator
    {
        private List<CSAItem> CSAList;
        private int boxLimit = 12;
        private List<CSAItem> box;
        private Random rand = new Random();


        public CSASimulator(List<CSAItem> list)
        {
            CSAList = list;
            box = new List<CSAItem>();
        }

        //calculate the CSA items and return them for output
        public List<CSAItem> calculateThings()
        {
            //go through list - check if hit or miss - populate 0/1 list with results
            //go through 0/1 list - add items to string list 
            //check if limit has been reached. if not, go again

            for (int i = CSAList.Count()-1; i>0; i--)
            {
                var one = CSAList[i].GetPercentage() * 100;
                var two = rand.NextDouble()*100;

                //if (CSAList[i].GetPercentage()*100 >= rand.NextDouble()*10)
                if (one >= two)
                {
                    box.Add(CSAList[i]);
                }
                if (box.Count() >= boxLimit){
                    break;
                }
            }

            //if the box isn't full yet, rerun the calculate function until it's full.
            if (box.Count < boxLimit)
            {
                calculateThings();
            }

            return box;
        }

        //Sets the number of items that appear in the CSA box
        public void setBoxLimit(int newLimit)
        {
            boxLimit = newLimit;
        }

    }
}
