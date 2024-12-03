using UnityEngine;

public class FloatVectorMove : BaseMove
{
    public Vector3 addSinVec = Vector3.zero;
    public Vector3 floatVector;
    public float speed=1.8f;

    float sinTime = 0;

    public float addSinTime;
    //スタート地点の座標を保存して　一定時間後に戻る？　それか破棄する　Wave制の更新用
    public override void Initialize(Rigidbody2D rb)
    {
        //base.Initialize(rb);
        m_rb = rb;
        IsKeepMove = true;

    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {
        sinTime += addSinTime;
        MyLib.LoopMotionSinVector(sinTime, transform, addSinVec, floatVector * speed);
        //transform.rotation = MyLib.TargetRotation2D(targets.position, transform);        ////回転

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("ExitErea"))
        {
            if(gameObject.tag=="Enemy")
            {
                gameObject.GetComponent<CreateDeadSound>().IsSoundEnable = false;
                gameObject.transform.GetComponent<EnemyBase>().EnemyDamage(10);
                return;
            }

        }

    }

    public void PosReset()
    {

    }
}
