using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
 
    // Update is called once per frame
    void Update()
    {
        Vector3 selfPosition = transform.position;
        Vector3 targetPosition = target.position;

        Vector3 direction = targetPosition - selfPosition;
        /*
        Vector3 direction = targetPosition- selfPosition;
        direction.Normalize();

        Vector3 velocity = direction * speed;

        transform.position = transform.position +  velocity * Time.deltaTime();*/

        transform.position = Vector3.MoveTowards(selfPosition, targetPosition, speed*Time.deltaTime);

       /* if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }*/

    }
}
