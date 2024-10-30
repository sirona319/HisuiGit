using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static EnemyBase;


public class Jerry_Wait : StateChildBase
{
    public override void OnEnter()
    {
        stateTime = 0f;
    }

    public override void OnExit()
    {

    }

    public override int StateUpdate()
    {
        //return (int)SlimeCtr.State.Slime_CircleAttack;

        //var randValue = Random.Range(0,3);

        if (GetComponent<EnemyBase>().IsDamage)
            GetComponent<EnemyBase>().ReturnStateTypeDamage();

        stateTime += Time.deltaTime;


        //return GetComponent<EnemyBase>().ReturnStateMoveTypeAttack(StateType);


        //if (GetComponent<EnemyBase>().enemyData.attackType == EnemyData.AttackType.circle)
        //    return (int)SlimeCtr.State.Slime_CircleAttack;
        //else if (GetComponent<EnemyBase>().enemyData.attackType == EnemyData.AttackType.five)
        //    return (int)SlimeCtr.State.Slime_FiveAttack;
        //else
        //    return (int)SlimeCtr.State.Slime_Attack;

        //if (GetComponent<EnemyBase>().moveType == EnemyBase.MoveType.random)
        //    return (int)SlimeCtr.State.Slime_CircleAttack;
        //else if (GetComponent<EnemyBase>().moveType == EnemyBase.MoveType.point)
        //    return (int)SlimeCtr.State.Slime_MovePoint;//　ポイントムーブ

        return GetComponent<JerryScr>().JerryReturnStateType(StateType);


        //return StateType;
    }

}
