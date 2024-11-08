using UnityEngine;
using static EnemyData;

public class Jerry_Move : StateChildBase
{
    //[SerializeField] float MOVEXY = 100;
    //[SerializeField] Vector3[] movePos;
    //[SerializeField] Vector3 targetPos;
    //[SerializeField] float moveSaveTime = 0;


    //const float ENDMOVELEN = 1f;

    //Rigidbody m_rb;

    PointMove pointMove;

    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

        //foreach (var move in GetComponent<JerryScr>().baseMove)
        //    move.Initialize();

        pointMove = GetComponent<JerryScr>().MoveTypeSelect(MoveType.PointMove) as PointMove;
        pointMove.IsLoop = false;
        pointMove.TargetSet(GetComponent<EnemyBase>().movePointsDatas);

        //pointMove.endLength = 3f;
        //GetComponent<JerryScr>().baseMove.move

    }

    public override void OnEnter()
    {
        stateTime = 0f;

        //foreach (var move in GetComponent<JerryScr>().baseMove)
            pointMove.MoveEnter();

    }

    public override void OnExit()
    {
        //stateTime = 0;
    }

    public override int StateUpdate()
    {
        stateTime += Time.deltaTime;
        //moveSaveTime += Time.deltaTime;

        if (GetComponent<EnemyBase>().IsDamage)
            return GetComponent<JerryScr>().ReturnStateTypeDamage();


        //移動の更新
        pointMove.MoveUpdate();

        //コルーチンで登録するようにする
        //if(pointMove.IsPointMoveEnd)



        if (pointMove.IsPointMoveEnd)
        {
            GetComponent<JerryScr>().IsAttack = true;
            GetComponent<JerryScr>().IsMove = false;
            return (int)GetComponent<JerryScr>().JerryReturnStateType(StateType);
        }
            


        return StateType;

    }
}
