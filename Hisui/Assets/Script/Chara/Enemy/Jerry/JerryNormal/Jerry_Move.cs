using DG.Tweening;
using System;
using UnityEngine;
using static EnemyData;


public class Jerry_Move : StateChildBase
{
    //[HideInInspector]
    //public bool IsKeepMove = false;
    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

        //foreach (var move in GetComponent<JerryScr>().baseMove)
        //{
        //    //move.Initialize();

        //    IsKeepMove = move.IsKeepMove;


        //    //var pMove = move as PointMove;
        //    //var movePointComp = move.GetComponent<IPointMove>();

        //    // の処理が必須
        //    ///if (movePointComp != null)
        //    //{

        //    //pMove.IsPointMoveEnd.Subscribe(x => StateUpdate());
        //}



            //別クラスでフロートムーブ設定をする

        
        //pointMove = GetComponent<JerryScr>().MoveTypeSelect(MoveType.PointMove) as PointMove;
        //pointMove.IsLoop = false;
        //pointMove.TargetSet(GetComponent<EnemyBase>().movePointsDatas);

        //pointMove.endLength = 3f;


        //GetComponent<JerryScr>().baseMove.move

    }

    public override void OnEnter()
    {
        stateTime = 0f;

        foreach (var move in GetComponent<JerryScr>().baseMove)
            move.MoveEnter();

    }

    public override void OnExit()
    {
        //stateTime = 0;
    }

    public override int StateUpdate()
    {
        stateTime += Time.deltaTime;
        //moveSaveTime += Time.deltaTime;

        if (GetComponent<EnemyBase>().IsDamage)
            return GetComponent<JerryScr>().ReturnStateTypeDamage();

        //bool IsPointMoveEnd = false;
        //移動の更新
        foreach (var move in GetComponent<JerryScr>().baseMove)
        {
            move.MoveUpdate();

            //var movePointComp = move.GetComponent<IPointMove>();

            //if (movePointComp != null)
            //    IsPointMoveEnd = movePointComp.GetMoveEnd();

        }


        //コルーチンで登録するようにする?
        //if(pointMove.IsPointMoveEnd)

        //if (IsCircleMove && IsPointMoveEnd)
        //{
        //    GetComponent<JerryScr>().IsAttack = true;
        //    return (int)GetComponent<JerryScr>().JerryReturnStateType(StateType);
        //}

        if (GetComponent<JerryScr>().AtkInterval <= 0|| !GetComponent<JerryScr>().IsMove)
        {
            //GetComponent<JerryScr>().IsAttack = true;

            //if(!IsKeepMove)
            //GetComponent<JerryScr>().IsMove = false;

            return (int)GetComponent<JerryScr>().JerryReturnStateType(StateType);
        }
            


        return StateType;

    }
}
