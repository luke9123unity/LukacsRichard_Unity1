using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityModifier : MonoBehaviour
{
    List<Rigidbody> rigidbodies = new List<Rigidbody>();

    [SerializeField] Vector3 gravity;
    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if(rb != null)
        {
            rigidbodies.Add(rb);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rigidbodies.Remove(rb);
        }
    }

    void FixedUpdate()
    {
        foreach(Rigidbody rb in rigidbodies)
        {
            rb.velocity += gravity * Time.fixedDeltaTime; //fix gyorsítás
            /*rb.velocity += gravity * Time.fixedDeltaTime / rb.mass; //fix erõ


            // ---------------------------------

            rb.AddForce(gravity, ForceMode.Acceleration); //tömeg nem számít  // folyamatos
            rb.AddForce(gravity, ForceMode.Force); //tömeg számít

            rb.AddForce(-gravity, ForceMode.VelocityChange);  //tömeg nem számít  // egyszeri
            rb.AddForce(-gravity, ForceMode.Impulse);  //tömeg számít
            */
        }
    }
}
