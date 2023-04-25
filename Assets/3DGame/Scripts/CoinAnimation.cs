using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource blinkSound;

 //   [SerializeField] List<AudioClip> clips;
    [SerializeField] AudioSet audioSet;

    void Update()
    {
        Collector[] collectors = FindObjectsOfType<Collector>();
        float distance = float.MaxValue;

        if (collectors.Length > 0)
        {
            Vector3 pos = transform.position;
            for(int i =0 ; i < collectors.Length; i++)
            {
                Collector c = collectors[i];
                float currentDist = Vector3.Distance(c.transform.position, pos);
                if (currentDist < distance)
                {
                    distance= currentDist;
                }
            }
        }

        animator.SetFloat("PlayerDistance", distance);
    }

    public void Blink()
    {
        blinkSound.clip = audioSet.GetRandom();
        //int randomIndex = Random.Range(0, clips.Count);
       // blinkSound.clip = clips[randomIndex];

        blinkSound.Play();
    }
}
