using UnityEngine;
using UniRx;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;
public class CircleMove : BaseMove
{
    //https://nekojara.city/unity-circular-motion


    // ���S�_
    [SerializeField] private Vector3 targetPos = Vector3.zero;

    // ��]��
    [SerializeField] private Vector3 _axis = Vector3.forward;

    // �~�^������
    [SerializeField] private float _period = 2;

    // �������X�V���邩�ǂ���
    [SerializeField] private bool _updateRotation = true;


    Transform targetTrans;

    public override void Initialize()
    {
        base.Initialize();

        var player = GameObject.FindGameObjectWithTag("Player");

        targetPos = player.transform.position;
        targetTrans = player.transform;


        var pScr = player.GetComponent<PlayerScr2D>();

        transform.parent = player.transform;
        //if (GetComponent<EnemyBase>().enemyData.moveType == EnemyData.MoveType.CircleMove)
        //using UniRx�K�v
        //pScr.prePosDiff.Subscribe(prePosDiff => UpdatePos(pScr));
    }

    void UpdatePos(PlayerScr2D p)
    {
        //transform.position += p.GetComponent<PlayerScr2D>().prePosDiff.Value;

        //targetPos = p.transform.position;
    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {
        //�^�[�Q�b�g�Ƃ̋����͏����ʒu�Ō��܂�I�I
        var tr = transform;
        // ��]�̃N�H�[�^�j�I���쐬
        var angleAxis = Quaternion.AngleAxis(360 / _period * Time.deltaTime, _axis);

        // �~�^���̈ʒu�v�Z
        var pos = tr.position;

        pos -= targetTrans.position;
        pos = angleAxis * pos;
        pos += targetTrans.position;


        tr.position = pos;
        m_rb.MovePosition(pos);


        // �����X�V
        if (_updateRotation)
        {
            tr.rotation = tr.rotation * angleAxis;
        }






        // ���S�_center�̎�����A��axis�ŁAperiod�����ŉ~�^��
        //transform.RotateAround(
        //    targetPos,
        //    _axis,
        //    360 / _period * Time.deltaTime
        //);




        ////��]
        const float INTERPOLANT = 5f;

        Vector3 targetDirection = targetTrans.position - transform.position;

        //2D�@Vector3.forward��Vector3.up
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, targetDirection.normalized);


        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, INTERPOLANT * Time.deltaTime);


        Vector3 movement = transform.right * Time.deltaTime * GetComponent<EnemyBase>().enemyData.Speed;

        //2D
        //m_rb.MovePosition(m_rb.position + movement);

        //const float ENDMOVELEN = 3f;
        //float len = Vector3.Distance(transform.position, targetTrans.position);
        //if (len < ENDMOVELEN)
        //{
        //    //�ړ��n�_�̍Đݒ�
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


    private void FixedUpdate()
    {
        //Vector3 movement= Vector3.zero; //= transform.right * Time.deltaTime * GetComponent<EnemyBase>().enemyData.Speed;

        ////2D
        ////m_rb.MovePosition(m_rb.position + movement);

        //const float ENDMOVELEN = 3f;
        //float len = Vector3.Distance(transform.position, targetTrans.position);
        //if (len < ENDMOVELEN)
        //{
        //    //�ړ��n�_�̍Đݒ�
        //    //MoveRandomSet();

        //    //var MoveDir = GameObject.Find("CirclePoint").transform.position;

        //    //movement = transform.right * Time.deltaTime * GetComponent<EnemyBase>().enemyData.Speed;

        //}
        //else
        //{
        //    Vector3 direction = targetTrans.position - transform.position;

        //    //transform.position += direction * 2f * Time.deltaTime;
        //    //movement += direction * 2f * Time.deltaTime;
        //}

        //var MovePos = GameObject.Find("CirclePoint").transform.position;

        //var distance = Vector3.Distance(transform.position, MovePos);
        //float present_Location = (Time.time * 0.1f) / distance;

        //var movePoint= Vector3.Slerp(transform.position, MovePos, present_Location);

        //transform.position = movePoint;
        ////m_rb.MovePosition(movePoint);
        //Debug.Log("Fixed");
    }

}
