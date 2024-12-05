using UnityEngine;


public class Jerry_Move : StateChildBase
{
    //[HideInInspector]
    //public bool IsKeepMove = false;
    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);
    }

    public override void OnEnter()
    {
        stateTime = 0f;

        foreach (var move in GetComponent<JerryScr>().baseMove)
            move.MoveEnter();

    }

    public override void OnExit()
    {
        //stateTime = 0;
    }

    public override int StateUpdate()
    {
        stateTime += Time.deltaTime;

        if (GetComponent<EnemyBase>().IsDamage)
            if (GetComponent<EnemyBase>().ReturnStateTypeDead())
                return (int)JerryCtr.State.Jerry_Dead;


        //移動の更新
        foreach (var move in GetComponent<JerryScr>().baseMove)
        {
            move.MoveUpdate();

        }


        if (GetComponent<JerryScr>().AtkInterval <= 0|| !GetComponent<JerryScr>().IsMove)
        {

            return (int)GetComponent<JerryScr>().JerryReturnStateType(StateType);
        }
            


        return StateType;

    }
}
