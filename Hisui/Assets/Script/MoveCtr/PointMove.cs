using UnityEngine;


public class PointMove : BaseMove
{
    Transform[] moveTrans;
    int targetNo = 0;
    const float ENDMOVELEN = 0.5f;

    bool IsPoint = false;

    public override void Initialize()
    {
        base.Initialize();

        //targetNo = eBase.firstTargetPoints;

        moveTrans = GetComponent<EnemyBase>().enemyData.movePointsSet;


        if (moveTrans.Length <= 0)
            throw new System.Exception(GetComponent<EnemyBase>().findName + "ムーブポイント未設定");
    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {
        if (IsPoint)
            return;

        var moveSpd = GetComponent<EnemyBase>().enemyData.Speed;
        m_rb.MovePosition(m_rb.position + transform.up * moveSpd * Time.deltaTime);



        const float INTERPOLANT = 5f;

        Vector3 targetDirection = moveTrans[targetNo].position - transform.position;
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, targetDirection.normalized);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, INTERPOLANT * Time.deltaTime);



        float len = Vector3.Distance(transform.position, moveTrans[targetNo].position);
        if (len < ENDMOVELEN)
        {
            //if (GetComponent<BaseJerryScr>().enemyData.FirstTargetPlayer)
            //     return GetComponent<BaseJerryScr>().ReturnStateMoveType(StateType);


            targetNo++;
            if (targetNo > moveTrans.Length - 1)
            {

                IsPoint = true;
                targetNo = 0;
            }
            //GetComponent<JerryScr>().IsMove = false;
            //return StateType;
        }


    }

}
