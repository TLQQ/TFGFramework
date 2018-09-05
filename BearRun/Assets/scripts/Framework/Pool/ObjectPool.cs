using System.Collections;
using System.Collections.Generic;
using UnityEngine;



///*****************
///  A  LeenYee Game
///*****************
public class ObjectPool : MonoSingleton<ObjectPool>
{
    /// <summary>
    /// 资源目录
    /// </summary>
    public string ResouceDir = "";

    private Dictionary<string, SubPool> m_pools = new Dictionary<string, SubPool>();
    /// <summary>
    /// 取出物体
    /// </summary>
    /// <param name="Name"></param>
    /// <returns></returns>
    public GameObject Spawn(string Name,Transform trans)
    {
        SubPool pool = null;
        if (m_pools.ContainsKey(Name))
        {
            RegisterNew(Name,trans);
        }

        pool = m_pools[Name];
        return pool.Spawn(); 
    }
    /// <summary>
    /// 回收
    /// </summary>
    /// <param name="go"></param>
    public void UnSpawn(GameObject go)
    {
        SubPool pool = null;
        foreach (var p in m_pools.Values)
        {
            if (p.Contain(go))
            {
                pool = p;
                break;
            }
        }
        pool.UnSpawn(go);
    }
    /// <summary>
    /// 回收所有
    /// </summary>
    public void UnSpawnAll()
    {
        foreach (var mPool in m_pools.Values)
        {
            mPool.UnSpawnAll();
        }
    }
 /// <summary>
 /// 
 /// </summary>
 /// <param name="Name">名字</param>
 /// <param name="trans">位置</param>
    void RegisterNew(string Name,Transform trans)
    {
        string path = ResouceDir + "/" + Name;
        GameObject go = Resources.Load<GameObject>(path);
        SubPool subPool = new SubPool(trans, go);
        m_pools.Add(subPool.Name,subPool);
    }
}
