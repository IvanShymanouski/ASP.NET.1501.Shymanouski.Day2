using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatestCommonDivisorLibrary
{
    public static class GreatestCommonDivisor
    {
        #region Euclidean
        /// <summary>
        /// Method calculates greatest common divisor of two numbers with help the Euclidean algorithm.
        /// </summary>
        /// <param name="a"> First number </param>
        /// <param name="b"> Second number </param>
        /// <returns> Greatest Common divisor </returns>
        public static int EuclideanAlgorithmWithTiming(out long passedTicks, int a, int b)
        {
            long startTicks = System.Diagnostics.Stopwatch.GetTimestamp();

            int result = EuclideanAlgorithm(a, b);

            passedTicks = System.Diagnostics.Stopwatch.GetTimestamp() - startTicks;
            return result;
        }

        private static int EuclideanAlgorithm(int a, int b)
        {
            if (a < 0) a = -a;
            if (b < 0) b = -b;

            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        /// <summary>
        /// Method calculates greatest common divisor of N-th numbers with help the Euclidean algorithm.
        /// </summary>
        /// <param name="passedTicks"></param>
        /// <param name="param"> Numbers </param>
        /// <returns> Greatest common divisor </returns>
        public static int EuclideanAlgorithmWithTiming(out long passedTicks, params int[] param)
        {
            long startTicks = System.Diagnostics.Stopwatch.GetTimestamp();

            int result = EuclideanAlgorithm(param);

            passedTicks = System.Diagnostics.Stopwatch.GetTimestamp() - startTicks;
            return result;
        }

        private static int EuclideanAlgorithm(params int[] param)
        {
            switch (param.Length)
            {
                case 0: return 0;
                case 1: return param[0];
            }
            int a = param[0];

            for (int i = 1; i < param.Length; i++)
            {
                a = EuclideanAlgorithm(a, param[i]);
            }

            return a;
        }
        #endregion

        #region Stein's
        /// <summary>
        /// Method calculates greatest common divisor of two numbers with help the Stein's algorithm.
        /// </summary>
        /// <param name="passedTicks"></param>
        /// <param name="a"> First number </param>
        /// <param name="b"> Second number </param>
        /// <returns> Greatest Common divisor </returns>
        public static int SteinAlgorithmWithTiming(out long passedTicks, int a, int b)
        {
             long startTicks = System.Diagnostics.Stopwatch.GetTimestamp();

             int result = SteinAlgorithm(a,b);

             passedTicks = System.Diagnostics.Stopwatch.GetTimestamp() - startTicks;
             return result;
        }

        private static int SteinAlgorithm(int a, int b)
        {
            int shift;

            if (a < 0) a = -a;
            if (b < 0) b = -b;
            if (a == 0) return b;
            if (b == 0) return a;
            
            //while a and b is even numbers
            for (shift = 0; ((a | b) & 1) == 0; ++shift)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)  a >>= 1;

            do
            {
                while ((b & 1) == 0) b >>= 1;

                if (a > b) Swap(ref a, ref b);  

                b = b - a;                  
            } while (b != 0);

            return a << shift;
        }

        /// <summary>
        /// Method calculates greatest common divisor of N-th numbers with help the Stein's algorithm.
        /// </summary>
        /// <param name="passedTicks"></param>
        /// <param name="param"> Numbers </param>
        /// <returns> Greatest common divisor </returns>
        /// <returns></returns>
        public static int SteinAlgorithmWithTiming(out long passedTicks, params int[] param)
        {
            long startTicks = System.Diagnostics.Stopwatch.GetTimestamp();

            int result = SteinAlgorithm(param);

            passedTicks = System.Diagnostics.Stopwatch.GetTimestamp() - startTicks;
            return result;
        }

        private static int SteinAlgorithm(params int[] param)
        {
            switch (param.Length)
            {
                case 0: return 0;
                case 1: return param[0];
            }
            int a = param[0];

            for (int i = 1; i < param.Length; i++)
            {
                a = SteinAlgorithm(a, param[i]);
            }

            return a;
        }
        #endregion

        private static void Swap(ref int a1, ref int a2)
        {
            int temp = a1;
            a1 = a2;
            a2 = temp;
        }
    }
}
