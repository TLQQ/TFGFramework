using System.Collections;
using System.Collections.Generic;
using UnityEngine;



///*****************
///  A  LeenYee Game
///*****************
public class RoadChange : MonoBehaviour
{

     GameObject roadNow;

     GameObject roadNext;

     GameObject Parent;
    Vector3 RoadOffset=new Vector3(0,0,160);

	void Start () {
	    if (Parent==null)
	    {
	        Parent=new GameObject("Road");
            Parent.transform.position=Vector3.zero;
	    }
	    roadNow = Game.Instance.objectPool.Spawn("Pattern_" + Random.Range(1, 5), Parent.transform);
        roadNow.transform.position=Vector3.zero;
        roadNext = Game.Instance.objectPool.Spawn("Pattern_" + Random.Range(1, 5), Parent.transform);
	    roadNext.transform.position = roadNow.transform.position+ RoadOffset;
	}
	

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag==Tag.Road)
        {
            Game.Instance.objectPool.UnSpawn(other.gameObject);
            SpawnNewRoad();
        }
    }

    void SpawnNewRoad()
    {
        roadNow = roadNext;
        roadNext = Game.Instance.objectPool.Spawn("Pattern_" + Random.Range(1, 5), Parent.transform);
        roadNext.transform.position = roadNow.transform.position+RoadOffset;
    }
}
