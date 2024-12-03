using System;
using System.Runtime.CompilerServices;
using UniRx;
using UnityEngine;

public class PointCircleMove : BaseMove
{

    public float speed = 10f;

    // 回転軸
    [SerializeField] private Vector3 _axis = Vector3.forward;

    // 円運動周期
    [SerializeField] private float _period = 2;

    // 向きを更新するかどうか
    [SerializeField] private bool _updateRotation = true;

    //指定座標への到達判定距離
    float pointEndLength = 2f;
    int targetNo = 0;

    Transform[] targets;
    Transform target;

    public ReactiveProperty<bool> IsPointMoveEnd = new ReactiveProperty<bool>(false);

    bool isLoop = false;

    public void TargetSet(Transform[] t)
    {
        targets = t;

        target = targets[0];

        if (targets.Length <= 0)
            throw new System.Exception(transform.name + "PointMoveムーブポイント未設定");
    }

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
        m_rb = rb;
        IsKeepMove = true;

    }


    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {
        if (IsPointMoveEnd.Value)
        {
            CircleUpdate();
            return;
        }
        else
        {
            PointUpdate();
        }



        if (IsPointMoveEnd.Value)
            SetParent(targets[0]);//ポイント移動を終了



    }

    void PointUpdate()
    {
        float len = Vector3.Distance(transform.position, targets[targetNo].position);

        if (len < pointEndLength)
        {

            targetNo++;
            if (targetNo > targets.Length - 1)
            {
                //if (!IsKeepMove)
                    IsPointMoveEnd.Value = true;

                if (isLoop)
                    targetNo = 0;
                else
                    targetNo--;

            }

        }

        //transform.position = m_rb.position + (Vector2)transform.up * speed * Time.deltaTime;
        m_rb.MovePosition(m_rb.position + (Vector2)transform.up * speed * Time.deltaTime);




        float targetAngle = MyLib.GetTargetAngle2D(targets[targetNo].position, transform);

        var velocity = MyLib.SetVelocityAngle2D(targetAngle);

        transform.rotation =
            MyLib.TargetRotation2DZOnlyLerp(transform, velocity, 5f);
        //transform.rotation = MyLib.TargetRotation2D(targets[targetNo].position, transform);

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


        m_rb.MovePosition(m_rb.position + (Vector2)transform.up * speed * Time.deltaTime);



        float targetAngle = MyLib.GetTargetAngle2D(targets[targetNo].position, transform);

        var velocity = MyLib.SetVelocityAngle2D(targetAngle);

        transform.rotation =
            MyLib.TargetRotation2DZOnlyLerp(transform, velocity, 5f);
        //transform.rotation = MyLib.TargetRotation2D(targets[targetNo].position, transform);

    }

}
