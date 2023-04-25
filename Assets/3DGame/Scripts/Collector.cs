using System.Data;
using TMPro;
using UnityEngine;

public class Collector : MonoBehaviour
{
    static int pointsCollected = 0;

    [SerializeField] TMP_Text uiText;

    public void Start()
    {
        UpdateUI();
    }
    public void Collect(int value)
    {
        pointsCollected += value;
        UpdateUI();
        //Debug.Log(pointsCollected.ToString());
    }

    private void UpdateUI()
    {
        if (uiText != null)
            uiText.text = "SCORE: " + pointsCollected;

        if(pointsCollected>1000)
        {
            pointsCollected = 0;
            GameManager.instance.NextLevel();
        }
    }



    public int Points() { return pointsCollected; }

    public static void MyMethod(int n)
    {
        for(int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Debug.Log(i * j);
            }
        }
    }

    public static int Min(int a, int b)
    {
        return a<b?a : b;
    }
}
