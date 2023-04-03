using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMod : MonoBehaviour
{
    public float gravityStrength = -10f;
    public float gravityRadius = 5f;

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, gravityRadius);

        foreach (Collider collider in colliders)
        {
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                Vector3 gravityDirection = transform.position - collider.transform.position;
                float distance = gravityDirection.magnitude;
                float distanceRatio = 1f - Mathf.Clamp01(distance / gravityRadius);
                float strength = gravityStrength * distanceRatio;
                rigidbody.AddForce(gravityDirection.normalized * strength, ForceMode.Acceleration);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, gravityRadius);
    }
}
