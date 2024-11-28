using DG.Tweening;
using System;
using UniRx;
using UnityEngine;
using static BaseMagazine;
using static BaseMove;

public class CreateMove : MonoBehaviour
{
    public void MoveCreateInit(EnemyData eData, Transform[] movePoint, GameObject go)
    {
        var eBase = go.GetComponent<EnemyBase>();

        //baseMove初期化　移動クラスに持っていく？
        for (int i = 0; i < (int)eData.moveType.Length; i++)
        {

            AddSetParamComponent(eData.moveType[i], go);
            //Type typeClass = Type.GetType(eData.moveType[i].ToString());

            //if (typeClass != null)
            //{
            //    eBase.baseMove.Add((BaseMove)enemy.AddComponent(typeClass));
            //}

        }


        foreach (var move in eBase.baseMove)
        {
            //初期化
            //move.Initialize(go.GetComponent<Rigidbody2D>());


            CreatePointFloatMove(move as PointFloatMove, movePoint, go, eData);
            //if (CreatePointFloatMove(move as PointFloatMove, movePoint, enemy, eData))
            // break;

            CreateFloatVectorMove(move as FloatVectorMove, movePoint[0].position, go);
            //if (CreateFloatVectorMove(move as FloatVectorMove, movePoint[0].position, enemy))
            //break;

            CreatePointCircleMove(move as PointCircleMove, movePoint, go, eData);
            //if (CreatePointCircleMove(move as PointCircleMove, movePoint, enemy, eData))
            //break;

            CreateCarveMove(move as CarveMove, movePoint[0].position, go, eData);

        }

    }

    void AddSetParamComponent(MoveType moveType, GameObject go)
    {
        var eBase = go.GetComponent<EnemyBase>();


        if (moveType == MoveType.CarveMoveL)
        {
            Type carveL = Type.GetType(MoveClassName.CarveMove.ToString());
            eBase.baseMove.Add((BaseMove)go.AddComponent(carveL));

            go.GetComponent<BaseMove>().Initialize(go.GetComponent<Rigidbody2D>());
            go.GetComponent<CarveMove>().SetCarveVal(15f);
            return;
        }
        if (moveType == MoveType.CarveMoveR)
        {
            Type carveR = Type.GetType(MoveClassName.CarveMove.ToString());
            eBase.baseMove.Add((BaseMove)go.AddComponent(carveR));

            go.GetComponent<BaseMove>().Initialize(go.GetComponent<Rigidbody2D>());
            go.GetComponent<CarveMove>().SetCarveVal(-15f);
            return;
        }

        Type typeClass = Type.GetType(moveType.ToString());

        if (typeClass != null)
        {
            eBase.baseMove.Add((BaseMove)go.AddComponent(typeClass));

            go.GetComponent<BaseMove>().Initialize(go.GetComponent<Rigidbody2D>());
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

    const float pCircleEndLen = 2f;
    bool CreatePointCircleMove(PointCircleMove pCircleMove, Transform[] movePoint, GameObject go, EnemyData eData)
    {
        if (pCircleMove == null) return false;

        //pMove.IsPointMoveEnd.Skip(1).Subscribe(count => Debug.Log(count));
        //関数がここで一度呼び出されるpMove.IsPointMoveEnd.Skip(1)初回をスキップする
        pCircleMove.IsPointMoveEnd.Skip(1).Subscribe(pointBool => go.GetComponent<EnemyBase>().SetEndMoveKeep());

        pCircleMove.TargetSet(movePoint);
        pCircleMove.SetMoveEndLength(pCircleEndLen);

        pCircleMove.speed = eData.Speed;

        return true;
    }

    bool CreateCarveMove(CarveMove cMove, Vector3 movePos, GameObject go, EnemyData eData)
    {
        if (cMove == null) return false;
        //const float moveVal = 0.02f;
        //pMove.IsPointMoveEnd.Skip(1).Subscribe(count => Debug.Log(count));
        //関数がここで一度呼び出されるpMove.IsPointMoveEnd.Skip(1)初回をスキップする
        //pCircleMove.IsPointMoveEnd.Skip(1).Subscribe(pointBool => go.GetComponent<EnemyBase>().SetEndMoveKeep());



        var dir = movePos - go.transform.position;
        //cMove.floatVector = dir.normalized;
        //go.transform.rotation = Quaternion.LookRotation(Vector3.up);


        go.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir.normalized);

        //cMove.SetCarveVal(15f);
        //pCircleMove.SetMoveEndLength(cPointEndLen);

        //pCircleMove.speed = eData.Speed;
        go.GetComponent<EnemyBase>().SetIsAttack();
        return true;
    }

}
