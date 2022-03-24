using System.Collections.Generic;

namespace Test
{
    public class Aggregator
    {

        /*please remove unnessasary regions (Properties and COnstractor)*/
        #region Properties

        #endregion

        #region Constructor

        #endregion

        #region Public Methods
        public static double[] AggregateYearlyProjections(List<double[]> listOfProjections, List<Inputs> listOfInputs)
        {
            /*
                      check "listOfProjections","listOfInputs" is null or empty, before preceed.else this couse null reference exception.
                      */

            double[] totalArray = new double[MaximumTermOfProjection.SetTermOfProjection(listOfInputs)];

            /*
             check "totalArray"is null or empty, before preceed.else this couse null reference exception.

            example:
            -----------------

            if(totalArray == null || !totalArray.Any())
                {  handle exception or return default values }
                   */

            foreach (var projection in listOfProjections)
            {
                /*
                 check projection has value before process

                example:

                if(!projection.Any()) continue;

                 */

                for (int i = 0; i < projection.Length; i++)
                {
                    totalArray[i] += projection[i];
                }
            }

            return totalArray;
        }
        public static double GetTotalSum(double[] array)
        {
            /*
            check array is null or empty, before preceed.else this couse null reference exception.
            */

            double sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }
        #endregion
    }
}