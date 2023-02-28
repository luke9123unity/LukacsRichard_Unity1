using UnityEngine;

public class Collector : MonoBehaviour
{
    int pointsCollected = 0;
    public void Collect(int value)
    {
        pointsCollected+=value;
        Debug.Log(pointsCollected.ToString());
    }

    public int Points() { return pointsCollected; }
}
