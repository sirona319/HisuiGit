using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryScr : EnemyBase
{

    //public Transform front;

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

        AtkInterval -= Time.deltaTime;

        //if(enemyData.AtkInterval<=0)

    }



    public int JerryReturnStateType(int stateType)
    {
        if (AtkInterval <= 0)
            return (int)JerryCtr.State.Jerry_Attack;
        else if (IsMove)
            return (int)JerryCtr.State.Jerry_Move;

        else
            return (int)JerryCtr.State.Jerry_Wait;

        //return stateType;
    }

}
