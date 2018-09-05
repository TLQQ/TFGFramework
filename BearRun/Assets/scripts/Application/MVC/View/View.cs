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

    [HideInInspector]
    public  List<string> AttentionList=new List<string>();

    public abstract void HandleEvent(string eName,object data);
 


    protected void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }

}
