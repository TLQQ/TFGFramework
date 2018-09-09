using System.Collections;
using System.Collections.Generic;
using UnityEngine;



///*****************
///  A  LeenYee Game
///*****************
public static class AppConst  {
    #region Event

    public const string E_ExitScene = "E_ExitScene";
    public const string E_EnterScene ="E_EnterScene";
    public const string E_StartUp = "E_StartUp";
    #endregion

    #region View

    public const string V_PlayerMove= "V_PlayerMove";

    #endregion
}

public enum EDirection
{
    None,Up,Down,Right,Left
}
