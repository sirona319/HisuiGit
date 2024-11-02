using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryScr : EnemyBase
{


    //[NonSerialized] public float moveRangeXZ = 3;

    //public Transform[] movePoints;

    //public Transform front;
    //[NonSerialized] public int firstTargetPoints = 0;

    void Start()
    {
        base.StartInit();
        base.Init();



        stateController.Initialize((int)JerryCtr.State.Jerry_Wait);
    }

    void Update()
    {
        AttackTimeUpdate();

        stateController.UpdateSequence();
    }


    void AttackTimeUpdate()
    {
        if (!IsAttack) return;

        enemyData.AtkInterval -= Time.deltaTime;

        //if(enemyData.AtkInterval<=0)

    }



    public int JerryReturnStateType(int stateType)
    {
        if (IsMove)
            return (int)JerryCtr.State.Jerry_Move;
        else if(enemyData.AtkInterval <= 0)
            return (int)JerryCtr.State.Jerry_Attack;
        else
            return (int)JerryCtr.State.Jerry_Wait;


        //if (enemyData.moveType == EnemyData.MoveType.random)
        //    return (int)JerryCtr.State.Jerry_Move;

        //if (enemyData.moveType == EnemyData.MoveType.random)
        //    return (int)BaseJerryCtr.State.BaseJerry_Move;
        //else if (enemyData.moveType == EnemyData.MoveType.point)
        //    return (int)BaseJerryCtr.State.BaseJerry_MovePoint;
        //else if (enemyData.moveType == EnemyData.MoveType.circle)
        //    return (int)BaseJerryCtr.State.BaseJerry_MoveCircle;

        return stateType;
    }


    //public int ReturnStateMoveTypeAttack(int stateType)
    //{
    //    if (enemyData.attackType == EnemyData.AttackType.normal)
    //        return (int)BaseJerryCtr.State.BaseJerry_Attack;

    //    //if (enemyData.attackType == EnemyData.AttackType.circle)
    //    //    return (int)BaseJerryCtr.State.BaseJerry_AttackCircle;
    //    //else if (enemyData.attackType == EnemyData.AttackType.five)
    //    //    return (int)BaseJerryCtr.State.BaseJerry_AttackFive;
    //    //else if (enemyData.attackType == EnemyData.AttackType.normal)
    //    //    return (int)BaseJerryCtr.State.BaseJerry_Attack;

    //    return stateType;
    //}
}
