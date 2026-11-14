using UnityEngine;

public class DirectionMove : BaseMove
{
    public float speed = 7f;
    float rotSpeed = 10f;
    float rotStopTime = 3f;

    public Vector3 targetsVec;

    //public bool isRot = true;
    //Vector2 targetDir;
    [SerializeField] Rigidbody2D rb2;

    public void TargetSet(Vector3 t)
    {
        targetsVec = t;
        //targetDir = (targetsVec - transform.position).normalized;
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {
        //if (isRot)
        RotUpdate();

        if(rb2!=null)
            rb2.MovePosition(rb2.position + (Vector2)transform.up * speed * Time.deltaTime);

        transform.position += (Vector3)transform.up * speed * Time.deltaTime;

    }

    void RotUpdate()
    {
        if (rotStopTime <= 0) return;
        rotStopTime -= Time.deltaTime;

        transform.rotation = MyLib.GetAngleRotationFuncs(targetsVec, transform, rotSpeed);


    }
}
