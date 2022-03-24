using System;
using Test.Discounter;

namespace Test
{
    public class RollForward
    {
        #region Constructor
        public RollForward(Projector projector)
        {
            /*
         validate "projector" check if null or empty

        example:
        --------

        if(rollForwardProjections == null || !rollForwardProjections.Any() || rollForwardProjections.Inputs==null )
        { // return default of throw exception}

         */

            Projector = projector;
        }
        #endregion

        #region Properties

        public Projector Projector;
        #endregion

        #region Public Methods

        /*this "GetRollForwardProjections" method overide by V2, create the method as virtual method
         example:
        -------------

        public virual double[] GetRollForwardProjections(.....

         */

        public double[] GetRollForwardProjections(int rollForwardYear, double[] inflatedArrayWithDecrement)
        {

            /*
             validate "inflatedArrayWithDecrement" check if null or empty

            example:
            --------

            if(inflatedArrayWithDecrement == null || !inflatedArrayWithDecrement.Any())
            { // return default of throw exception}

             */

            double assumedInflationFactor = 1 + Projector.Inputs.Inflation / 100;
            double knownInflationFactor = 1 + Projector.Inputs.RollForwardInflationRate / 100;

            /*
            
            check "inflatedArrayWithDecrement.Length > rollForwardYear" before create "rollForwardCashflows"

             */

            double[] rollForwardCashflows = new double[inflatedArrayWithDecrement.Length - rollForwardYear];

            /*
             check length of "rollForwardCashflows > 0" before process. can throw exception of default value. 
             */

            for (int i = 0; i < rollForwardCashflows.Length; i++)
            {
                double discountFactor = Math.Pow(1 + Projector.Inputs.DiscountRate, -1);

                /*
                 this code can cause DevideByZeroException, therefore , before process need to check 

                if(Math.Pow(assumedInflationFactor, rollForwardYear) * discountFactor == 0)
                 {  // continue or thow exception }

                 */
                rollForwardCashflows[i] = inflatedArrayWithDecrement[i + rollForwardYear] *
                                          Math.Pow(knownInflationFactor, rollForwardYear) /
                                          Math.Pow(assumedInflationFactor, rollForwardYear) * discountFactor;
            }

            return rollForwardCashflows;
        }


        /*this "GetRollForwardDiscountedProjections" method overide by V2, create the method as virtual method*/
        public double[] GetRollForwardDiscountedProjections(int rollForwardYears, double[] rollForwardProjections)
        {

            /*
           validate "rollForwardProjections" check if null or empty

          example:
          --------

          if(rollForwardProjections == null || !rollForwardProjections.Any())
          { // return default of throw exception}

           */

            if (Projector.Inputs.IsContinuous)
            {

                // need to inject "discounterContinuous" rather than create new instance over here.
                DiscounterContinuous discounterContinuous = new DiscounterContinuous(Projector);
                return discounterContinuous.GetDiscountedValue(rollForwardProjections);
            }

            else
            {
                // need to inject "discounterContinuous" rather than create new instance over here.
                DiscountEndOfYear discountEndOfYear = new DiscountEndOfYear(Projector);
                return discountEndOfYear.GetDiscountedValue(rollForwardProjections);
            }
        }
        #endregion
    }
}
