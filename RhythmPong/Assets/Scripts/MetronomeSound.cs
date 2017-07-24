using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetronomeSound : MonoBehaviour
{
    [SerializeField]
    AudioClip m_beatSoundPoint;
    [SerializeField]
    AudioClip m_beatSound;

    public AudioClip GetBeatSound()
    {
        return m_beatSound;
    }

    public AudioClip GetBeatSoundPoint()
    {
        return m_beatSoundPoint;
    }
}