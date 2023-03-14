using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerRocket : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] float speed = 2;
    [SerializeField] float angularRotation = 90;

    void Update()
    {
        if(target == null)
            return;

        Vector3 targetForward = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetForward);

        transform.position += transform.forward * speed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angularRotation*Time.deltaTime);

    }
}
