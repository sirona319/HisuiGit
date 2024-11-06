using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Jerry_Attack : StateChildBase
{

    public override void Initialize(int stateType)
    {

        base.Initialize(stateType);
        GetComponent<JerryScr>().AtkInterval = GetComponent<JerryScr>().enemyData.AtkIntervalMax;
    }

    public override void OnEnter()
    {

        stateTime = 0f;
        foreach (var magazine in GetComponent<JerryScr>().baseMagazine)
            magazine.MagazineEnter();
    }

    public override void OnExit()
    {
        // Debug.Log("攻撃終了");
    }

    public override int StateUpdate()
    {

        stateTime += Time.deltaTime;

        if (GetComponent<EnemyBase>().IsDamage)
            return GetComponent<JerryScr>().ReturnStateTypeDamage();



        //マガジンの更新
        GetComponent<JerryScr>().AttackMagazineUpdateAll();



        if (stateTime > GetComponent<JerryScr>().baseMagazine[0].bulletShotTime)
        {
            GetComponent<JerryScr>().AtkInterval = GetComponent<JerryScr>().enemyData.AtkIntervalMax;
            //GetComponent<JerryScr>().IsAttack = false;
            return GetComponent<JerryScr>().JerryReturnStateType(StateType);
        }




        return (int)StateType;
    }

}
