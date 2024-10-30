using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomMove : BaseMove
{
    [SerializeField] float MOVEXY = 100;
    [SerializeField] Vector3[] movePos;
    [SerializeField] Vector3 targetPos;
    [SerializeField] float moveSaveTime = 0;


    const float ENDMOVELEN = 1f;

    public override void Initialize()
    {
        base.Initialize();

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

    public override void MoveEnter()
    {
        //m_rb.linearVelocity = Vector3.zero;
        var moveRandomValue = Random.Range(0, movePos.Length);



        targetPos =
        movePos[moveRandomValue] + new Vector3
        (Random.Range(-MOVEXY, MOVEXY),
        Random.Range(-MOVEXY, MOVEXY),
        0);
    }

    public override void MoveUpdate()
    {

        Vector3 movement = transform.up * Time.deltaTime * GetComponent<EnemyBase>().enemyData.Speed;

        //2D
        //movement.y = movement.z;
        movement.z = 0;

        m_rb.MovePosition(m_rb.position + movement);


        //âÒì]
        const float INTERPOLANT = 5f;

        Vector3 targetDirection = targetPos - transform.position;

        //2DÅ@Vector3.forwardÅ®Vector3.up
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, targetDirection.normalized);


        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, INTERPOLANT * Time.deltaTime);
    }


}
