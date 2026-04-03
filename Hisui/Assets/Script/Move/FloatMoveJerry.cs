using UnityEngine;

public class FloatMoveJerry : BaseMove
{
    [SerializeField] float floatSpeed = 0.005f;
    const float rotSpeed = 10f;
    float sinTime = 0;


    void FixedUpdate()
    {

        sinTime += Time.deltaTime;
        //エネミーにトレイルレンダーがついている場合持続する
        // MyLib.LoopMotionSinWait(sinTime, transform, 0, floatSpeed);


        //ワールド座標　上方向を向かせる
        //float targetAngle = MyLib.GetTargetAngle((transform.position + Vector3.up), transform);

        //var velocity = MyLib.SetVelocityAngle2D(targetAngle);
        //transform.rotation = MyLib.TargetRotation2D((transform.position + Vector3.up), transform, 10f);
        transform.rotation = MyLib.GetAngleRotationFuncs((transform.position + Vector3.up), transform, rotSpeed);

        //Debug.Log("FloatMoveJerry　FixedUpdate");

    }

    public override void MoveEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void MoveUpdate()
    {
        throw new System.NotImplementedException();
    }
}
