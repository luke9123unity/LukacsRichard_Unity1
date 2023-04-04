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
            rb.velocity += gravity * Time.fixedDeltaTime; //fix gyors�t�s
            /*rb.velocity += gravity * Time.fixedDeltaTime / rb.mass; //fix er�


            // ---------------------------------

            rb.AddForce(gravity, ForceMode.Acceleration); //t�meg nem sz�m�t  // folyamatos
            rb.AddForce(gravity, ForceMode.Force); //t�meg sz�m�t

            rb.AddForce(-gravity, ForceMode.VelocityChange);  //t�meg nem sz�m�t  // egyszeri
            rb.AddForce(-gravity, ForceMode.Impulse);  //t�meg sz�m�t
            */
        }
    }
}
