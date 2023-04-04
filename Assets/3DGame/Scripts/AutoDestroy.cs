using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float distanceFromCreation = 100;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float currentDistance = Vector3.Distance(startPos, transform.position);
        if(currentDistance > distanceFromCreation)
        {
            Destroy(gameObject);
        }
    }
}
