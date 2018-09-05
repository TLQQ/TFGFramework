using System.Collections;
using System.Collections.Generic;
using UnityEngine;



///*****************
///  A  LeenYee Game
///*****************
public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour

{

    private static T m_instance;

    public static T Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType(typeof(T)) as T;
            }
            if (m_instance == null)
            {
                m_instance = new GameObject("MonoSingletonOf" + typeof(T).ToString(), typeof(T)).GetComponent<T>();
            }
            return m_instance;
        }

        set
        {
            m_instance = value;
        }
    }

}

