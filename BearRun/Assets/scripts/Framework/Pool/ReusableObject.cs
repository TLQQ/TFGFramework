using System.Collections;
using System.Collections.Generic;
using UnityEngine;



///*****************
///  A  LeenYee Game
///*****************
public abstract class ReusableObject : MonoBehaviour, IReusable
{
    public abstract void Spawn();

    public abstract void UnSpawn();
}
