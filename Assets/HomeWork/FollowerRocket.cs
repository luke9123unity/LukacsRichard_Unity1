using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerRocket : MonoBehaviour
{
    [SerializeField] Transform target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime);
    }
}
