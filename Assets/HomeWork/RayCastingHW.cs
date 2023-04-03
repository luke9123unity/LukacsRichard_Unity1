using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastingHW : MonoBehaviour
{
    [SerializeField] float maxRayLength = 10f;

    [SerializeField] Color gizmoColor = Color.red;

    [SerializeField] GameObject[] objectsToDraw;

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawRay(transform.position, transform.forward * maxRayLength);
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxRayLength))
        {
            Debug.Log("Hit object: " + hit.transform.name);

            for (int i = 0; i < objectsToDraw.Length; i++)
            {
                objectsToDraw[i].SetActive(true);
            }

            Vector3 hitPoint = hit.point;
            Vector3 startPos = transform.position;
            Vector3 dir = hitPoint - startPos;
            float dist = dir.magnitude;

            for (int i = 0; i < objectsToDraw.Length; i++)
            {
                float t = (float)i / (float)(objectsToDraw.Length - 1);
                Vector3 pos = startPos + dir * t;
                objectsToDraw[i].transform.position = pos;
                //objectsToDraw[i].transform.LookAt(hitPoint);
            }
        }
        else
        {
            for (int i = 0; i < objectsToDraw.Length; i++)
            {
                objectsToDraw[i].SetActive(false);
            }
        }
    }
}
