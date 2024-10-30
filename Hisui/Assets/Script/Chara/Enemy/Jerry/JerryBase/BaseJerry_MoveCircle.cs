using UnityEngine;
using UniRx;

public class BaseJerry_MoveCircle : StateChildBase
{

    //[SerializeField] float MOVEXY = 100;
    //[SerializeField] Vector3[] movePos;
    //[SerializeField] Vector3 targetPos;
    [SerializeField] float moveSaveTime = 0;


    //const float ENDMOVELEN = 1f;

    Rigidbody m_rb;

    // 中心点
    [SerializeField] private Vector3 targetPos = Vector3.zero;

    // 回転軸
    [SerializeField] private Vector3 _axis = Vector3.forward;

    // 円運動周期
    [SerializeField] private float _period = 2;

    // 向きを更新するかどうか
    [SerializeField] private bool _updateRotation = true;


    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);
        m_rb = GetComponent<Rigidbody>();

        var player = GameObject.FindGameObjectWithTag("Player");

        targetPos = player.transform.position;

        var pScr = player.GetComponent<PlayerScr2D>();


        if (GetComponent<EnemyBase>().enemyData.moveType == EnemyData.MoveType.CircleMove)
            //using UniRx必要
            pScr.prePosDiff.Subscribe(prePosDiff => UpdatePos(pScr));
    }

    void UpdatePos(PlayerScr2D p)
    {
        transform.position += p.GetComponent<PlayerScr2D>().prePosDiff.Value;

        targetPos = p.transform.position;
    }

    public override void OnEnter()
    {
        stateTime = 0f;
        moveSaveTime = 0f;


        //m_rb.linearVelocity = Vector3.zero;

    }

    public override void OnExit()
    {

    }

    public override int StateUpdate()
    {
        stateTime += Time.deltaTime;
        moveSaveTime += Time.deltaTime;

        if (GetComponent<EnemyBase>().IsDamage)
        {
            return (int)BaseJerryCtr.State.BaseJerry_Damage;
        }



        //Vector3 movement = transform.up * Time.deltaTime * GetComponent<EnemyBase>().enemyData.Speed;

        //movement.z = 0;
        //
        //m_rb.MovePosition(m_rb.position + movement);



        ////回転
        //const float INTERPOLANT = 5f;

        //Vector3 targetDirection = targetPos - transform.position;

        ////2D　Vector3.forward→Vector3.up
        //Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, targetDirection.normalized);

        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, INTERPOLANT * Time.deltaTime);



        //ターゲットとの距離は初期位置で決まる！！
        var tr = transform;
        // 回転のクォータニオン作成
        var angleAxis = Quaternion.AngleAxis(360 / _period * Time.deltaTime, _axis);

        // 円運動の位置計算
        var pos = tr.position;

        pos -= targetPos;
        pos = angleAxis * pos;
        pos += targetPos;

        //
        //var leftVec = -transform.right * 0.8f;
        //
        tr.position = pos;


        //float offsetX = 0.1f;

        // 向き更新
        if (_updateRotation)
        {
            tr.rotation = tr.rotation * angleAxis;
        }



        //float len = Vector3.Distance(transform.position, targetPos);
        //if (len < ENDMOVELEN)
        //{
        //    return (int)SlimeCtr.State.Slime_Wait;
        //}


        if (moveSaveTime > GetComponent<EnemyBase>().enemyData.AtkInterval)
        {
            moveSaveTime = 0;

            return GetComponent<BaseJerryScr>().ReturnStateMoveType(StateType);

        }

        return (int)StateType;

    }


}
