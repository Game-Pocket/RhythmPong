using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TEXT에 달아놓고 쓰세요
public class SliderText : MonoBehaviour
{
    Text m_text;
    Text Handle
    {
        get
        {
            if(m_text == null)
            {
                m_text = GetComponent<Text>();
            }

            return m_text;
        }
        set { m_text = value; }
    }

    public void SetText(float value)
    {
        Handle.text = Mathf.FloorToInt(value).ToString();
    }
}