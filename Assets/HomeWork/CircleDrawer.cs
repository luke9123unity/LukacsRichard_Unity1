using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class CircleDrawer : MonoBehaviour
{
    [SerializeField] Vector3 center;
    [SerializeField] float radius;

    [SerializeField, Min(3)] int segmentCount = 60;

    void OnDrawGizmos()
    {
       // DrawCircleGizmo(center, radius, segmentCount);
    }

    private void OnValidate()
    {
        UpdateLineRender();
    }

    void UpdateLineRender()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        if(lineRenderer == null)
            return;

        List<Vector3> points = GetCirclePoints(center, radius, segmentCount);
        lineRenderer.positionCount = points.Count;

        for (int i = 0; i < points.Count; i++)
        {
            lineRenderer.SetPosition(i, points[i]);
        }
        
    }

    public static void DrawCircleGizmo(Vector3 center, float radius, int segmentCount)
    {
        List<Vector3> points = GetCirclePoints(center, radius, segmentCount);

        Gizmos.color = Color.yellow;

        for (int i=0; i<points.Count-1; i++)
        {
            Vector3 point = points[i];
            Vector3 point2 = points[i + 1];

            Gizmos.DrawLine(point, point2);
        }
        Gizmos.DrawLine(points[0], points[^1]); //nulladik és utolsó elem
    }

    //----------------------------------------------
    //ez már használható a CircleDrawer.GetCirclePoints()-al hívható

    public static List<Vector3> GetCirclePoints(Vector3 center,float radius, int segmentCount)
    {
        List<Vector3> points = new List<Vector3>();

        float segmentAngle = 360f / segmentCount;

        for(int i=0; i < segmentCount; i++)
        {
            float angle = i * segmentAngle;
            angle *= Mathf.Deg2Rad;

            float x = Mathf.Cos(angle)*radius;
            float y = Mathf.Sin(angle)*radius;

            Vector3 point = new Vector3(x, y) + center; ;
            points.Add(point);
        }

        return points;
    }

}
