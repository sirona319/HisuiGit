using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryCtr : StateControllerBase
{
    public enum State
    {
        Jerry_Wait,
        Jerry_Damage,
        Jerry_Dead,
        Jerry_Attack,
        Jerry_Move,


        NumStates
    }

    public override void Initialize(int initializeStateType)
    {

        for (int i = 0; i < (int)State.NumStates; i++) //NumStates‚ðŽg‚¤ê‡
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
