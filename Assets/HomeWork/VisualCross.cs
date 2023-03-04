using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualCross : MonoBehaviour
{
    [SerializeField] float crossSize = 1;
    void OnDrawGizmos()
    {
        Vector3 center = transform.position;

        Vector3 dirY=transform.TransformDirection(Vector3.up).normalized;
        Vector3 dirX=transform.TransformDirection(Vector3.right).normalized;
        Vector3 dirZ=transform.TransformDirection(Vector3.forward).normalized;

        //Y axis
        Vector3 a = center + dirY * crossSize;
        Vector3 b = center - dirY * crossSize;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(a, b);
        Gizmos.DrawSphere(a, 0.1f);

        //X axis
        Vector3 c = center + dirX * crossSize;
        Vector3 d = center - dirX * crossSize;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(c, d);
        Gizmos.DrawSphere(c, 0.1f);

        //Z axis
        Vector3 e = center + dirZ * crossSize;
        Vector3 f = center - dirZ * crossSize;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(e, f);
        Gizmos.DrawSphere(e, 0.1f);

    }
}
