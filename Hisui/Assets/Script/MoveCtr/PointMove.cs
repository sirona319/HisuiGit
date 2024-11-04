using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


public class PointMove : BaseMove
{
    //Transform[] moveTrans;
    //Transform[] moveTrans;
    int targetNo = 0;
    const float ENDMOVELEN = 0.5f;

    //bool IsPoint = false;

    public override void Initialize()
    {
        base.Initialize();

        //targetNo = eBase.firstTargetPoints;

        //targetTrans = GetComponent<EnemyBase>().movePointsDatas;


        if (targets.Length <= 0)
            throw new System.Exception(transform.name + "PointMoveムーブポイント未設定");
    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {
        if (!IsMove)
            return;

        const float speed = 6f;
        m_rb.MovePosition(m_rb.position + transform.up * speed * Time.deltaTime);




        transform.rotation = MyLib.TargetRotation2D(targets[targetNo].position, transform);



        float len = Vector3.Distance(transform.position, targets[targetNo].position);
        if (len < ENDMOVELEN)
        {
            //if (GetComponent<BaseJerryScr>().enemyData.FirstTargetPlayer)
            //     return GetComponent<BaseJerryScr>().ReturnStateMoveType(StateType);

                            IsMove = false;

            targetNo++;
            if (targetNo > targets.Length - 1)
            {
                //ここに処理を追加できるようにしたい
                //IsPoint = true;


                targetNo = 0;
            }
            //GetComponent<JerryScr>().IsMove = false;
            //return StateType;
        }


    }

}
