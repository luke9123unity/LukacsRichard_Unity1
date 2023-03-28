using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] float accler = 9.81f;
    [SerializeField] float drag = 0.2f;
    [SerializeField] KeyCode jumpButton=KeyCode.Space;
    [SerializeField] float jumpForce = 10f;

    Vector3 velocity = Vector3.zero;

    [SerializeField]void FixedUpdate()
    {
        Vector3 p = transform.position;

        if(p.y>=0)
        {

            velocity += Vector3.down * accler * Time.fixedDeltaTime;
            velocity -= velocity * (drag * Time.fixedDeltaTime);
        
            
        }
        else
        {
            p.y = 0;
            transform.position = p;
            velocity = Vector3.zero;
        }

        transform.position += velocity * Time.fixedDeltaTime;
    }
    void Update()
    {
        if(Input.GetKeyDown(jumpButton))
        {
            velocity += Vector3.up * jumpForce;
        }
    }
}
