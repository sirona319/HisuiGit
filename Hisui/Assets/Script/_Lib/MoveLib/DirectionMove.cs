using UnityEngine;

public class DirectionMove : BaseMove
{

    public float speed = 7f;
    const float rotSpeed = 5f;
    float rotStopTime = 3f;

    Vector3 targetsVec;
    //Vector2 targetDir;

    Rigidbody2D rb2;

    public void TargetSet(Vector3 t)
    {
        targetsVec = t;
        //targetDir = (targetsVec - transform.position).normalized;
    }

    public override void Initialize()
    {
        rb2 = GetComponent<Rigidbody2D>();
        // m_rb = rb;
        // IsKeepMove = true;
    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {
        RotUpdate();

        rb2.MovePosition(rb2.position + (Vector2)transform.up * speed * Time.deltaTime);

    }

    void RotUpdate()
    {
        if (rotStopTime <= 0) return;
        rotStopTime -= Time.deltaTime;

        transform.rotation = MyLib.GetAngleRotationFuncs(targetsVec, transform, rotSpeed);


    }
}
