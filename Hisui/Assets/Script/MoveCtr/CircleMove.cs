using UnityEngine;
using UniRx;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;
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


    public Transform targetTrans;

    //bool IsTargetMove = false;

    public override void Initialize()
    {
        base.Initialize();

        //var player = GameObject.FindGameObjectWithTag("Player");

        //targetPos = player.transform.position;

        //targets = GetComponent<EnemyBase>().movePointsDatas[0];
        targetTrans = targets[0];

        //moveTrans = GetComponent<EnemyBase>().movePointsDatas;


        //var pScr = player.GetComponent<PlayerScr2D>();


        //if (GetComponent<EnemyBase>().enemyData.moveType == EnemyData.MoveType.CircleMove)
        //using UniRx必要
        //pScr.prePosDiff.Subscribe(prePosDiff => UpdatePos(pScr));
    }

    //void UpdatePos(PlayerScr2D p)
   // {
        //transform.position += p.GetComponent<PlayerScr2D>().prePosDiff.Value;

        //targetPos = p.transform.position;
   // }

    public override void MoveEnter()
    {
        //対象が動くときなど
        transform.parent = targetTrans;
    }

    public override void MoveUpdate()
    {
        //ターゲットとの距離は初期位置で決まる！！
        var tr = transform;
        // 回転のクォータニオン作成
        var angleAxis = Quaternion.AngleAxis(360 / _period * Time.deltaTime, _axis);

        // 円運動の位置計算
        var pos = tr.position;

        pos -= targetTrans.position;
        pos = angleAxis * pos;
        pos += targetTrans.position;


        tr.position = pos;
        m_rb.MovePosition(pos);


        // 向き更新
        if (_updateRotation)
        {
            tr.rotation = tr.rotation * angleAxis;
        }






        // 中心点centerの周りを、軸axisで、period周期で円運動
        //transform.RotateAround(
        //    targetPos,
        //    _axis,
        //    360 / _period * Time.deltaTime
        //);





        transform.rotation = MyLib.TargetRotation2D(targetTrans.position, transform);        ////回転


        //Vector3 movement = transform.right * Time.deltaTime * GetComponent<EnemyBase>().enemyData.Speed;

        //2D
        //m_rb.MovePosition(m_rb.position + movement);

        //const float ENDMOVELEN = 3f;
        //float len = Vector3.Distance(transform.position, targetTrans.position);
        //if (len < ENDMOVELEN)
        //{
        //    //移動地点の再設定
        //    //MoveRandomSet();
        //}
        //else
        //{
        //    Vector3 direction = targetTrans.position - transform.position;

        //    //transform.position += direction * 2f * Time.deltaTime;
        //    movement += direction * 1f * Time.deltaTime;
        //}

        ////transform.position = m_rb.position + movement;
        //m_rb.MovePosition(m_rb.position + movement);
        //Debug.Log("Fixed");
    }


    //private void FixedUpdate()
    //{
    //    //Vector3 movement= Vector3.zero; //= transform.right * Time.deltaTime * GetComponent<EnemyBase>().enemyData.Speed;

    //    ////2D
    //    ////m_rb.MovePosition(m_rb.position + movement);

    //    //const float ENDMOVELEN = 3f;
    //    //float len = Vector3.Distance(transform.position, targetTrans.position);
    //    //if (len < ENDMOVELEN)
    //    //{
    //    //    //移動地点の再設定
    //    //    //MoveRandomSet();

    //    //    //var MoveDir = GameObject.Find("CirclePoint").transform.position;

    //    //    //movement = transform.right * Time.deltaTime * GetComponent<EnemyBase>().enemyData.Speed;

    //    //}
    //    //else
    //    //{
    //    //    Vector3 direction = targetTrans.position - transform.position;

    //    //    //transform.position += direction * 2f * Time.deltaTime;
    //    //    //movement += direction * 2f * Time.deltaTime;
    //    //}

    //    //var MovePos = GameObject.Find("CirclePoint").transform.position;

    //    //var distance = Vector3.Distance(transform.position, MovePos);
    //    //float present_Location = (Time.time * 0.1f) / distance;

    //    //var movePoint= Vector3.Slerp(transform.position, MovePos, present_Location);

    //    //transform.position = movePoint;
    //    ////m_rb.MovePosition(movePoint);
    //    //Debug.Log("Fixed");
    //}

}
