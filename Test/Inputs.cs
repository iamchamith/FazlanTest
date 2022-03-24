using System;

namespace Test
{
    public class Inputs
    {
        #region Properties
        private string _typeOfInput;

        //since this is a property shold follow PascalCase
        public readonly double _annualChangeInYearlyPayments;

        /*since the values are assign only from constractor, you can add readonly to following properties
        then no one can override the values. 

        example:
         public readonly int Time ;
         public readonly DiscountRate { get; }
         */

        public int Time { get; }
        public double DiscountRate { get; }
        public double Cost { get; }
        public double Inflation { get; }
        public int YearsToRollForwardBy { get; }
        public double RollForwardInflationRate { get; }
        public bool IsContinuous { get; }
        #endregion

        #region Constructor

        // Constractor 2
        public Inputs(string typeOfInput, double cost, double inflation, double annualChangeInYearlyPayments,
            int time, double discountRate, bool isContinuous, int yearsToRollForward, double rollForwardInflationRate)
        {

            /*
              since constractor 1 accept all parameter which have constractor 2 , pass that arguments to constractor 1
            
            example

             public Inputs(string typeOfInput, double cost, double inflation, double annualChangeInYearlyPayments,
            int time, double discountRate, bool isContinuous, int yearsToRollForward, double rollForwardInflationRate):
            this(typeOfInput,cost,inflation,annualChangeInYearlyPayments, time,discountRate,isContinuous))

             */

            /*
              validate the arguments before assign,

             example,
             cost should between 0-any . can not be less than zero. therefore while assigin the cost , you should check the value

             if(cost < 0)
               throw new ApplicationException("Cost should grater than 0");

             like you should need to validate DiscoultRate,YearsToRollForwardBy,RollForwardInflationRate,Time while creating "Inputs" type objects

             */

            _typeOfInput = typeOfInput;
            Cost = cost;
            Inflation = inflation;
            _annualChangeInYearlyPayments = annualChangeInYearlyPayments;
            Time = time;
            DiscountRate = discountRate;
            IsContinuous = isContinuous;
            YearsToRollForwardBy = yearsToRollForward;
            RollForwardInflationRate = rollForwardInflationRate;
        }
        
        // Constractor 1
        public Inputs(string typeOfInput, double cost, double inflation, double annualChangeInYearlyPayments,
            int time, double discountRate, bool isContinuous)
        {
            _typeOfInput = typeOfInput;
            Cost = cost;
            Inflation = inflation;
            _annualChangeInYearlyPayments = annualChangeInYearlyPayments;
            Time = time;
            DiscountRate = discountRate;
            IsContinuous = isContinuous;
        }
        #endregion

        #region Public Methods
        public double GetAvgPercentOfAnnualChangeInPayments(int cashFlowYear)
        {
            double factor = (100 + _annualChangeInYearlyPayments)/100;
            double avgPercentOfAnnualChangeInPayments = ((Math.Pow(factor, cashFlowYear) + Math.Pow(factor, cashFlowYear + 1)) / 2);
            return avgPercentOfAnnualChangeInPayments;
        }
        #endregion
    }
}