using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    [SerializeField]
    MetronomeSound m_sound;
    [SerializeField]
    MetronomeTimer m_timer;
    [SerializeField]
    AudioSource m_audio;
    [SerializeField]
    bool m_isOnPointSound = true;
    public void IsOnPointSound(bool value)
    {
        m_isOnPointSound = value;
    }    

    void BeatEvent(int beat)
    {
        if (m_isOnPointSound == true && beat == 1)
        {
            m_audio.clip = m_sound.GetBeatSoundPoint();            
        }
        else
        {
            m_audio.clip = m_sound.GetBeatSound();
        }

        m_audio.Play();
    }

    public void OnMetronomeEvent()
    {
        m_timer.AddBeatAction(BeatEvent);
        m_timer.On();
    }

    public void OffMetronomeEvent()
    {
        m_timer.Off();
        m_timer.DeleteBeatAction(BeatEvent);
    }

    public void SetBPM(int bpm)
    {
        m_timer.SetBPM(bpm);
    }

    public void SetBPM(float bpm)
    {
        m_timer.SetBPM((int)bpm);
    }
}