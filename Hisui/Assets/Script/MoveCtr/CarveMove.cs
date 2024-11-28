using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CarveMove : BaseMove
{
    //public Vector3 floatVector;

    //public float carveVal = 0f;

    public void SetCarveVal(float angle)
    {
        gameObject.GetComponent<CarveModule>().SetAngle(angle);
    }
    public override void Initialize(Rigidbody2D rb)
    {
        //base.Initialize(rb);
        m_rb = rb;
        IsKeepMove = true;

        this.gameObject.AddComponent<CarveModule>();
    }



    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {

        const float speed = 4f;
        m_rb.MovePosition(m_rb.position + (Vector2)transform.up * speed * Time.deltaTime);

        //transform.rotation = MyLib.GetAngleRotationFuncs(floatVector, transform, 1);
        //transform.rotation = MyLib.TargetRotation2D(targets.position, transform);        ////回転

    }
}
