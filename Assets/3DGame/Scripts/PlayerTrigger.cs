using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioSet audioSet;
    [SerializeField] Dialog dialog;
    [SerializeField] TMP_Text question;
    [SerializeField] Canvas canvas;

    void Start()
    {
        canvas.enabled= false;
    }

    void OnValidate()
    {
        source = GetComponent<AudioSource>();
        canvas = GetComponent<Canvas>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null) return;
        
        source.clip = audioSet.GetRandom();
        source.Play();
        if (dialog != null)
        {
            canvas.enabled= true;
            Debug.Log(dialog.GetText());
            question.text=dialog.GetText();
        }
            
    }

    void OnTriggerExit(Collider other)
    {
        canvas.enabled = false;
    }
}
