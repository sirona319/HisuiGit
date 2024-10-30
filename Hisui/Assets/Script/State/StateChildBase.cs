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
    //    //�X�e�[�g�̌����Ă΂��
    //    //Debug.Log("StateChildBase��Start�֐����Ă΂ꂽ");
    //}

    public virtual void Initialize(int stateType)
    {
        //Debug.Log("StateChildBase��Initialize�֐����Ă΂ꂽ");
        StateType = stateType;
        controller = GetComponent<StateControllerBase>();
    }

    public abstract void OnEnter();

    public abstract void OnExit();

    public abstract int StateUpdate();

    //public abstract void ChildUpdate();
}
