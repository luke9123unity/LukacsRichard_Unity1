using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallisticPath : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float speed = 10;
    [SerializeField, Min(0)] float simulationTime = 1;
    [SerializeField] LayerMask raycastMak;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        Vector3 startDirection = transform.up;

        Vector3 gravity = Physics.gravity;
        float deltaT = Time.fixedDeltaTime;

        Vector3 velocity = startDirection * speed;
        float time = 0;

        List<Vector3> points = new List<Vector3>();
        points.Add(position);

        while(time<simulationTime)
        {
            Vector3 lastPosition = position;
            position += velocity * deltaT;
            velocity += gravity * deltaT;

            Vector3 dir = position - lastPosition;
            Ray ray = new Ray(lastPosition, dir);

            bool isHit = Physics.Raycast(ray,out RaycastHit hitInfo, dir.magnitude, raycastMak);

            if (isHit)
            {
                points.Add(hitInfo.point);
                break;
            }
            else
            {
                points.Add(position);
            }

            points.Add(position);

            time += deltaT;
        }

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }
}
