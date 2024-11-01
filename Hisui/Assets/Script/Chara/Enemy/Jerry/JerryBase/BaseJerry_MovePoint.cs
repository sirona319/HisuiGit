using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseJerry_MovePoint : StateChildBase
{
    Transform[] moveTrans;
    int targetNo = 0;
    protected float ENDMOVELEN = 0.5f;


    Rigidbody m_rb;
    //Animator m_anim;


    [SerializeField] float moveSaveTime = 0;


    public override void Initialize(int stateType)
    {
        base.Initialize(stateType);
        m_rb = GetComponent<Rigidbody>();

        var eBase = GetComponent<JerryScr>();

        //m_anim = GetComponent<Animator>();





        //if (eBase.enemyData.FirstTargetPlayer)
        //{
        //    var p = GameObject.FindGameObjectWithTag("Player");

        //    moveTrans = new Transform[1];
        //    moveTrans[0] = p.transform;
        //}
        //else
        //    moveTrans = eBase.movePoints;


        //if (moveTrans.Length <= 0)
        //    throw new System.Exception(eBase.findName + "ムーブポイント未設定");



        targetNo = 0;

    }

    public override void OnEnter()
    {
        stateTime = 0f;

        //m_anim.SetBool("Run", true);
        //m_rb.linearVelocity = Vector3.zero;


    }

    public override void OnExit()
    {

    }

    public override int StateUpdate()
    {
        stateTime += Time.deltaTime;
        moveSaveTime += Time.deltaTime;

        if (GetComponent<EnemyBase>().IsDamage)
        {
            return (int)BaseJerryCtr.State.BaseJerry_Damage;
        }

        //if (GetComponent<EnemyBase>().movePoints.Length <= 1)
        //    return (int)SlimeCtr.State.Slime_Find;

        //if (SPEED <= 0)
        //    return StateType;




        //toFront.normalized==transform.up

        //Vector3 toFront = transform.up - transform.position;
        //Vector3 moveDir = toFront.normalized;
        //2D
        //movement.y = 0;

        var moveSpd = GetComponent<EnemyBase>().enemyData.Speed;
        m_rb.MovePosition(m_rb.position + transform.up * moveSpd * Time.deltaTime);



        //��]
        const float INTERPOLANT = 5f;

        Vector3 targetDirection = moveTrans[targetNo].transform.position - transform.position;
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
                targetNo = 0;
            }


            return StateType;
        }



        if (moveSaveTime > GetComponent<EnemyBase>().enemyData.AtkInterval)
        {
            moveSaveTime = 0;

            //return GetComponent<EnemyBase>().ReturnStateMoveTypeAttack(StateType);
        }

        return StateType;

    }
}
