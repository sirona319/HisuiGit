using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static EnemyBase;
using static UnityEngine.GraphicsBuffer;


public class Jerry_Wait : StateChildBase
{
    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

    }

    public override void OnEnter()
    {
        stateTime = 0f;
    }

    public override void OnExit()
    {

    }

    public override int StateUpdate()
    {

        transform.rotation = MyLib.TargetRotation2D((transform.position + Vector3.up), transform, 5f);


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
