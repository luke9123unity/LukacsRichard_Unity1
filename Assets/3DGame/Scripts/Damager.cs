using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] int damage = 10;

    void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;

        HealthObject ho = go.GetComponent<HealthObject>();

        if(ho!=null)
        {
            ho.Damage(damage);
        }
    }
}
