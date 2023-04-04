using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] KeyCode shootKey = KeyCode.Space;
    [SerializeField] GameObject projectilePrototype;
    [SerializeField] float projectileSpeed=10f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(shootKey))
        {
            GameObject newBullet = Instantiate(projectilePrototype);
            newBullet.transform.position = transform.position;
            newBullet.transform.rotation = Quaternion.LookRotation(transform.up);
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();

            rb.velocity = transform.up * projectileSpeed;
        }
    }
}
