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

    }

    public override void OnEnter()
    {

        stateTime = 0f;

    }

    public override void OnExit()
    {
        // Debug.Log("�U���I��");
    }

    public override int StateUpdate()
    {

        stateTime += Time.deltaTime;

        if (GetComponent<JerryScr>().IsDamage)
            return GetComponent<JerryScr>().ReturnStateTypeDamage();



        //�}�K�W���̍X�V
        GetComponent<JerryScr>().AttackMagazineUpdateAll();



        if (stateTime > GetComponent<JerryScr>().enemyData.AtkInterval)
        {
            GetComponent<JerryScr>().IsAttack = false;

            return GetComponent<JerryScr>().JerryReturnStateType(StateType);
        }
          

        

        return StateType;
    }

}
