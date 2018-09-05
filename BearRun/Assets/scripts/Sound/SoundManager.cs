using System.Collections;
using System.Collections.Generic;
using UnityEngine;



///*****************
///  A  LeenYee Game
///*****************
public class SoundManager : MonoSingleton<SoundManager> {

    AudioSource m_Bgm;
    AudioSource m_effect;

    private string ResouceDir = ""+"/";
    private void Awake()
    {
        m_Bgm = gameObject.AddComponent<AudioSource>();
        m_Bgm.playOnAwake = false;
        m_Bgm.loop = true;

        m_effect = gameObject.AddComponent<AudioSource>();
    }
    /// <summary>
    /// 播放BGM
    /// </summary>
    /// <param name="Name"></param>
    public void PlayBGM(string Name)
    {
        string oldName;
        if (m_Bgm.clip==null)
        {
            oldName = "";
        }
        else
        {
            oldName = m_Bgm.clip.name;
        }

        if (oldName!=Name)
        {
            string path = ResouceDir + Name;
            AudioClip clip = Resources.Load<AudioClip>(path);
            if (clip!=null)
            {
                m_Bgm.clip = clip;
                m_Bgm.Play();
            }
        }
    }
/// <summary>
///  播放音效
/// </summary>
/// <param name="Name"></param>
    public void PlayEffect(string Name)
    {
        string path = ResouceDir + Name;
        AudioClip clip = Resources.Load<AudioClip>(path);
        if (clip!=null)
        {
            m_effect.PlayOneShot(clip);
        }
    }
}
