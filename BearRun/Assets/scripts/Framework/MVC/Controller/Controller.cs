﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



///*****************
///  A  LeenYee Game
///*****************
public abstract class Controller : MonoBehaviour
{
    /// <summary>
    /// 执行事件
    /// </summary>
    /// <param name="data"></param>
    public abstract void Excute(object data);

    /// <summary>
    /// 获取模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    protected T GetModel<T>() where T : Model
    {
        return MVC.GetModel<T>() as T;
    }
    /// <summary>
    /// 获取视图
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    protected T GetView<T>() where T : View
    {
        return MVC.GetView<T>() as T;
    }
    /// <summary>
    /// 注册模型
    /// </summary>
    /// <param name="model"></param>
    protected void RegisterModel(Model model)
    {
        MVC.RegisterModel(model);
    }
    /// <summary>
    /// 注册视图
    /// </summary>
    /// <param name="view"></param>
    protected void RegisterView(View view)
    {
        MVC.RegisterView(view);
    }
    /// <summary>
    /// 注册控制器
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="controllerType"></param>
    protected void RegisterController(string eventName,Type controllerType)
    {
        MVC.RegisterController(eventName,controllerType);
    }
}
