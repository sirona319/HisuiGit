using NUnit.Framework;
using System.Collections.Generic;
using UniRx;
using UnityEngine;


public class PointMove : BaseMove
{

    int targetNo = 0;
    public float endLength = 0.7f;

    public float speed = 40f;

    public Transform[] targets;

    //public bool IsLoop = false;
    //public bool IsPointMoveEnd = false;
    public ReactiveProperty<bool> IsPointMoveEnd = new ReactiveProperty<bool>(false);
    //リセットできるようにする？　移動後停止してまた使えるようにするため

    public void TargetSet(Transform[] t)
    {
        targets = t;

        if (targets.Length <= 0)
            throw new System.Exception(transform.name + "PointMoveムーブポイント未設定");
    }

    //public bool GetMoveEnd()
    //{
    //    return IsPointMoveEnd.Value;
    //}

    public void SetMoveEndLength(float len)
    {
        endLength = len;
    }

    public override void Initialize(Rigidbody2D rb)
    {
        m_rb = rb;
        //base.Initialize();
        
    }

    public override void MoveEnter()
    {


    }

    public override void MoveUpdate()
    {
        if (IsPointMoveEnd.Value) return;

        PointUpdate();

        m_rb.MovePosition(m_rb.position + (Vector2)transform.up * speed * Time.deltaTime);

        transform.rotation = MyLib.TargetRotation2D(targets[targetNo].position, transform);
    }

    void PointUpdate()
    {
        float len = Vector3.Distance(transform.position, targets[targetNo].position);

        //重力テスト
        //if(len<2f&&speed>4f)
        //{
        //    speed *= (len * 0.4f);
        //}

        if (len < endLength)
        {

            targetNo++;
            if (targetNo > targets.Length - 1)
            {
                if (!IsKeepMove)
                    IsPointMoveEnd.Value = true;

                targetNo = 0;
            }

        }
        
    }

}
