using UnityEngine;

public class FloatVectorMove : BaseMove
{
    public Vector3 addVec = Vector3.zero;
    public Vector3 floatVector;
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
        MyLib.LoopMotionSinVector(transform, addVec, floatVector);
        //transform.rotation = MyLib.TargetRotation2D(targets.position, transform);        ////回転

    }
}
