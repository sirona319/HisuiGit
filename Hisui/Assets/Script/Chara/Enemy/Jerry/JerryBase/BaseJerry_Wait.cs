using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static EnemyBase;


public class BaseJerry_Wait : StateChildBase
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
        {
            const int DAMAGE = 2;
            return DAMAGE;
        }

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

        return GetComponent<EnemyBase>().ReturnStateMoveType(StateType);


        //return StateType;
    }

}
