using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homework3 : MonoBehaviour
{
    [SerializeField] int number = 10;

    void Start()
    {
        nPrime(number);
    }

    void nPrime(int n)
    {
        int i = 2;
        while (n > 0)
        {
            if (isPrime(i))
            {
                Debug.Log(i);
                n--;
            }
            i++;
        }
    }

    bool isPrime(int num)
    {
        for (int i = 2; i <= num / 2; i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }
        return true;
    }

}
