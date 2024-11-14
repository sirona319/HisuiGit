using System;
using UniRx;
using UnityEngine;

public class PointCircleMove : BaseMove, ICircleMove
{

    //CircleMove circle;
    //PointMove point;
    public float speed = 40f;


    // 回転軸
    [SerializeField] private Vector3 _axis = Vector3.forward;

    // 円運動周期
    [SerializeField] private float _period = 2;

    // 向きを更新するかどうか
    [SerializeField] private bool _updateRotation = true;


    float pointEndLength = 2f;
    //bool IsPointMoveEnd = false;
    //bool IsLoop = false;
    int targetNo = 0;

    Transform[] targets;
    Transform target;

    public ReactiveProperty<bool> IsPointMoveEnd = new ReactiveProperty<bool>(false);

    public void TargetSet(Transform[] t)
    {
        targets = t;

        target = targets[0];
        //circle.targets = t[0];
        //point.TargetSet(t);
        if (targets.Length <= 0)
            throw new System.Exception(transform.name + "PointMoveムーブポイント未設定");
    }

    //public bool GetMoveEnd()
    //{
    //    return IsPointMoveEnd.Value;
    //}

    public void SetMoveEndLength(float len)
    {
        pointEndLength = len;
    }

    public void SetParent(Transform t)
    {
        transform.parent = t;
    }

    public override void Initialize(Rigidbody2D rb)
    {
        base.Initialize(rb);

        IsKeepMove = true;
        //point = new PointMove();
        //circle = new CircleMove();
        //point = gameObject.AddComponent<PointMove>();
        //circle = gameObject.AddComponent<CircleMove>();
        //circle.Initialize();
        //point.Initialize();
    }


    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {
        if (IsPointMoveEnd.Value)
        {
            //IsNotMoveAction(() =>
            //{
            CircleUpdate();
            return;
            //});

            //return;
        }

        PointUpdate();

        //float len = Vector3.Distance(transform.position, circle.targetTrans.position);
        //if (!point.IsMove)
        //{
        if (IsPointMoveEnd.Value)
        {
            //if (transform.tag == "Enemy")
            //    GetComponent<JerryScr>().IsAttack = true;


            //point.enabled = false;//ポイント移動を終了
            SetParent(targets[0]);
        }


        m_rb.MovePosition(m_rb.position + (Vector2)transform.up * speed * Time.deltaTime);

        transform.rotation = MyLib.TargetRotation2D(targets[targetNo].position, transform);
    }

    void PointUpdate()
    {
        float len = Vector3.Distance(transform.position, targets[targetNo].position);

        if (len < pointEndLength)
        {

            targetNo++;
            if (targetNo > targets.Length - 1)
            {
                if (!IsKeepMove)
                    IsPointMoveEnd.Value = true;

                targetNo = 0;
            }

        }

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


        tr.position = pos;
        m_rb.MovePosition(pos);


        // 向き更新
        if (_updateRotation)
        {
            tr.rotation = tr.rotation * angleAxis;
        }
    }

}
