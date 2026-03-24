using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//https://qiita.com/loveRice/items/6f458776f9a7c886280d
public abstract class StateControllerBase : MonoBehaviour
{
    protected Dictionary<int, StateChildBase> stateDic = new();

    //現在ステート
    public int CurrentState { protected set; get; }

    public abstract void Initialize(int initializeStateType);

    public void UpdateSequence()
    {
        int nextState = (int)stateDic[CurrentState].StateUpdate();
        AutoStateTransitionSequence(nextState);
    }

    public void AutoStateTransitionSequence(int nextState)
    {
        if(CurrentState == nextState)
        {
            return;
        }

        stateDic[CurrentState].OnExit();
        CurrentState = nextState;
        stateDic[CurrentState].OnEnter();
    }

    //protected void StateSet(int state)
    //{
    //    if (CurrentState == nextState)
    //    {
    //        return;
    //    }

    //    stateDic[CurrentState].OnExit();
    //    CurrentState = nextState;
    //    stateDic[CurrentState].OnEnter();
    //}
}
