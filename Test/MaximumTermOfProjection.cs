using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class MaximumTermOfProjection
    {
        public static int SetTermOfProjection(List<Inputs> listOfInputs)
        {

            // please handle null reference exception. Create customer exception for handle it
            /*
             
            if(listOfInputs == null)
                throw New ApplicationException("List of inputs could not be null");             
             */

            //why putting 4 ? what if listOfInputs > 4 . you can remove 4.
            List<int> termOfProjections = new List<int>(4);
            foreach (Inputs input in listOfInputs)
            {
                // no need to create another varialble on stack (int). derecly add output to the termOfProjection list
                int termOfProjection = input.Time;
                termOfProjections.Add(termOfProjection);
            }

            // no need this convertion. can direcly use
            // termOfProjections.Max();
            int[] arrayOfTerms = termOfProjections.ToArray();

            int maximumTerm = arrayOfTerms.Max();
            return maximumTerm;
        }
    }
}