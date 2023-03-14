using System.Collections.Generic;
using UnityEngine;

public class CollectionsPractice : MonoBehaviour
{
    [SerializeField] int[] intArraySetting;
    [SerializeField] string[] stringArraySetting;
    [SerializeField] GameObject[] gameObjectArraySetting;
    
    [SerializeField] List<string> stringListSetting;

    [SerializeField] int[][] arrayOfArraySetting; //nem tudja szerializálni
    [SerializeField] int[,] matrix; //nem tudja szerializálni

    void Start()
    {
        int a = 67;

        int[] intArray = new int[10]; //10 elemû tömb
        string[] stringArray = { "alma", "korte", "barack" };

        intArray[2] = 15;

        int element = intArray[5];

        for (int i = 0;i < intArray.Length; i++)
        {
            intArray[i] = i+1;
        }

        for (int i = 0; i < gameObjectArraySetting.Length; i++)
        {
            Debug.Log(gameObjectArraySetting[i].name);
        }

        char myFirstChar = 'a';

        char[] chars = "valami".ToCharArray(); //string átalakítás karakter tömbbé
        string s2 = new string(chars);

        string s3 = s2.Substring(s2.Length/2, s2.Length/2); //melyik karaktertõl mennyit vágunk ki
        string s4 = s2.Replace("a", "e");

        string s5 = s2.ToUpper();
        string s6 = s2.ToLower();

        bool contains = s2.Contains("la");

        int indexOf = s2.IndexOf("lam");

        // --------------------------------------------------------------------

        List<int> ints = new List<int>();
        
        for(int i=0; i<10;i++)
        {
            ints.Add(i*i);
        }

        Debug.Log(ints.Count);

        for(int i=0;i<ints.Count;i++)
        {
            Debug.Log(ints[i]);
        }

        List<string> strings = new List<string> { "alma", "korte", "dio", "sajt"};

        bool success = strings.Remove("dios"); //false

        strings.RemoveAt(2);    //2es indexen töröl

        strings.Sort(); //rendezés

        strings.Insert(1,"121131414");

        string sss = strings[2];
        strings.RemoveAt(2);
        strings.Insert(2,sss);

        strings.Clear(); 

    }
}
