using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HosssienCod
{
    public static class Tools
    {
        public static int maxNum(this int[] numbers)
        {
            int bigestNumber = Mathf.Max(numbers);
            return bigestNumber;
        }
        public static float maxNum(this float[]numbers)
        {
            float bigestNumber = Mathf.Max(numbers);
            return bigestNumber;
        }
        public static int minNum(this int[] numbers)
        {
            int SmalestNumber = Mathf.Min(numbers);
            return SmalestNumber;
        }
        public static float minNum(this float[] numbers)
        {
            float SmalestNumber = Mathf.Min(numbers);
            return SmalestNumber;
        }

        ////public static int [] SortByBIG (this int[] numbers)
        //{
        //    int[] checklist = numbers;
        //    int[] result = new int[numbers.Length];
        //    int currentMaxnum;

        //    for (int i  = 0; i < numbers.Length; i++)
        //    {
                
        //        result[i] = Mathf.Max(checklist);
        //        checklist
        //    }
        //    return result;
        //}
    }
    
       
    

}
