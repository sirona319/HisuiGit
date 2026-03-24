using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateChildBase : MonoBehaviour
{

    protected StateControllerBase controller;

    protected int StateType { get; set; }

    [SerializeField] protected float stateTime = 0f;

    //private void Start()
    //{
    //    //ステートの個数分呼ばれる
    //    //Debug.Log("StateChildBaseのStart関数が呼ばれた");
    //}

    public virtual void Initialize(int stateType)
    {
        //Debug.Log("StateChildBaseのInitialize関数が呼ばれた");
        StateType = stateType;
        controller = GetComponent<StateControllerBase>();
    }

    public abstract void OnEnter();

    public abstract void OnExit();

    public abstract int StateUpdate();

    //public abstract void ChildUpdate();
}
