using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassNewtonMethodTask1
{
    public static class NewtonMethod
    {
        /// <summary>
        /// Method calculating root of the n-th degree from double value with accuracy
        /// </summary>
        /// <param name="value">value to the calculate</param>
        /// <param name="power">degree to the calculate</param>
        /// <param name="accuracy">accurancy to the check</param>
        /// <returns></returns>
        public static double RootCalculation(double value, double power, double accuracy)
        {
            double startValueX0=1;
            double squareRoot = (1 / power) * ((power - 1) * startValueX0 + (value / Math.Pow(startValueX0, power - 1)));
            double temp;
            do{
                temp=squareRoot;
                squareRoot = (1 / power) * ((power - 1) * squareRoot + (value / Math.Pow(squareRoot, power - 1)));
            }while(Math.Abs(temp-squareRoot)>accuracy);
            return squareRoot;
        }
    }
}
