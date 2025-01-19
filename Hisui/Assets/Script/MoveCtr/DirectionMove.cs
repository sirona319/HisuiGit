using System.Runtime.CompilerServices;
using UniRx;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DirectionMove : BaseMove
{

    public float speed = 7f;
    const float rotSpeed = 5f;
    float rotStopTime = 3f;

    Vector3 targetsVec;
    //Vector2 targetDir;

    public void TargetSet(Vector3 t)
    {
        targetsVec = t;
        //targetDir = (targetsVec - transform.position).normalized;
    }

    public override void Initialize(Rigidbody2D rb)
    {

        m_rb = rb;
        IsKeepMove = true;
    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {
        RotUpdate();

        m_rb.MovePosition(m_rb.position + (Vector2)transform.up * speed * Time.deltaTime);

    }

    void RotUpdate()
    {
        if (rotStopTime <= 0) return;
        rotStopTime -= Time.deltaTime;

        transform.rotation = MyLib.GetAngleRotationFuncs(targetsVec, transform, rotSpeed);


    }
}
