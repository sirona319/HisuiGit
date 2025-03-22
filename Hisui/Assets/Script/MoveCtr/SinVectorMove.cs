using UnityEngine;

public class SinVectorMove : BaseMove
{
    enum SinType
    {
        Add,
        Sub,
    }
    [SerializeField] SinType sinType;

    public Vector3 addSinVec = Vector3.zero;
    public Vector3 floatVector;
    [SerializeField] float speed=1.8f;

    float sinTime = 0;

    [SerializeField]float addSinTime;

    //public void SubSin()
    //{
    //    addSinTime = -Time.deltaTime;
    //}
    //public void AddSin()
    //{
    //    addSinTime = Time.deltaTime;
    //}
    //スタート地点の座標を保存して　一定時間後に戻る？　それか破棄する　Wave制の更新用
    public override void Initialize()
    {
        //base.Initialize(rb);
        //m_rb = rb;
       // IsKeepMove = true;

        if(sinType == SinType.Add)
            addSinTime = Time.deltaTime;
        else if(sinType == SinType.Sub)
            addSinTime = -Time.deltaTime;
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

    //public void PosReset()
    //{

    //}
}
