using UnityEngine;
using static EnemyData;

public class JerryCircle_MovePoint : StateChildBase
{
    PointMove pointMove;
    //CircleMove circleMove;
    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

        pointMove = GetComponent<EnemyBase>().MoveTypeSelect(MoveType.PointMove) as PointMove;
        pointMove.TargetSet(GetComponent<EnemyBase>().movePointsDatas);
        pointMove.endLength = 2f;
        pointMove.IsLoop = false;
    }

    public override void OnEnter()
    {
        stateTime = 0f;

        //foreach (var move in GetComponent<EnemyBase>().baseMove)
            pointMove.MoveEnter();

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
        pointMove.MoveUpdate();


        if (pointMove.IsPointMoveEnd)
            return (int)JerryPointCircleCtr.State.JerryCircle_MoveCircle;


        return StateType;

    }
}
