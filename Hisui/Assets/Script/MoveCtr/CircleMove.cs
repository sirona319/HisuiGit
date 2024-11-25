using UnityEngine;
using UniRx;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;
public class CircleMove : BaseMove
{
    //https://nekojara.city/unity-circular-motion


    // 中心点
    //[SerializeField] private Vector3 targetPos = Vector3.zero;

    // 回転軸
    [SerializeField] private Vector3 _axis = Vector3.forward;

    // 円運動周期
    [SerializeField] private float _period = 2;

    // 向きを更新するかどうか
    [SerializeField] private bool _updateRotation = true;


    public Transform targets;


    public void SetParent(Transform t)
    {
        transform.parent = t;
    }

    public override void Initialize(Rigidbody2D rb)
    {
        base.Initialize(rb);

        IsKeepMove = true;

    }


    public override void MoveEnter()
    {
        //Debug.Log(targetTrans);
        SetParent(targets);
    }

    public override void MoveUpdate()
    {

        CircleUpdate();


        transform.rotation = MyLib.TargetRotation2D(targets.position, transform);        ////回転

    }

    void CircleUpdate()
    {
        //ターゲットとの距離は初期位置で決まる！！
        var tr = transform;
        // 回転のクォータニオン作成
        var angleAxis = Quaternion.AngleAxis(360 / _period * Time.deltaTime, _axis);

        // 円運動の位置計算
        var pos = tr.position;

        pos -= targets.position;
        pos = angleAxis * pos;
        pos += targets.position;


        tr.position = pos;
        m_rb.MovePosition(pos);


        // 向き更新
        if (_updateRotation)
        {
            tr.rotation = tr.rotation * angleAxis;
        }
    }

}
