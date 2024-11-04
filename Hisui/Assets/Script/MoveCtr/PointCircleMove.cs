using System;
using UnityEngine;

public class PointCircleMove : BaseMove
{

    CircleMove circle;
    PointMove point;

    const float rotLength = 2f;
    public override void Initialize()
    {
        base.Initialize();

        point =gameObject.AddComponent<PointMove>();
        circle = gameObject.AddComponent<CircleMove>();

        circle.targets = targets;
        point.targets = targets;

        circle.Initialize();
        point.Initialize();
    }


    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {
        if (!point.IsMove)
        {
            //IsNotMoveAction(() =>
            //{
                circle.MoveUpdate();
                return;
            //});

            //return;
        }

        point.MoveUpdate();

        float len = Vector3.Distance(transform.position, circle.targetTrans.position);
        //if (!point.IsMove)
        //{
        if(len<=rotLength)
        {
            if(transform.tag=="Enemy")
            GetComponent<JerryScr>().IsAttack = true;

            point.IsMove = false;
            //Destroy(point);
            point.enabled = false;//ポイント移動を終了
            circle.MoveEnter();
        }

        //IsNotMoveAction(() =>
        //    {

        //    });
            //GetComponent<JerryScr>().IsAttack = true;
            ////IsMove = point.IsMove;
            //Destroy(point);
            ////point.enabled = false;//ポイント移動を終了
            //circle.MoveEnter();
        //}
    }

    //void IsNotMoveAction(Action action)
    //{
    //    if (point.IsMove) return;

    //    action?.Invoke();
    //}
 
}
