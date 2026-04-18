using UnityEngine;

public class EnFloatMove : BaseMove
{
    [SerializeField] float floatSpeed = 0.005f;
    const float rotSpeed = 10f;
    float sinTime = 0;


    void FixedUpdate()
    {

        sinTime += Time.deltaTime;
        //エネミーにトレイルレンダーがついている場合持続する
        MyLib.LoopMotionSinWait(sinTime, transform, 0, floatSpeed);

        transform.rotation = MyLib.GetAngleRotationFunc2D((transform.position + Vector3.up), transform, rotSpeed);

    }
}
