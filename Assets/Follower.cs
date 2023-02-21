using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] Transform target;
 
    // Update is called once per frame
    void Update()
    {
        Vector3 selfPosition = transform.position;
        Vector3 targetPosition = target.position;

        Vector3 direction = targetPosition- selfPosition;
        direction.Normalize();

        transform.position += direction * Time.DeltaTime();
    }
}
