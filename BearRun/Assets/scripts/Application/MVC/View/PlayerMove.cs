using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



///*****************
///  A  LeenYee Game
///*****************
public class PlayerMove : View
{


    public float MoveSpeed = 20;
    private CharacterController m_cc;
    private EDirection m_Dir;
    private Vector3 DragStart;
    private bool activeInput;
    private int RoadIndex = 1;
    private int TargetRoadIndex = 1;
    private float MoveOffSet;
    private float moveSpeed=10;
    public override string Name
    {
        get { return AppConst.V_PlayerMove; }
    }
    public override void HandleEvent(string eName, object data)
    {

    }

    void Awake()
    {
        m_cc = GetComponent<CharacterController>();
    }

    void Update()
    {

    }

    void Start()
    {
        StartCoroutine(UpdateAction());
    }
    IEnumerator UpdateAction()
    {
        while (true)
        {
            m_cc.Move(Vector3.forward * MoveSpeed * Time.deltaTime);
           
            GetInputDirection();
            MoveControl();
            yield return 0;
        }
    }

    void MoveDirection(EDirection dir)
    {
        switch (dir)
        {
            case EDirection.Left:
                if (TargetRoadIndex> 0)
                {
                    TargetRoadIndex--;
                    MoveOffSet =-2;
                }
                break;
            case EDirection.Right:
                if (TargetRoadIndex<2)
                {
                    TargetRoadIndex++;
                    MoveOffSet=2;
                }
                break;
        }

        
    }

    void MoveControl()
    {
        if (TargetRoadIndex != RoadIndex)
        {
            float move = Mathf.Lerp(0, MoveOffSet, moveSpeed * Time.deltaTime);
            transform.position += new Vector3(move, 0, 0);
            MoveOffSet -= move;
            if (Mathf.Abs(MoveOffSet) < 0.05f)
            {
                MoveOffSet = 0;
                RoadIndex = TargetRoadIndex;
                switch (RoadIndex)
                {
                    case 0:
                        transform.position =new Vector3(-2,transform.position.y,transform.position.z);
                        break;
                    case 1:
                        transform.position = new Vector3(0, transform.position.y, transform.position.z);
                        break;
                    case 2:
                        transform.position = new Vector3(2, transform.position.y, transform.position.z);
                        break;
                }
            }
        }
    }
    Vector3 offset;
    void GetInputDirection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            activeInput = true;
            DragStart = Input.mousePosition;
        }
        if (Input.GetMouseButton(0) && activeInput)
        {
            offset = Input.mousePosition - DragStart;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (Mathf.Abs(offset.x) > 50 || Mathf.Abs(offset.y) > 50)
            {
                if (Mathf.Abs(offset.x) > Mathf.Abs(offset.y))
                {
                    if (offset.x > 0)
                    {
                        MoveDirection(EDirection.Right);
                    }
                    else
                    {
                        MoveDirection(EDirection.Left);
                    }
                }
                else
                {
                    if (offset.y > 0)
                    {
                        MoveDirection(EDirection.Up);
                    }
                    else
                    {
                        MoveDirection(EDirection.Down);
                    }
                }
            }
            else
            {
                MoveDirection(EDirection.None);
            }
        }
    }

}
