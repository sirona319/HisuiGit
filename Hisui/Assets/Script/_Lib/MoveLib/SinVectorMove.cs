using UnityEngine;

public class SinVectorMove : BaseMove
{
    Vector3 addSinVec = Vector3.zero;
    Vector3 floatVector;

    float sinTime = 0;

    [SerializeField] float sinVal = 0.02f;

    [SerializeField]float speed=1.8f;

    float moveVal = 0.02f;

    [SerializeField] Transform targetTrans;

    private void Start()
    {
        Initialize();
    }
    private void FixedUpdate()
    {
        MoveUpdate();
    }
    //スタート地点の座標を保存して　一定時間後に戻る？　それか破棄する　Wave制の更新用
    public override void Initialize()
    {

        var dir = targetTrans.position - transform.position;

        transform.rotation = Quaternion.FromToRotation(Vector3.up, dir.normalized);

        floatVector = dir.normalized * moveVal;

        addSinVec = transform.right * sinVal;
    }

    public override void MoveUpdate()
    {
        sinTime += Time.fixedDeltaTime;
        MyLib.LoopMotionSinVector(sinTime, transform, addSinVec, floatVector * speed);
        //transform.rotation = MyLib.TargetRotation2D(targets.position, transform);        ////回転

    }

}
