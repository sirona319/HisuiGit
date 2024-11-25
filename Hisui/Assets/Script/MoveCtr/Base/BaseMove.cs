using System;
using System.Collections;
using UnityEngine;

public abstract class BaseMove : MonoBehaviour
{

    public enum MoveType
    {
        RandomMove,
        PointMove,
        CircleMove,

        PointFloatMove,
        PointCircleMove,

        FloatVectorMove,

        //randomApoint,

    }

    protected Rigidbody2D m_rb;
    //void SetRb2D(Rigidbody2D rb2)
    //{
    //    m_rb = rb2;
    //}

    public bool IsKeepMove = false;//動き続ける移動

    public virtual void Initialize(Rigidbody2D rb)
    {
        m_rb = rb;
    }

    public abstract void MoveEnter();

    public abstract void MoveUpdate();

}
