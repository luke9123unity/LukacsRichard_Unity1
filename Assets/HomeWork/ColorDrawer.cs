using UnityEngine;

public class ColorDrawer : MonoBehaviour
{
    [SerializeField] Vector3 point1, point2;

    [SerializeField] Color color1 = Color.white;
    [SerializeField] Color color2 = Color.white;

    [SerializeField, Min(2)] int segmentCount = 2;

    // Update is called once per frame
    void OnDrawGizmos()
    {
        float step = 1 / (float)segmentCount;

        for(int i=0;i<segmentCount; i++)
        {
            Color mixedColor=Color.Lerp(color1, color2, (float)i/(segmentCount-1));
            Vector3 draw1=Vector3.Lerp(point1, point2, i*step);
            Vector3 draw2=Vector3.Lerp(point1, point2, (i+1)*step);
            Gizmos.color = mixedColor;
            Gizmos.DrawLine(draw1, draw2);
        }
    }
}