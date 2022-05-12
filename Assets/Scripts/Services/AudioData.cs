using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class AudioData
{
    public string m_name;
    public AudioClip m_audioClip;

    public bool m_looping;

    public AudioMixerGroup m_audioMixerGroup;

    [Range(0f, 1f)]
    public float m_volume;

    [Range(0.3f, 3f)]
    public float m_pitch;

    [Range(0f, 5f)]
    public float m_fadeInSpeed;

    [Range(0f, 5f)]
    public float m_fadeOutSpeed;

    public bool m_fade;

    [HideInInspector]
    public GameObject m_object;

    [HideInInspector]
    public AudioSource m_audioSource;
}