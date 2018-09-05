using System.Collections;
using System.Collections.Generic;
using UnityEngine;



///*****************
///  A  LeenYee Game
///*****************
public abstract class View : MonoBehaviour {
    /// <summary>
    /// 名字标识
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// 事件关心列表
    /// </summary>
    [HideInInspector]
    public  List<string> AttentionList=new List<string>();


    public virtual void  RegisterAttentionEvent()
    {

    }
    public abstract void HandleEvent(string eName,object data);
 

    /// <summary>
    /// 发送事件
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="data"></param>
    protected void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }
    /// <summary>
    /// 获取模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    protected T GetModel<T>() where T : Model
    {
        return MVC.GetModel<T>()as T;
    }

}
