using DG.Tweening;
using System;
using UniRx;
using UnityEngine;

public class CreateMove : MonoBehaviour
{
    public void MoveCreateInit(EnemyData eData, Transform[] movePoint, GameObject enemy)
    {
        var eBase = enemy.GetComponent<EnemyBase>();

        //baseMove初期化　移動クラスに持っていく？
        for (int i = 0; i < (int)eData.moveType.Length; i++)
        {
            Type typeClass = Type.GetType(eData.moveType[i].ToString());

            if (typeClass != null)
            {
                eBase.baseMove.Add((BaseMove)enemy.AddComponent(typeClass));
            }

        }


        foreach (var move in eBase.baseMove)
        {
            //初期化
            move.Initialize(enemy.GetComponent<Rigidbody2D>());


            CreatePointFloatMove(move as PointFloatMove, movePoint, enemy, eData);
            //if (CreatePointFloatMove(move as PointFloatMove, movePoint, enemy, eData))
            // break;

            CreateFloatVectorMove(move as FloatVectorMove, movePoint[0].position, enemy);
            //if (CreateFloatVectorMove(move as FloatVectorMove, movePoint[0].position, enemy))
            //break;

            CreatePointCircleMove(move as PointCircleMove, movePoint, enemy, eData);
            //if (CreatePointCircleMove(move as PointCircleMove, movePoint, enemy, eData))
            //break;

        }

    }

    bool CreatePointFloatMove(PointFloatMove pFloatMove,Transform[] movePoint,GameObject go,EnemyData eData)
    {
        if(pFloatMove==null) return false;

        //pMove.IsPointMoveEnd.Skip(1).Subscribe(count => Debug.Log(count));
        //関数がここで一度呼び出されるpMove.IsPointMoveEnd.Skip(1)初回をスキップする
        pFloatMove.IsPointMoveEnd.Skip(1).Subscribe(pointBool =>
        {
            go.GetComponent<EnemyBase>().SetEndMoveKeep();
            go.GetComponent<JerryScr>().SetEndTrail();
        }
        );

        pFloatMove.TargetSet(movePoint);

        pFloatMove.speed = eData.Speed;
        //pFloatMove.SetMoveEndLength(eData.PointEndLength);

        return true;
    }

    bool CreateFloatVectorMove(FloatVectorMove fVectorMove,Vector3 movePos, GameObject go)
    {
        if (fVectorMove == null) return false;
        const float moveVal = 0.02f;
        const float sinVal = 0.04f;


        var dir = movePos - go.transform.position;

        go.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir.normalized);



        fVectorMove.floatVector = dir.normalized * moveVal;

        fVectorMove.addSinVec = go.transform.right * sinVal;

        go.GetComponent<EnemyBase>().SetIsAttack();

        return true;
    }

    const float cPointEndLen = 2f;
    bool CreatePointCircleMove(PointCircleMove pCircleMove, Transform[] movePoint, GameObject go, EnemyData eData)
    {
        if (pCircleMove == null) return false;

        //pMove.IsPointMoveEnd.Skip(1).Subscribe(count => Debug.Log(count));
        //関数がここで一度呼び出されるpMove.IsPointMoveEnd.Skip(1)初回をスキップする
        pCircleMove.IsPointMoveEnd.Skip(1).Subscribe(pointBool => go.GetComponent<EnemyBase>().SetEndMoveKeep());

        pCircleMove.TargetSet(movePoint);
        pCircleMove.SetMoveEndLength(cPointEndLen);

        pCircleMove.speed = eData.Speed;

        return true;
    }
}
