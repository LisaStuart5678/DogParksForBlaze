using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogParksForBlaze
{
    class DogPark
    {
        #region Properties
        public string DogParkName { get; set; }
        public string DogParkAddress { get; set; }
        public int NumVisits { get; set; }
        public string Rating { get; set; }
        #endregion

        #region Methods
        public string HaveVisited(string visited)
        {
            if (NumVisits > 0)
                return "Yes";
            return "No";
        }
        public void VisitPark(int currentVisit)
        {
            NumVisits += 1;
        }
        #endregion
    }
}
