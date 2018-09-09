using System.Collections;
using System.Collections.Generic;
using UnityEngine;



///*****************
///  A  LeenYee Game
///*****************
public class CameraFollow : MonoBehaviour
{
    private Transform m_player;

    private Vector3 m_offset;

    private float speed = 20;

    void Awake()
    {
        m_player = GameObject.FindWithTag(Tag.Player).transform;
        m_offset = transform.position - m_player.position;
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    transform.position = Vector3.Lerp(transform.position, m_offset + m_player.position, speed * Time.deltaTime);
	}
}
