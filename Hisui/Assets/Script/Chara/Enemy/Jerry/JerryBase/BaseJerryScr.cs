using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseJerryScr : EnemyBase
{


    //[NonSerialized] public float moveRandXZ = 3;

    //public Transform[] movePoints;
    //[NonSerialized] public int firstTargetPoints = 0;

    //void Start()
    //{
    //    base.Init();

    //    basePosition = transform.position;

    //    stateController.Initialize((int)BaseJerryCtr.State.BaseJerry_Wait);
    //}

    //void Update()
    //{
    //    stateController.UpdateSequence();
    //}








    public int JerryBaseReturnStateType(int stateType)
    {
        //É_ÉÅÅ[ÉW

        //if (enemyData.moveType == EnemyData.MoveType.RandomMove)
        //    return (int)BaseJerryCtr.State.BaseJerry_Move;

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
