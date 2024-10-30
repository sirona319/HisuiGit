//using DG.Tweening;
//using UnityEngine;
//using UnityEngine.AI;

//public class RodScript : EnemyBase
//{
//    private Animator animator;
//    //private int hitCount = 0;//殴った回数
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

//        // Nav Mesh Agent を取得します。
//        myAgent = GetComponent<NavMeshAgent>();
//        // autoBraking を無効にすると、目標地点の間を継続的に移動します
//        //(つまり、エージェントは目標地点に近づいても速度をおとしません)
//        myAgent.autoBraking = false;
//        speedAgent = myAgent.speed;

//        pTrans = GameObject.FindGameObjectWithTag("Player").transform;
//        myAgent.destination = pTrans.position;


//        //animator.SetFloat("Speed", 1);

//        const float MOVERESETTIME = 1f;
//        StartCoroutine(MyLib.LoopDelayCoroutine(MOVERESETTIME, () =>
//        {
//            //スタック対処のため定期的にプレイヤーの座標を登録
//            myAgent.destination = pTrans.position;
//        }));
//    }

//    void Update()
//    {

//        //stateController.UpdateSequence();

//        //目標地点に近づいたら次の目標地点を選択
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

//        Debug.Log("エネミー攻撃処理　CallFunc");
//        //攻撃コリジョンを有効にする
//        m_hitCol.enabled = true;

//    }

//    public void EnemyAttackEnd()
//    {
//        Debug.Log("エネミー攻撃終了処理　CallFunc");

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

    //    hpPoint -= damage;        //HP減少処理
    //    m_isDamage = true;

    //    const float DAMAGETIME = 0.5f;
    //    //コルーチンの起動
    //    StartCoroutine(MyLib.DelayCoroutine(DAMAGETIME, () =>
    //    {
    //        m_isDamage = false;
    //    }));


    //    //オブジェクトを揺らしオン
    //    EnemyShake(0.25f, 0.1f);

    //    //壊れたかどうかの判定
    //    if (hpPoint <= 0 && !IsDead /*&& largeValue > 1.5f*/)
    //    {
    //        //パーティクル生成
    //        //Instantiate(particleBreak.gameObject, this.transform.position, Quaternion.identity);

    //        MyLib.MyPlayOneSound("SE/" + "重いパンチ1", 0.05f, gameObject);

    //        IsDead = true;            //死亡判定

    //        GetComponent<DissolveEffect>().DissolveOut();//ディゾルブ効果オン
    //        //コルーチンの起動
    //        const float DAEDTIME = 1f;
    //        StartCoroutine(MyLib.DelayCoroutine(DAEDTIME, () =>
    //        {
    //            gameObject.SetActive(false);
    //            SanctuaryControl.I.UpdateEnemyCount();
    //        }));


    //    }
    //    else
    //    {
    //        MyLib.MyPlayOneSound("SE/" + "軽いキック1 1", 0.05f, gameObject);
    //    }

    //}

    //public void EnemyDamageEffect(int damage)
    //{
    //    if (IsDead) return;
    //    if (m_isDamageEffect) return;


    //    //HP減少処理
    //    hpPoint -= damage;
    //    m_isDamageEffect = true;

    //    const float DAMAGETIME = 0.5f;
    //    //コルーチンの起動
    //    StartCoroutine(MyLib.DelayCoroutine(DAMAGETIME, () =>
    //    {
    //        m_isDamageEffect = false;
    //    }));


    //    EnemyShake(0.25f, 0.1f);        //オブジェクトを揺らしオン

    //    //吹き飛ばし処理
    //    var rb = GetComponent<Rigidbody>();
    //    rb.AddForce(-rb.transform.forward * 10, ForceMode.Impulse);

    //    //壊れたかどうかの判定
    //    if (hpPoint <= 0 && !IsDead /*&& largeValue > 1.5f*/)
    //    {
    //        stateController.AutoStateTransitionSequence((int)EnemyStateController.EnemyStateType.EnemyStateChild_Dead);
    //        //パーティクル生成
    //        //Instantiate(particleBreak.gameObject, this.transform.position, Quaternion.identity);

    //        MyLib.MyPlayOneSound("SE/" + "重いパンチ1", 0.05f, gameObject);

    //        IsDead = true;            //死亡判定

    //        GetComponent<DissolveEffect>().DissolveOut();//ディゾルブ効果オン
    //        //コルーチンの起動
    //        const float DAEDTIME = 1f;
    //        StartCoroutine(MyLib.DelayCoroutine(DAEDTIME, () =>
    //        {
    //            gameObject.SetActive(false);
    //            SanctuaryControl.I.UpdateEnemyCount();
    //        }));


    //    }
    //    else
    //    {
    //        MyLib.MyPlayOneSound("SE/" + "軽いキック1 1", 0.05f, gameObject);
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


