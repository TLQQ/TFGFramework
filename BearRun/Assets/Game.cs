using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


///*****************
///  A  LeenYee Game
///*****************

[RequireComponent(typeof(SoundManager))]
[RequireComponent(typeof(ObjectPool))]
[RequireComponent(typeof(StaticData))]
public class Game : MonoSingleton<Game>
{

    [HideInInspector]
    public ObjectPool objectPool;
    [HideInInspector]
    public SoundManager Sound;
    [HideInInspector]
    public StaticData Data;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        objectPool = ObjectPool.Instance;
        Sound = SoundManager.Instance;
        Data = StaticData.Instance;
        //todo gameStart
        //注册所有的controller
        RegisterController(AppConst.E_StartUp, typeof(StartUpController));
        //todo
        LoadLevel(4);
    }

    public void LoadLevel(int level)
    {
        //发送退出场景事件
        SceneArgs e = new SceneArgs() { SceneIndex = SceneManager.GetActiveScene().buildIndex };
        SendEvent(AppConst.E_ExitScene, e);
        //加载新的场景事件
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }

    void OnLevelWasLoaded(int level)
    {
        Debug.Log("加载完成");
        SceneArgs e = new SceneArgs() { SceneIndex = level };
        SendEvent(AppConst.E_EnterScene, e);
    }


    /// <summary>
    /// 发送事件
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="data"></param>
    void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }

    void RegisterController(string eventName, Type controllerType)
    {
        MVC.RegisterController(eventName, controllerType);
    }
}
