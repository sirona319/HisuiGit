using UniRx;
using UnityEngine;
using static TargetSet;

public class CircleMove : BaseMove
{
    //[SerializeField] float speed = 10f;

    // 回転軸
    [SerializeField] private Vector3 _axis = Vector3.forward;

    // 円運動周期
    [SerializeField] private float _period = 2;

    // 向きを更新するかどうか
    [SerializeField] private bool _updateRotation = true;

    //指定座標への到達判定距離
    [SerializeField] float pointEndLength;

    bool isTargetLenge = false;
    //int targetNo = 0;

    //Transform[] targets;
    [SerializeField] Transform target;
    TargetSet targetSet;
    //[SerializeField] Target targetType;
    Rigidbody2D rb2;

    public override void Initialize()
    {
        rb2 = GetComponent<Rigidbody2D>();
        targetSet=GetComponent<TargetSet>();
        targetSet.Init();
        target = targetSet.Set(TargetName.Circle);
    }

    public override void MoveEnter()
    {
        transform.parent = target;//サークル移動へ移行
    }

    public override void MoveUpdate()
    {

        CircleUpdate();

    }

    void CircleUpdate()
    {
        //ターゲットとの距離は初期位置で決まる！！
        var tr = transform;
        // 回転のクォータニオン作成
        var angleAxis = Quaternion.AngleAxis(360 / _period * Time.deltaTime, _axis);

        // 円運動の位置計算
        var pos = tr.position;

        pos -= target.position;
        pos = angleAxis * pos;
        pos += target.position;


        // 向き更新
        if (_updateRotation)
        {
            tr.rotation = tr.rotation * angleAxis;
        }


        float len = Vector3.Distance(transform.position, target.position);
        float pointEndLengthShort = 3f;
        float pointEndLengthLong = 5f;
        Vector3 dir;
        if (!isTargetLenge)
        {

            dir = transform.position - target.position;
            if (len > pointEndLengthLong)
                isTargetLenge = true;

        }
        else
        {
            dir = target.position - transform.position;
            if (len < pointEndLengthShort)
                isTargetLenge = false;


        }

        const float targetSpeed = 0.3f;
        rb2.MovePosition((Vector2)pos + ((Vector2)dir * targetSpeed) * Time.deltaTime);

        transform.rotation = MyLib.GetAngleRotationFuncs(target.position, transform, 5f);

    }

}
