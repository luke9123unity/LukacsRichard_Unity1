using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float destroyDistance = 100;
    [SerializeField] float destroyTime = 100;

    Vector3 startPos;
    //float startTime;

    void Start()
    {
        startPos = transform.position;
        //startTime= Time.time;

        //Destroy(gameObject, destroyTime); //késleltetve

        //DestroySelf();

        Invoke(nameof(DestroySelf), destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        float currentDistance = Vector3.Distance(startPos, transform.position);
        if(currentDistance > destroyDistance)
        {
            Destroy(gameObject);
        }

        /*float age = Time.time - startTime;
        if(age > destroyTime)
        {
            Destroy(gameObject);
        }*/
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
