using UnityEngine;

public class SinVectorMove : BaseMove
{
    //enum SinType
    //{
    //    Add,
    //    Sub,
    //}
    //[SerializeField] SinType sinType;
    //float addSinTime;


    Vector3 addSinVec = Vector3.zero;
    Vector3 floatVector;

    float sinTime = 0;



    [SerializeField] float sinVal = 0.02f;

    [SerializeField]float speed=1.8f;



    //TargetSet targetSet;
    float moveVal = 0.02f;

    [SerializeField] Transform targetTrans;

    private void Start()
    {
        Initialize();

        Debug.Log(gameObject.name+"SinVectorMove Start");
    }
    private void FixedUpdate()
    {
        MoveUpdate();
    }
    //スタート地点の座標を保存して　一定時間後に戻る？　それか破棄する　Wave制の更新用
    public override void Initialize()
    {

        //if (sinType == SinType.Add)
        //    addSinTime = Time.deltaTime;
        //else if (sinType == SinType.Sub)
        //    addSinTime = -Time.deltaTime;
        //addSinTime = Time.deltaTime;

        //targetSet=GetComponent<TargetSet>();




        var movePos = TargetSet.I.GetTargetTrans(targetTrans, gameObject).position;
        var dir = movePos - transform.position;

        transform.rotation = Quaternion.FromToRotation(Vector3.up, dir.normalized);




        //transform.rotation = MyLib.GetAngleRotationFuncs((transform.position + Vector3.up), transform, 10);
        //const float sinVal = 0.04f;
        //const float sinValMini = 0.02f;
        //見た目だけの回転
        //var spriteTrans = transform.Find("Sprite").gameObject.transform;
        //spriteTrans.rotation = Quaternion.FromToRotation(Vector3.up, transform.up);

        //float moveVal = speedM;//0.02f;
        floatVector = dir.normalized * moveVal;

        addSinVec = transform.right * sinVal;
    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {
        sinTime += Time.fixedDeltaTime;
        MyLib.LoopMotionSinVector(sinTime, transform, addSinVec, floatVector * speed);
        //transform.rotation = MyLib.TargetRotation2D(targets.position, transform);        ////回転

    }



    //private void OnTriggerExit2D(Collider2D other)
    //{

    //    if (other.CompareTag("ExitErea"))
    //    {
    //        if(gameObject.tag=="Enemy")
    //        {
    //            Debug.Log("ExitEreaに触れた  SoundCreateDead");
    //            //gameObject.GetComponent<CreateDeadSound>().IsSoundEnable = false;
    //            gameObject.transform.GetComponent<EnemyBase>().EnemyDamage(10);
    //            return;
    //        }

    //    }

    //}

    //public void PosReset()
    //{

    //}
}
