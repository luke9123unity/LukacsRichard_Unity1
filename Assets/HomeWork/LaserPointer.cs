using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    [SerializeField] Transform[] points;

    void Update()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.up;

        Ray ray = new Ray(origin, direction);

        //ray.direction = direction;
        //ray.origin = origin;

        bool isHit = Physics.Raycast(ray, out RaycastHit hit);

        if (isHit)
        {
            for (int i = 0; i < points.Length; i++)
            {
                Transform point = points[i];
                float t = i / (float)(points.Length-1);
                point.position = Vector3.Lerp(origin, hit.point, t);
            }
        }
        foreach (Transform point in points)
        {
            point.gameObject.SetActive(isHit);
        }
    }
}
