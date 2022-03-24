﻿using System;

namespace Test
{
    public class Projector
    {
        #region Properties
        public Inputs Inputs;
        #endregion

        #region Constructor
        public Projector(Inputs inputs)
        {
            /*
             check input is valied varialble. check null reference exception
             */
            Inputs = inputs;
        }
        #endregion

        #region Public Methods
        public double[] GetInflatedCost()
        {

            // need to check  Inputs.Time > 0 before process. else can throw a exception or return a default value
            /*
             example:
             ------------
            if(Inputs.Time <= 0)
                throw new ApplicationException("Time should be grater than zero");


             */

            double[] projections = new double[Inputs.Time];
            double factor = (Inputs.Inflation + 100) / 100;

            for (int i = 0; i < Inputs.Time; i++)
            {
                projections[i] = Inputs.Cost * GetProjectionFactor(factor, i);
            }

            return projections;
        }
        
        public double[] GetInflatedCostWuthDecrement()
        {
            double[] projections = GetInflatedCost();

            // need to validate projections is null or empty before proess
            // need to validate Input.Time > 0

            double[] projectionsWithDecrement = new double[Inputs.Time];
            double factor = (100 + Inputs._annualChangeInYearlyPayments)/100;

            for (int i = 0; i < projections.Length; i++)
            {
                projectionsWithDecrement[i] = projections[i] * Math.Pow(factor, i + 1);
            }

            return projectionsWithDecrement;
        }

        public void UpdateInflatedCostWithDecrement(double[] salaryProjectionsWithoutDecrement)
        {
            /*
             check salaryProjectionsWithoutDecrement is null or empty, before process.
             */
            for (int i = 0; i < Inputs.Time; i++)
            {
                salaryProjectionsWithoutDecrement[i] *= Inputs.GetAvgPercentOfAnnualChangeInPayments(i);
            }
        }
        #endregion

        #region Private Methods
        private static double GetProjectionFactor(double factor, int cashFlowYear)
        {
            /*
             validate factor and cacheFlowYear before process.
             */
            return (Math.Pow(factor, cashFlowYear));
        }
        #endregion
    }
}