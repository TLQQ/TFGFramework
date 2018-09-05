using System.Collections;
using System.Collections.Generic;
using UnityEngine;



///*****************
///  A  LeenYee Game
///*****************
public abstract  class Model : MonoBehaviour {
    /// <summary>
    /// 名字标识
    /// </summary>
    public abstract string Name { get; }

    protected void SendEvent(string eventName,object data=null)
    {
        MVC.SendEvent(eventName,data);
    }
}
