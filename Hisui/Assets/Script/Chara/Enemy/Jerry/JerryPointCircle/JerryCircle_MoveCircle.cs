using UnityEngine;
using static EnemyData;

public class JerryCircle_MoveCircle : StateChildBase
{
    CircleMove circleMove;

    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

        circleMove = GetComponent<EnemyBase>().MoveTypeSelect(MoveType.CircleMove) as CircleMove;
        circleMove.targetTrans = GetComponent<EnemyBase>().movePointsDatas[0];
    }

    public override void OnEnter()
    {
        stateTime = 0f;

        //foreach (var move in GetComponent<EnemyBase>().baseMove)
            circleMove.MoveEnter();

        GetComponent<EnemyBase>().IsAttack = true;

    }

    public override void OnExit()
    {

    }

    public override int StateUpdate()
    {
        stateTime += Time.deltaTime;

        if (GetComponent<EnemyBase>().IsDamage)
            return GetComponent<EnemyBase>().ReturnStateTypeDamage();


        //à⁄ìÆÇÃçXêV
        circleMove.MoveUpdate();



        if (GetComponent<EnemyBase>().AtkInterval <= 0)
            return (int)JerryPointCircleCtr.State.JerryCircle_Attack;


        return StateType;

    }
}
