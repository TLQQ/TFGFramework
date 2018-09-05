using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///*****************
///  A  LeenYee Game
///*****************
public class SubPool
{
    /// <summary>
    /// 集合
    /// </summary>
    private List<GameObject> m_objects = new List<GameObject>();
    /// <summary>
    /// 预制体
    /// </summary>
    private GameObject m_prefab;
    /// <summary>
    /// 名字
    /// </summary>
    public string Name
    {
        get { return m_prefab.name; }
    }
    /// <summary>
    /// 父物体的位置
    /// </summary>
    private Transform m_parent;

    public SubPool(Transform parent,GameObject go)
    {
        m_prefab = go;
        m_parent = parent;
    }
    /// <summary>
    /// 取出物体
    /// </summary>
    /// <returns></returns>
    public GameObject Spawn()
    {
        GameObject go = null;
        foreach (var obj in m_objects)
        {
            if (!obj.activeSelf)
            {
                go = obj;
            }
        }

        if (go==null)
        {
            go = GameObject.Instantiate<GameObject>(m_prefab);
            go.transform.parent = m_parent;
            m_objects.Add(go);
        }
        go.SetActive(true);
        go.SendMessage("OnSpawn",SendMessageOptions.DontRequireReceiver);
        return go;
    }
    /// <summary>
    /// 回收物体
    /// </summary>
    /// <param name="go"></param>
    public void UnSpawn(GameObject go)
    {
        if (m_objects.Contains(go))
        {
            go.SendMessage("OnUnSpawn",SendMessageOptions.DontRequireReceiver);
            go.SetActive(false);
        }
    }
    /// <summary>
    /// 回收全部
    /// </summary>
    public void UnSpawnAll()
    {
        foreach (var obj in m_objects)
        {
            if (obj.activeSelf)
            {
                UnSpawn(obj);
            }
        }
    }
    /// <summary>
    /// 判断是否包含go
    /// </summary>
    /// <param name="go"></param>
    /// <returns></returns>
    public bool Contain(GameObject go)
    {
        return m_objects.Contains(go);
    }
}
