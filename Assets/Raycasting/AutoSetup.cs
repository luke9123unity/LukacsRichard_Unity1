using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSetup : MonoBehaviour
{
    [SerializeField] float density = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider[] boxes = FindObjectsOfType<BoxCollider>();

        foreach (BoxCollider box in boxes)
        {
            Rigidbody rb = box.GetComponent<Rigidbody>();
            if(rb!= null)
            {
                Vector3 scale = box.transform.lossyScale;

                float volume = box.size.x * box.size.y * box.size.z * scale.x * scale.y * scale.z;
                rb.mass = volume * density;
            }
        }
    }
}
