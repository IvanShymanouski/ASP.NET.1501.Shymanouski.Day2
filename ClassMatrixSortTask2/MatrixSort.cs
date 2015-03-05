using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMatrixSortTask2
{
    public class MatrixSort
    {

        /// <summary>
        /// Sort strings of matrix by custom function and custom selector
        /// </summary>
        /// <param name="array"></param>
        /// <param name="selector">for example: i => i.Max() </param>
        /// <param name="compare">set the rule of following for near lines
        ///                       for exemple: (i, j) => { return i > j; }
        ///                       it's for sorting according to decrease</param>
        /// <returns>new sort array</returns>
        public static void Sort(int[][] array, Func<int[],int>selector, Func<int,int,bool>compare)
        {
            int[] index;

            //Initialization
            int[] arrayOfKeys=new int[array.Length];
            index = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                arrayOfKeys[i] = selector(array[i]);
                index[i] = i;
            }

            Qsort(arrayOfKeys, 0, array.Length - 1, selector, compare, index);

            RearrangementOfArrayByIndex(array,index);
        }

        private static void Qsort(int[] array, int left, int right, Func<int[], int> selector, Func<int, int, bool> compare,int[] index)
        {
            int i = left;
            int j = right;
            int medium = array[index[(left + right) / 2]];

            while (i <= j)
            {
                while (compare(array[index[i]],medium)) i++;
                while (compare(medium,array[index[j]])) j--;
                if (i <= j)
                {
                    Swap(ref index[i],ref index[j]);
                    i++; j--;
                }
            }

            if (left < j) Qsort(array, left, j, selector, compare,index);
            if (i < right) Qsort(array, i, right, selector, compare,index);

        }

        private static void Swap(ref int a1, ref int a2)
        {
            int temp = a1;
            a1 = a2;
            a2 = temp;
        }

        private static void RearrangementOfArrayByIndex(int[][] array, int[] index)
        {
            int[][] newArray = new int[array.Length][];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[index[i]];
            }
            Array.Copy(newArray, array, array.Length);
        }
    }
}
