using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMover : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] Transform posA, posB;

    [SerializeField, Range(0, 1)] float startPosition = 0.5f;

    Transform nextTarget;

    //csak editorban jelenik meg
    void OnDrawGizmos()
    {
        if (posA == null) return;
        if (posB == null) return;

        Color c1 = Color.red;
        Color c2 = new Color(0, 0, 1);

        Gizmos.color = Color.Lerp(c1, c2, startPosition);

        Gizmos.DrawSphere(posA.position, 0.1f);
        Gizmos.DrawSphere(posB.position, 0.1f);
        Gizmos.DrawLine(posA.position, posB.position);
    }

    void OnValidate()
    {
        //lineáris interpoláció
        transform.position = Vector3.Lerp(posA.position, posB.position, startPosition);
    }

    void Start()
    {
        nextTarget = posA;
    }

    void Update()
    {
        //Vector3 direction = posA-posB;
        //Vector3 velocity = direction * speed;

        Vector3 targetPosition = nextTarget.position;

        Vector3 nextPosition = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.position = nextPosition;

        if (nextPosition == targetPosition)
        {
            if (nextTarget == posA)
            {
                nextTarget = posB;
            }
            else
            {
                nextTarget = posA;
            }
        }
    }
}
