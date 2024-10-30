using UnityEngine;

public class Jerry_Move : StateChildBase
{
    [SerializeField] float MOVEXY = 100;
    [SerializeField] Vector3[] movePos;
    [SerializeField] Vector3 targetPos;
    [SerializeField] float moveSaveTime = 0;


    const float ENDMOVELEN = 1f;

    Rigidbody m_rb;


    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);
        m_rb = GetComponent<Rigidbody>();

        movePos = new Vector3[4];

        //pos2D.x = transform.position.x;
        //pos2D.y = transform.position.y;


        var bPos = GetComponent<EnemyBase>().basePosition;

        MOVEXY = GetComponent<JerryScr>().moveRandXZ;

        movePos[0] = bPos;
        movePos[0].x += MOVEXY;
        movePos[1] = bPos;
        movePos[1].x -= MOVEXY;
        movePos[2] = bPos;
        movePos[2].y += MOVEXY;
        movePos[3] = bPos;
        movePos[3].y -= MOVEXY;

    }

    public override void OnEnter()
    {
        stateTime = 0f;
        moveSaveTime = 0f;


        //m_rb.linearVelocity = Vector3.zero;
        var moveRandomValue = Random.Range(0, movePos.Length);



        targetPos =
        movePos[moveRandomValue] + new Vector3
        (Random.Range(-MOVEXY, MOVEXY),
        Random.Range(-MOVEXY, MOVEXY),
        0);

        //var eBase = gameObject.GetComponent<EnemyBase>();
        //atkRandStartValue = Random.Range(eBase.enemyData.AtkRandTimeMin, eBase.enemyData.AtkRandTimeMax);


    }

    public override void OnExit()
    {

    }

    public override int StateUpdate()
    {
        stateTime += Time.deltaTime;
        moveSaveTime += Time.deltaTime;

        if (GetComponent<EnemyBase>().IsDamage)
            GetComponent<EnemyBase>().ReturnStateTypeDamage();


        //Vector3 movement = transform.up * Time.deltaTime * GetComponent<EnemyBase>().enemyData.Speed;

        ////2D
        ////movement.y = movement.z;
        //movement.z = 0;

        //m_rb.MovePosition(m_rb.position + movement);


        ////âÒì]
        //const float INTERPOLANT = 5f;

        //Vector3 targetDirection = targetPos - transform.position;

        ////2DÅ@Vector3.forwardÅ®Vector3.up
        //Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, targetDirection.normalized);


        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, INTERPOLANT * Time.deltaTime);





        /////////
        //const float INTERPOLANT = 4f;
        //transform.rotation = MyLib.TargetRotation(targetPos, transform, INTERPOLANT);
        ////////


        ///////
        //Transform arrowTrans; 
        //Transform ballTrans; 

        // Vector3 dir = targetPos - transform.position;


        //transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        /////////



        float len = Vector3.Distance(transform.position, targetPos);
        if (len < ENDMOVELEN)
        {
            return (int)BaseJerryCtr.State.BaseJerry_Wait;
        }

        //var eBase = gameObject.GetComponent<EnemyBase>();
        //var atkRand = 1;//Random.Range(eBase.enemyData.AtkRandTimeMin, eBase.enemyData.AtkRandTimeMax);

        if (moveSaveTime > GetComponent<EnemyBase>().enemyData.AtkInterval)//GetComponent<EnemyBase>().enemyData.AtkInterval
        {
            moveSaveTime = 0;

            return GetComponent<JerryScr>().ReturnStateMoveType(StateType);

        }

        return (int)StateType;

    }
}
