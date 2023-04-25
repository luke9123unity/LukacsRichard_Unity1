using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioSet audioSet;

    void OnValidate()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            source.clip = audioSet.GetRandom();
            source.Play();
        }
    }
}
