using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryPointCircleCtr : StateControllerBase
{
    public enum State
    {
        JerryCircle_Wait,
        JerryCircle_Damage,
        JerryCircle_Dead,
        JerryCircle_Attack,
        JerryCircle_MovePoint,
        JerryCircle_MoveCircle,
        NumStates
    }

    public override void Initialize(int initializeStateType)
    {

        for (int i = 0; i < (int)State.NumStates; i++) //NumStatesを使う場合
        {
            State type = (State)i;
            string className = type.ToString();
            Type typeClass = Type.GetType(className);

            if (typeClass != null)
            {
                var state = (StateChildBase)gameObject.AddComponent(typeClass);

                stateDic[i] = state;
                state.Initialize(i);

            }
        }


        CurrentState = initializeStateType;
        stateDic[CurrentState].OnEnter();
    }
}

//コードがベースと同じクラスをまとめる
public class JerryCircle_Attack : Jerry_Attack { }

public class JerryCircle_Damage : Jerry_Damage { }

public class JerryCircle_Dead : Jerry_Dead { }

public class JerryCircle_Wait : Jerry_Wait { }
