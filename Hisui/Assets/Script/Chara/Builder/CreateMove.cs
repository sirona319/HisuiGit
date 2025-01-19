using DG.Tweening;
using System;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;
using static BaseMagazine;
using static BaseMove;
using static UnityEngine.GraphicsBuffer;

public class CreateMove : MonoBehaviour
{
    float speed = 7;

    public void MoveCreateInit(EnemyData eData, Transform[] movePoint, GameObject go)
    {
        var eBase = go.GetComponent<EnemyBase>();

        //baseMove初期化　移動クラスに持っていく？
        for (int i = 0; i < (int)eData.moveType.Length; i++)
        {
            AddSetParamComponent(eData.moveType[i], movePoint, go);
        }

    }

    void AddSetParamComponent(MoveType moveType, Transform[] movePoint,GameObject go)
    {

        /*
        var eBase = go.GetComponent<EnemyBase>();

        //switch文へ
        if (moveType == MoveType.CarveMoveL)
        {
            InitFunc(MoveClassName.CarveMove, go);

            go.GetComponent<CarveMove>().SetCarveVal(15f);

            CreateCarveMove(go.GetComponent<CarveMove>(), movePoint[0].position, go);

            //var dir = movePoint[0].position - go.transform.position;
            //go.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir.normalized);
            //go.GetComponent<EnemyBase>().SetIsAttack();
        }
        else if (moveType == MoveType.CarveMoveR)
        {
            InitFunc(MoveClassName.CarveMove, go);

            go.GetComponent<CarveMove>().SetCarveVal(-15f);

            CreateCarveMove(go.GetComponent<CarveMove>(), movePoint[0].position, go);

        }
        else if(moveType == MoveType.PointFloatMove)
        {
            InitFunc(MoveType.PointFloatMove, go);

            CreatePointFloatMove(go.GetComponent<PointFloatMove>(), movePoint, go);
        }
        else if(moveType == MoveType.FloatVectorMoveUp)
        {
            InitFunc(MoveClassName.FloatVectorMove, go);

            go.GetComponent<FloatVectorMove>().addSinTime=Time.deltaTime;

            CreateFloatVectorMove(go.GetComponent<FloatVectorMove>(), movePoint[0].position, go);

        }
        else if (moveType == MoveType.FloatVectorMoveDown)
        {
            InitFunc(MoveClassName.FloatVectorMove, go);

            go.GetComponent<FloatVectorMove>().addSinTime = -Time.deltaTime;

            CreateFloatVectorMove(go.GetComponent<FloatVectorMove>(), movePoint[0].position, go);

        }
        else if( moveType == MoveType.PointCircleMove)
        {
            InitFunc(MoveType.PointCircleMove, go);

            CreatePointCircleMove(go.GetComponent<PointCircleMove>(), movePoint, go);

        }
        */

    }

    public bool CreatePointFloatMove(PointFloatMove pFloatMove,Transform[] movePoint,GameObject go)
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

        pFloatMove.speed = speed;

        return true;
    }

    public bool CreateFloatVectorMove(FloatVectorMove fVectorMove,Vector3 movePos, GameObject go,float sin)
    {
        if (fVectorMove == null) return false;
        const float moveVal = 0.02f;
        //float sinVal = sin;


        var dir = movePos - go.transform.position;

        go.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir.normalized);

        //見た目だけの回転
        var spriteTrans = go.transform.Find("Sprite").gameObject.transform;
        spriteTrans.rotation = Quaternion.FromToRotation(Vector3.up, transform.up);


        fVectorMove.floatVector = dir.normalized * moveVal;

        fVectorMove.addSinVec = go.transform.right * sin;

        go.GetComponent<EnemyBase>().SetIsAttack();


        return true;
    }

    public bool CreatePointCircleMove(PointCircleMove pCircleMove, Transform[] movePoint, GameObject go)
    {
        if (pCircleMove == null) return false;
        //const float pCircleEndLen = 2f;

        pCircleMove.IsPointMoveEnd.Skip(1).Subscribe(pointBool => go.GetComponent<EnemyBase>().SetEndMoveKeep());

        pCircleMove.TargetSet(movePoint);
        //pCircleMove.SetMoveEndLength(pCircleEndLen);

        pCircleMove.speed = speed;

        return true;
    }

    public bool CreateCarveMove(CarveMove cMove, Vector3 movePos, GameObject go)
    {
        if (cMove == null) return false;

        var dir = movePos - go.transform.position;

        go.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir.normalized);

        go.GetComponent<EnemyBase>().SetIsAttack();
        return true;
    }


    public void InitFunc(MoveType moveType, GameObject go)
    {
        var eBase = go.GetComponent<EnemyBase>();

        Type typeClass = Type.GetType(moveType.ToString());
        eBase.baseMove.Add((BaseMove)go.AddComponent(typeClass));
        go.GetComponent<BaseMove>().Initialize(go.GetComponent<Rigidbody2D>());
    }

    public void InitFunc(MoveClassName moveType, GameObject go)
    {
        var eBase = go.GetComponent<EnemyBase>();

        Type typeClass = Type.GetType(moveType.ToString());
        eBase.baseMove.Add((BaseMove)go.AddComponent(typeClass));
        go.GetComponent<BaseMove>().Initialize(go.GetComponent<Rigidbody2D>());
    }

    public void AddFunc(MoveType moveType, GameObject go)
    {
        var eBase = go.GetComponent<EnemyBase>();

        Type typeClass = Type.GetType(moveType.ToString());
        eBase.baseMove.Add((BaseMove)go.AddComponent(typeClass));
        //go.GetComponent<BaseMove>().Initialize(go.GetComponent<Rigidbody2D>());
    }
}
