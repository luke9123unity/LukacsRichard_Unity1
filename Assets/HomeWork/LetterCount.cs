using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterCount : MonoBehaviour
{
    [SerializeField] string text = "ABC";

    [SerializeField] int count = 0;

    void OnValidate()
    {
        count = CountLetters(text);
    }
    int CountLetters(string text)
    {
        List<char> characters = new List<char>();
        text = text.ToUpper();
        text = text.Replace(" ","");

        foreach (char c in text)
        {
            if (!characters.Contains(c))
            {
                characters.Add(c);
            }
        }

        return characters.Count;
    }
}
