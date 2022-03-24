using System.Collections.Generic;

namespace Test
{
    public class Calcs
    {
        private Engine _engine;

        public Calcs(Engine engine)
        {
            /*
             check engine is null or empty, before preceed.else this couse null reference exception.

            example:
            ------------
            if(_engine==null) throw new ApplicationException("engine should not be null");

             */
            _engine = engine;
        }

        public double GetProjections(bool undiscountedProjection, List<Inputs> listOfInputs)
        {

            /*
             check listOfInput is null or empty, before preceed.else this couse null reference exception.

              example:
            ------------
             if(listOfInputs==null || !listOfInputs.Any()) throw new ApplicationException("listOfInputs shuold have values");
             */

            Result totalProjection = _engine.GetResultProjections(listOfInputs);

            if (undiscountedProjection)
            {
                double[] totalYearlyProjections = Aggregator.AggregateYearlyProjections(totalProjection.TotalProjections, listOfInputs);
                return Aggregator.GetTotalSum(totalYearlyProjections);
            }
            else
            {
                double[] totalYearlyDiscountedProjections = Aggregator.AggregateYearlyProjections(totalProjection.TotalDiscountedProjections, listOfInputs);
                return Aggregator.GetTotalSum(totalYearlyDiscountedProjections);
            }
        }
        
        public double GetRollForwardProjections(bool undiscountedProjection, int rollForwardYears, List<Inputs> listOfInputs)
        {
            /*
             check listOfInput is null or empty, before preceed.else this couse null reference exception.
             */
            Result totalRollForwardProjection = _engine.GetRollForwardProjections(listOfInputs, rollForwardYears);

            /*
             check "totalRollForwardProjection" is null or empty before process
             */

            if (undiscountedProjection)
            {
                double[] totalYearlyProjections = Aggregator.AggregateYearlyProjections(totalRollForwardProjection.TotalProjections, listOfInputs);
                return Aggregator.GetTotalSum(totalYearlyProjections);
            }
            else
            {
                double[] totalYearlyDiscountedProjections = Aggregator.AggregateYearlyProjections(totalRollForwardProjection.TotalDiscountedProjections, listOfInputs);
                return Aggregator.GetTotalSum(totalYearlyDiscountedProjections);
            }
        }
    }
}
