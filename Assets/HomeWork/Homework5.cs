using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Homework5 : MonoBehaviour
{

   void Start()
   {
        WriteFirstNumbers(3);
   }
   //1. feladat
   void WriteFirstNumbers(int n)
    {
        int found = 0;

        for(int i=1; found < n; i++)
        {
            int sumOfDigits=SumOfDigits(i);
            if(sumOfDigits==n)
            {
                found++;
                Debug.Log(i);
            }
        }
    }

    int SumOfDigits(int n)
    {
        int sum = 0;
        while(n > 0)
        {
            int lastDigit = n%10;
            sum += lastDigit;
            n /=10;
        }
        return sum;
    }

    //2. feladat
    void MinCash(int value)
    {
        int leastCashNum = 0;
        string namedCash = "";
        int[] possibleCash = { 20000, 10000, 5000, 2000, 1000, 500, 200, 100, 10, 5, 2, 1 };
        for (int i = 0; i < possibleCash.Length; i++)
        {
            //Debug.Log(possibleCash[i]);
            if (value >= possibleCash[i])
            {
                int local = RemoveFrom(value, possibleCash[i]);
                //Debug.Log(local);
                value = value - (local * possibleCash[i]);
                namedCash += local + "*" + possibleCash[i] + ";";
                leastCashNum += local;
            }
        }
        Debug.Log(leastCashNum);
        Debug.Log(namedCash);
    }

    int RemoveFrom(int value, int number)
    {
        int times = 0;
        while (value - number >= 0)
        {
            value -= number;
            times += 1;
        }
        return times;
    }

    //3. feladat
    float ArrayAvg(float[] numbers)
    {
        float avg = 0;
        foreach (float n in numbers)
        {
            avg += n;
        }
        avg /= numbers.Length;
        return avg;
    }

    //4. feladat
    int BinToDec(int numbers)
    {
        int[] digits = numbers.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
        Array.Reverse(digits);
        double result = 0;
        for (int i = 0; i < digits.Length; i++)
        {
            if (digits[i] == 0 || digits[i] == 1)
            {
                result += Math.Pow(2, i) * digits[i];
            }
            else
            {
                return 0;
            }
        }
        return (int)result;
    }
}
