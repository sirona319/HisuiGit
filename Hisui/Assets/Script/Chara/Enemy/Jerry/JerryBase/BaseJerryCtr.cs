using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseJerryCtr : StateControllerBase
{
    public enum State
    {
        BaseJerry_Wait,
        BaseJerry_Damage,
        BaseJerry_Dead,
        BaseJerry_Attack,
        BaseJerry_Move,


        NumStates
    }

    public override void Initialize(int initializeStateType)
    {

        for (int i = 0; i < (int)State.NumStates; i++) //NumStates���g���ꍇ
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

    //protected void BaseJerryStateSet(State enemyState)
    //{
    //    AutoStateTransitionSequence((int)enemyState);
    //}
}

//public class BaseJerry_Move : EnemyStateChildBaseMove2D{}
