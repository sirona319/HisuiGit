using UnityEngine;

public class FloatVectorMove : BaseMove
{
    [SerializeField] float floatSpeed = 0.005f;
    [SerializeField] Vector3 floatVector;
    public override void Initialize(Rigidbody2D rb)
    {
        base.Initialize(rb);

        IsKeepMove = true;

    }



    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {
        MyLib.LoopMotionSinVector(transform,0, floatSpeed, floatVector);
        //transform.rotation = MyLib.TargetRotation2D(targets.position, transform);        ////‰ñ“]

    }
}
