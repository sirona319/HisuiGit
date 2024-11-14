using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.GridBrushBase;

public class Jerry_Attack : StateChildBase
{

    public override void Initialize(int stateType)
    {

        base.Initialize(stateType);
        //GetComponent<EnemyBase>().AtkInterval = GetComponent<EnemyBase>().enemyData.AtkIntervalMax;

        //foreach (var magazine in GetComponent<EnemyBase>().baseMagazine)
        //{
        //    magazine.BulletLoad("prefab/Bullet/JerryBullet");

        //    magazine.SetPool(GetComponent<EnemyBase>().pool);
        //}
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


        foreach (var move in GetComponent<JerryScr>().baseMove)
        {
            if(move.IsKeepMove)
                move.MoveUpdate();
        }



        if (stateTime > GetComponent<JerryScr>().baseMagazine[0].shotTime)
        {
            GetComponent<JerryScr>().AtkInterval = GetComponent<JerryScr>().enemyData.AtkIntervalMax;
            return GetComponent<JerryScr>().JerryReturnStateType(StateType);
        }


        return (int)StateType;
    }

}
