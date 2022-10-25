using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueClass
{
    [SerializeField] private string m_name;

    public string Name
    {
        get { return m_name; } 
        set { m_name = value; }
    }

    [TextArea(3, 10)]
    [SerializeField] private string [] m_sentance;

    public string[] Sentance
    {
        get { return m_sentance; }
        set { m_sentance = value; }
    }

    [SerializeField] private AudioClip audioClip;

    public AudioClip AudioClip
    {
        get { return audioClip; }
        set { audioClip = value; }
    }
}
