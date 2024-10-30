//using DG.Tweening;
//using UnityEngine;
//using UnityEngine.AI;

//public class RodScript : EnemyBase
//{
//    private Animator animator;
//    //private int hitCount = 0;//��������
//   // [SerializeField] int hpPointMax = 100;
//   //[SerializeField] int hpPoint;

//   // bool m_isDamage = false;
//   // bool m_isDamageEffect = false;
//   // public bool IsDead { get; private set; } = false;
//    //private ParticleSystem particleBreak;


//    const float ENEMYATKINTERVAL = 1.5f;
//    bool isEnemyAtkInterval = false;
//    //[SerializeField] BoxCollider m_hitCol;


//    NavMeshAgent myAgent;
//    Transform pTrans;
//    float speedAgent;

//    protected override void Start()
//    {
//        //stateController.Initialize(0);

//        animator = GetComponentInParent<Animator>();
//        hpPoint = hpPointMax;

//        //particleBreak = MyLib.GetComponentLoad<ParticleSystem>("Prefab/DustExplosion");

//        // Nav Mesh Agent ���擾���܂��B
//        myAgent = GetComponent<NavMeshAgent>();
//        // autoBraking �𖳌��ɂ���ƁA�ڕW�n�_�̊Ԃ��p���I�Ɉړ����܂�
//        //(�܂�A�G�[�W�F���g�͖ڕW�n�_�ɋ߂Â��Ă����x�����Ƃ��܂���)
//        myAgent.autoBraking = false;
//        speedAgent = myAgent.speed;

//        pTrans = GameObject.FindGameObjectWithTag("Player").transform;
//        myAgent.destination = pTrans.position;


//        //animator.SetFloat("Speed", 1);

//        const float MOVERESETTIME = 1f;
//        StartCoroutine(MyLib.LoopDelayCoroutine(MOVERESETTIME, () =>
//        {
//            //�X�^�b�N�Ώ��̂��ߒ���I�Ƀv���C���[�̍��W��o�^
//            myAgent.destination = pTrans.position;
//        }));
//    }

//    void Update()
//    {

//        //stateController.UpdateSequence();

//        //�ڕW�n�_�ɋ߂Â����玟�̖ڕW�n�_��I��
//        if (!myAgent.pathPending && myAgent.remainingDistance < 3.5f)
//        {
//            myAgent.speed = 0f;
//            animator.SetFloat("Speed", 0);

//            if (!isEnemyAtkInterval)
//                animator.SetBool("Attack", true);
//        }
//        else
//        {
//            if (!animator.GetBool("Attack"))
//            {
//                myAgent.speed = speedAgent;
//                animator.SetFloat("Speed", 1);
//            }


//        }
//    }

//    public void EnemyAttackDamage()
//    {

//        Debug.Log("�G�l�~�[�U�������@CallFunc");
//        //�U���R���W������L���ɂ���
//        m_hitCol.enabled = true;

//    }

//    public void EnemyAttackEnd()
//    {
//        Debug.Log("�G�l�~�[�U���I�������@CallFunc");

//        m_hitCol.enabled = false;

//        myAgent.destination = pTrans.position;
//        myAgent.speed = speedAgent;


//        animator.SetBool("Attack", false);
//        isEnemyAtkInterval = true;
//        StartCoroutine(MyLib.LoopDelayCoroutine(ENEMYATKINTERVAL, () =>
//        {
//            isEnemyAtkInterval = false;
//        }));
//    }

    //public void EnemyDamage(int damage)
    //{
    //    if (stateController.CurrentState == (int)EnemyStateController.EnemyStateType.EnemyStateChild_Dead)
    //        return;

    //    if (IsDead) return;
    //    if (m_isDamage) return;

    //    hpPoint -= damage;        //HP��������
    //    m_isDamage = true;

    //    const float DAMAGETIME = 0.5f;
    //    //�R���[�`���̋N��
    //    StartCoroutine(MyLib.DelayCoroutine(DAMAGETIME, () =>
    //    {
    //        m_isDamage = false;
    //    }));


    //    //�I�u�W�F�N�g��h�炵�I��
    //    EnemyShake(0.25f, 0.1f);

    //    //��ꂽ���ǂ����̔���
    //    if (hpPoint <= 0 && !IsDead /*&& largeValue > 1.5f*/)
    //    {
    //        //�p�[�e�B�N������
    //        //Instantiate(particleBreak.gameObject, this.transform.position, Quaternion.identity);

    //        MyLib.MyPlayOneSound("SE/" + "�d���p���`1", 0.05f, gameObject);

    //        IsDead = true;            //���S����

    //        GetComponent<DissolveEffect>().DissolveOut();//�f�B�]���u���ʃI��
    //        //�R���[�`���̋N��
    //        const float DAEDTIME = 1f;
    //        StartCoroutine(MyLib.DelayCoroutine(DAEDTIME, () =>
    //        {
    //            gameObject.SetActive(false);
    //            SanctuaryControl.I.UpdateEnemyCount();
    //        }));


    //    }
    //    else
    //    {
    //        MyLib.MyPlayOneSound("SE/" + "�y���L�b�N1 1", 0.05f, gameObject);
    //    }

    //}

    //public void EnemyDamageEffect(int damage)
    //{
    //    if (IsDead) return;
    //    if (m_isDamageEffect) return;


    //    //HP��������
    //    hpPoint -= damage;
    //    m_isDamageEffect = true;

    //    const float DAMAGETIME = 0.5f;
    //    //�R���[�`���̋N��
    //    StartCoroutine(MyLib.DelayCoroutine(DAMAGETIME, () =>
    //    {
    //        m_isDamageEffect = false;
    //    }));


    //    EnemyShake(0.25f, 0.1f);        //�I�u�W�F�N�g��h�炵�I��

    //    //������΂�����
    //    var rb = GetComponent<Rigidbody>();
    //    rb.AddForce(-rb.transform.forward * 10, ForceMode.Impulse);

    //    //��ꂽ���ǂ����̔���
    //    if (hpPoint <= 0 && !IsDead /*&& largeValue > 1.5f*/)
    //    {
    //        stateController.AutoStateTransitionSequence((int)EnemyStateController.EnemyStateType.EnemyStateChild_Dead);
    //        //�p�[�e�B�N������
    //        //Instantiate(particleBreak.gameObject, this.transform.position, Quaternion.identity);

    //        MyLib.MyPlayOneSound("SE/" + "�d���p���`1", 0.05f, gameObject);

    //        IsDead = true;            //���S����

    //        GetComponent<DissolveEffect>().DissolveOut();//�f�B�]���u���ʃI��
    //        //�R���[�`���̋N��
    //        const float DAEDTIME = 1f;
    //        StartCoroutine(MyLib.DelayCoroutine(DAEDTIME, () =>
    //        {
    //            gameObject.SetActive(false);
    //            SanctuaryControl.I.UpdateEnemyCount();
    //        }));


    //    }
    //    else
    //    {
    //        MyLib.MyPlayOneSound("SE/" + "�y���L�b�N1 1", 0.05f, gameObject);
    //        //Debug.Log("HIT" + hitCount);
    //    }

    //}

    //public void EnemyShake(float duration, float magnitude)
    //{
    //    StartCoroutine(EnemyDoShake(duration, magnitude));
    //}

    //private IEnumerator EnemyDoShake(float duration, float magnitude)
    //{
    //    var pos = transform.localPosition;

    //    var elapsed = 0f;

    //    while (elapsed < duration)
    //    {
    //        var x = pos.x + Random.Range(-1f, 1f) * magnitude;
    //        var z = pos.z + Random.Range(-1f, 1f) * magnitude;

    //        transform.localPosition = new Vector3(x, pos.y, z);

    //        elapsed += Time.deltaTime;

    //        yield return null;
    //    }

    //    transform.localPosition = pos;
    //}


//}


