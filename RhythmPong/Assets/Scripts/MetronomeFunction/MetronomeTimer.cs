using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetronomeTimer : MonoBehaviour
{
    const int baseBeat = 1;
    const float baseMinit = 60f;

    [SerializeField]
    int m_bpm;
    public void SetBPM(int bpm)
    {
        m_bpm = bpm;
        m_intervalSeconds = GetInterval(m_bpm);
    }

    public int GetBPM()
    {
        return m_bpm;
    }

    [SerializeField]
    int m_beats;    
    bool m_isOn;

    int m_currentBeat;
    float m_intervalSeconds;
    float m_curTime;    

    Action<int> m_beatAction;

    public void AddBeatAction(Action<int> beatAction)
    {
        m_beatAction += beatAction;
    }

    public void DeleteBeatAction(Action<int> beatAction)
    {
        m_beatAction -= beatAction;
    }

    public void ClearBeatAction()
    {
        m_beatAction = null;
    }

    void OnBeatAction(int beat)
    {
        if(m_beatAction != null)
        {
            m_beatAction(beat);
        }
    }	

    float GetInterval(int bpm)
    {        
        float returnValue = baseMinit / bpm;
        return returnValue;
    }    

    void Update()
    {
        if (m_isOn == false) return;

        m_curTime += Time.deltaTime;

        if (m_curTime >= m_intervalSeconds)
        {
            OnBeatAction(m_currentBeat);

            ++m_currentBeat;

            if (m_currentBeat > m_beats)
            {
                m_currentBeat = baseBeat;
            }

            m_curTime -= m_intervalSeconds;
        }                
    }

    public void On()
    {
        m_currentBeat = baseBeat;
        m_intervalSeconds = GetInterval(m_bpm); //< bpm 정보를 갖고 인터벌 계산.
        m_curTime = m_intervalSeconds;
        m_isOn = true;
    }

    public void Off()
    {
        m_isOn = false;
    }
}