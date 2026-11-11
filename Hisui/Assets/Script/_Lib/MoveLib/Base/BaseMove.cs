using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMove : MonoBehaviour
{
    //[SerializeField]public List<Vector3> childsposs;
    public enum MoveType
    {
        //RandomMove,
        //PointMove,
        //CircleMove,

        PointFloatMove,
        PointCircleMove,

        FloatVectorMoveUp,
        FloatVectorMoveDown,

        FloatVectorMoveUpMini,
        FloatVectorMoveDownMini,

        CarveMoveR,
        CarveMoveL,

        DirectionMove
        //randomApoint,

    }

    public enum MoveClassName
    {
        CarveMove,
        FloatVectorMove,
    }

    public virtual void Initialize()
    {
        //if(GetComponent<Rigidbody2D>()!=null)
        //    rb2 = GetComponent<Rigidbody2D>();

        //if (GetComponent<Rigidbody>() != null)
        //    rb3 = GetComponent<Rigidbody>();
    }

    public virtual void MoveEnter() { }
    public virtual void MoveExit()
    {

    }


    public virtual void MoveUpdate() { }
}
