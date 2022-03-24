using System.Collections.Generic;

namespace Test
{
    public class Result
    {
        #region Properties
        /*make as readonly*/
        public List<double[]> TotalProjections;
        public List<double[]> TotalDiscountedProjections;
        #endregion

        #region Constructor
        public Result(List<double[]> totalProjections, List<double[]> totalDiscountedProjections)
        {
            /*
            need to check "totalProjections","totalDiscountedProjections" are null or empty before process
             
             */
            TotalDiscountedProjections = totalDiscountedProjections;
            TotalProjections = totalProjections;
        }
        #endregion
    }
}