using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


public class PointMove : BaseMove
{
    Transform[] moveTrans;
    //Transform[] moveTrans;
    int targetNo = 0;
    const float ENDMOVELEN = 0.5f;

    //bool IsPoint = false;

    public override void Initialize()
    {
        base.Initialize();

        //targetNo = eBase.firstTargetPoints;

        moveTrans = GetComponent<EnemyBase>().movePointsDatas;


        if (moveTrans.Length <= 0)
            throw new System.Exception(GetComponent<EnemyBase>().findName + "ムーブポイント未設定");
    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {
        if (!IsMove)
            return;

        var moveSpd = GetComponent<EnemyBase>().enemyData.Speed;
        m_rb.MovePosition(m_rb.position + transform.up * moveSpd * Time.deltaTime);




        transform.rotation = MyLib.TargetRotation2D(moveTrans[targetNo].position, transform);



        float len = Vector3.Distance(transform.position, moveTrans[targetNo].position);
        if (len < ENDMOVELEN)
        {
            //if (GetComponent<BaseJerryScr>().enemyData.FirstTargetPlayer)
            //     return GetComponent<BaseJerryScr>().ReturnStateMoveType(StateType);

                            IsMove = false;

            targetNo++;
            if (targetNo > moveTrans.Length - 1)
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
