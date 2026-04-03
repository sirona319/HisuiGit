using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CarveMove : BaseMove
{
    //public Vector3 floatVector;

    //public float carveVal = 0f;

    Rigidbody2D rb2;

    [SerializeField] CarveModule carveModule;

    public void SetCarveVal(float angle)
    {
        //carveModule.SetAngle(angle);
    }
    public override void Initialize()
    {
        rb2 = GetComponent<Rigidbody2D>();

        this.gameObject.AddComponent<CarveModule>();
    }



    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {

        const float speed = 4f;
        rb2.MovePosition(rb2.position + (Vector2)transform.up * speed * Time.deltaTime);

        //transform.rotation = MyLib.GetAngleRotationFuncs(floatVector, transform, 1);
        //transform.rotation = MyLib.TargetRotation2D(targets.position, transform);        ////回転

    }
}
