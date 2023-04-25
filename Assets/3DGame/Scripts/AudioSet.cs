using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] 

public class AudioSet : ScriptableObject
{
    [SerializeField] List<AudioClip> clips;

    public AudioClip GetRandom()
    {
        int randomIndex = Random.Range(0,clips.Count);
        return clips[randomIndex];
    }
}
