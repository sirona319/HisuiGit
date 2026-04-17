using UnityEngine;

public class FloatMove : BaseMove
{
    [SerializeField] float floatSpeed = 0.005f;
    const float rotSpeed = 5f;
    float sinTime = 0;

        
    public override void Initialize()
    {
    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {

        sinTime += Time.deltaTime;
        //エネミーにトレイルレンダーがついている場合持続する
        MyLib.LoopMotionSinWait(sinTime, transform, 0, floatSpeed);


        //ワールド座標　上方向を向かせる
        //float targetAngle = MyLib.GetTargetAngle((transform.position + Vector3.up), transform);

        //var velocity = MyLib.SetVelocityAngle2D(targetAngle);

        transform.rotation = MyLib.GetAngleRotationFunc2D((transform.position + Vector3.up), transform, rotSpeed);

    }
}
