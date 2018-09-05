using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



///*****************
///  A  LeenYee Game
///*****************
public static class MVC
{
    /// <summary>
    /// 
    /// </summary>
    public static Dictionary<string, Model> Models = new Dictionary<string, Model>();

    public static Dictionary<string, View> Views = new Dictionary<string, View>();

    public static Dictionary<string, Type> CommandMap = new Dictionary<string, Type>();

    public static void RegisterView(View view)
    {
        view.RegisterAttentionEvent();
        Views[view.name] = view;
    }

    public static void RegisterModel(Model model)
    {
        Models[model.Name] = model;
    }

    public static void RegisterController(string EventName,Type controllerType)
    {
        CommandMap[EventName] = controllerType;
    }
    /// <summary>
    /// 获取model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetModel<T>()where  T:Model
    {
        foreach (var model in Models.Values)
        {
            if (model is T)
            {
                return model as T;
            }
        }

        return null;
    }
    /// <summary>
    /// 获取view
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetView<T>() where T : View
    {
        foreach (var view in Views.Values)
        {
            if (view is T)
            {
                return view as T;
            }
        }
        return null;
    }

    public static void SendEvent(string EventName,object data=null)
    {
        if (CommandMap.ContainsKey(EventName))
        {
            Type t = CommandMap[EventName];
            Controller c=Activator.CreateInstance(t) as Controller;
            c.Excute(data);
        }
    }

}
