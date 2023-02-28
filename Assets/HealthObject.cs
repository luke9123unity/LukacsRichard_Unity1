using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthObject : MonoBehaviour
{
    [SerializeField, Min(1)] int maxHealth = 100;

    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(int damage)
    {

        if (currentHealth <= 0)
            return;

        currentHealth = Mathf.Max(currentHealth - damage, 0);
        //currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
            //GetComponent<Collider>().enabled=false;
            //GetComponent<Mover>().enabled = false;
        }
    }
}
