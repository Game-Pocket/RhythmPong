using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeronomeUIInitializer : MonoBehaviour
{
    //< UI초기화는 어쩔 수 없이 노가다가 들어갈 수 밖에 없다.
    Metronome m_data;
    Text m_bpmText;
    Slider m_slider;
    Toggle m_toggle;

    void Awake()
    {
        GetHandle();
    }

    void Start()
    {
        if (IsAlreadyHandle() == false) return;

        Initialize();
    }

    void Initialize()
    {
        m_slider.value = m_data.GetBPM();
        m_toggle.isOn = m_data.GetIsOnPointSound();
    }

    bool IsAlreadyHandle()
    {
        if (m_data == null || m_bpmText == null ||
            m_slider == null || m_toggle == null)
        {
            Debug.LogError("Handle NULL");
            return false;
        }

        return true;
    }

    void GetHandle()
    {
        m_data = GetComponentInParent<Metronome>();

        m_bpmText = this.GetComponentInChildren<Text>("BPMText");
        m_slider = this.GetComponentInChildren<Slider>("Slider");
        m_toggle = this.GetComponentInChildren<Toggle>("Toggle");
    }
}