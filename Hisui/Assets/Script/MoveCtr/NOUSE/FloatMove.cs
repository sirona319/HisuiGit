using UnityEngine;

public class FloatMove : BaseMove
{
    [SerializeField] float floatSpeed = 0.005f;

    float sinTime = 0;
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
        MyLib.LoopMotionSinWait(sinTime,transform, 0, floatSpeed);

        //transform.rotation = MyLib.TargetRotation2D(targets.position, transform);        ////回転

    }


}
