using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomMove : BaseMove
{

    //[SerializeField] float MOVEXY = 100;
    [SerializeField] Vector3[] movePos;
    [SerializeField] Vector3 targetPos;

    float moveRangeXZ = 3;
    const float ENDMOVELEN = 1f;

    const float INTERPOLANT = 5f;
    public override void Initialize(Rigidbody2D rb)
    {
        base.Initialize(rb);

        //MOVEXY = moveRangeXZ;

        movePos = new Vector3[4];

        //transformはtargetsになるようにする？？
        movePos[0] = transform.position;
        movePos[0].x += moveRangeXZ;
        movePos[1] = transform.position;
        movePos[1].x -= moveRangeXZ;
        movePos[2] = transform.position;
        movePos[2].y += moveRangeXZ;
        movePos[3] = transform.position;
        movePos[3].y -= moveRangeXZ;

        IsKeepMove = true;
    }

    public override void MoveEnter()
    {
        MoveRandomSet();
    }

    public override void MoveUpdate()
    {
        const float speed = 6f;
        Vector2 movement = transform.up * Time.deltaTime * speed;

        m_rb.MovePosition(m_rb.position + movement);



        transform.rotation = MyLib.TargetRotation2D(targetPos, transform);        //回転


        float len = Vector3.Distance(transform.position, targetPos);
        if (len < ENDMOVELEN)
        {
            //移動地点の再設定
            MoveRandomSet();
        }
    }

    void MoveRandomSet()
    {
        var moveRandomValue = Random.Range(0, movePos.Length);

        targetPos =
        movePos[moveRandomValue] + new Vector3
        (Random.Range(-moveRangeXZ, moveRangeXZ),
        Random.Range(-moveRangeXZ, moveRangeXZ),
        0);
    }


}
