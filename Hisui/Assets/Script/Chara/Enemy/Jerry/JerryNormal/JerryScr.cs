using DG.Tweening;
using UnityEngine;

public class JerryScr : EnemyBase
{
    #region ステートコントローラー
    [SerializeField] protected StateControllerBase stateController = default;

    public int GetState()
    {
        return stateController.CurrentState;
    }
    #endregion

    public BaseMagazine atkMagazine = null;
    //public List<BaseMove> baseMove = new ();
    public BaseMove move = null;
    public BaseMove atkMove = null;

    public bool IsDamage { get; set; } = false;

    public bool IsAttack = false;

    public bool IsMove = true;
    void Start()
    {
        //base.Init();
        stateController.Initialize((int)JerryCtr.State.Jerry_Wait);

        if (atkMagazine != null)
            atkMagazine.Initialize();

        if (atkMove != null)
            atkMove.Initialize();

        if (move != null)
            move.Initialize();
    }

    void Update()
    {
        //stateController.AutoStateTransitionSequence(0);

        //AttackTimeUpdate();

        stateController.UpdateSequence();

        //if (!IsMove && enemyData.isFloat)
        //    MyLib.LoopMotionSinVector(transform, floatSpeed, enemyData.flaotVector);

    }


    //void AttackTimeUpdate()
    //{
    //    if (!IsAttack) return;

    //    AtkInterval -= Time.deltaTime;


    //}

    public int JerryReturnStateType(int stateType)
    {
        if (IsAttack)
            return (int)JerryCtr.State.Jerry_Attack;
        else if (IsMove)
            return (int)JerryCtr.State.Jerry_Move;
        else
            return (int)JerryCtr.State.Jerry_Wait;

    }

    //float IntensityVal = 1;
    //const float TrailEndSpeed = 0.02f;

    //Emission
    public void SetEndTrail()
    {
        //var color=GetComponent<TrailRenderer>().material.GetColor("_EmissionColor");

        //StartCoroutine(MyLib.LoopDelayCoroutine(Time.deltaTime, () =>
        //{
        //    IntensityVal -= TrailEndSpeed;//Time.deltaTime;
        //    if (IntensityVal <= 0)
        //    {
        //        IntensityVal = 0;
        //        //return;
        //    }


        //    GetComponent<TrailRenderer>().material.SetColor("_EmissionColor", color * IntensityVal);
        //}));

        GetComponent<TrailRenderer>().material.DOFade(endValue: 0, duration:1f);

        //StartCoroutine(MyLib.LoopDelayCoroutineIf(Time.deltaTime, IntensityVal > 0, () =>
        //{
        //    IntensityVal -= TrailEndSpeed;//Time.deltaTime;
        //    if (IntensityVal <= 0)
        //    {
        //        IntensityVal = 0;
        //        //return;
        //    }

 
        //    GetComponent<TrailRenderer>().material.SetColor("_EmissionColor", color * IntensityVal);
        //}));

        //GetComponent<TrailRenderer>().material.SetColor("_EmissionColor", color * 0);

        //GetComponent<TrailRenderer>().material.GetColor("_EmissionColor");


        //GetComponent<TrailRenderer>().enabled = false;
        //if (!moveEnd) return;
        //GetComponent<JerryScr>().IsAttack = true;

        //GetComponent<JerryScr>().IsMove = true;

    }

    public bool ReturnStateTypeDead()
    {
        //const int DEAD = 2;
        if (GetComponent<CharaBase>().isDead) return true;

        //const int DAMAGESTATE = 1;
        //return DAMAGESTATE;
        return false;

    }

    public void SetEndMoveKeep()
    {
        //if (!moveEnd) return;
        IsAttack = true;

        IsMove = true;

    }

    public void SetIsAttack()
    {
        IsAttack = true;
    }
    public void MoveEnd()
    {
        IsMove = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            //プレイヤーへのダメージ処理
            other.transform.GetComponent<PlayerScr2D>().PlayerDamage(1);

            Debug.Log("攻撃がPlayerにHIT Enemyに当たった");

            //PoolDestroy();
            return;
        }

    }

}
