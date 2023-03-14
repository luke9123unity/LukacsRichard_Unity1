using TMPro;
using UnityEngine;

public class Collector : MonoBehaviour
{
    int pointsCollected = 0;

    [SerializeField] TMP_Text uiText;

    public void Start()
    {
        NewMethod();
    }
    public void Collect(int value)
    {
        pointsCollected += value;
        NewMethod();
        //Debug.Log(pointsCollected.ToString());
    }

    private void NewMethod()
    {
        if (uiText != null)
            uiText.text = "Score: " + pointsCollected;
    }

    public int Points() { return pointsCollected; }
}
