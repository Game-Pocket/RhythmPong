using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythemTestSceneManager : MonoBehaviour
{
    [SerializeField]
    MetronomeTimer m_metronome;
    [SerializeField]
    AudioSource m_audio;
    [SerializeField]
    AudioClip m_beatSound_Start;
    [SerializeField]
    AudioClip m_beatSound;    

    void BeatEvent(int beat)
    {
        string debugContent = string.Empty;

        if(beat == 1)
        {
            m_audio.clip = m_beatSound_Start;
            debugContent = "딱";
        }
        else
        {
            m_audio.clip = m_beatSound;
            debugContent = "띡";
        }

        m_audio.Play();
        Debug.Log(beat + "Beat! : " + debugContent);
    }

    void OnDestroy()
    {
        OffMetronomeEvent();
        m_metronome = null;
    }

    public void OnMetronomeEvent()
    {
        m_metronome.AddBeatAction(BeatEvent);
        m_metronome.On();
    }

    public void OffMetronomeEvent()
    {
        m_metronome.Off();
        m_metronome.DeleteBeatAction(BeatEvent);
    }
}