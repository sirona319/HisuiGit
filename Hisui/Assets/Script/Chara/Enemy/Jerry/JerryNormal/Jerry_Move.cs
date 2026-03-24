using UnityEngine;


public class Jerry_Move : StateChildBase
{
    //[HideInInspector]
    //public bool IsKeepMove = false;

    BaseMove move;
    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

        move = GetComponent<EnemyBase>().move;
        //move.Initialize();
    }

    public override void OnEnter()
    {
        stateTime = 0f;

        move.MoveEnter();

    }

    public override void OnExit()
    {
        //stateTime = 0;
    }

    public override int StateUpdate()
    {
        stateTime += Time.deltaTime;

        if (GetComponent<JerryScr>().IsDamage)
            if (GetComponent<JerryScr>().ReturnStateTypeDead())
                return (int)JerryCtr.State.Jerry_Dead;


        move.MoveUpdate();        //移動の更新


        if (!GetComponent<JerryScr>().IsMove)
        {
            return (int)GetComponent<JerryScr>().JerryReturnStateType(StateType);
        }
            
        return StateType;

    }
}
