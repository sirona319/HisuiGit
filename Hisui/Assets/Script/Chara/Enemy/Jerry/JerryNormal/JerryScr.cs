using UnityEngine;

public class JerryScr : EnemyBase
{

    void Start()
    {
        base.Init();
        stateController.Initialize((int)JerryCtr.State.Jerry_Wait);
    }

    void Update()
    {
        //stateController.AutoStateTransitionSequence(0);

        AttackTimeUpdate();

        stateController.UpdateSequence();

        //if (!IsMove && enemyData.isFloat)
        //    MyLib.LoopMotionSinVector(transform, floatSpeed, enemyData.flaotVector);

    }


    void AttackTimeUpdate()
    {
        if (!IsAttack) return;

        AtkInterval -= Time.deltaTime;


    }

    public int JerryReturnStateType(int stateType)
    {
        if (AtkInterval <= 0)
            return (int)JerryCtr.State.Jerry_Attack;
        else if (IsMove)
            return (int)JerryCtr.State.Jerry_Move;
        else
            return (int)JerryCtr.State.Jerry_Wait;

    }

    float IntensityVal = 1;
    const float TrailEndSpeed = 0.02f;

    //Emission
    public void SetEndTrail()
    {
        var color=GetComponent<TrailRenderer>().material.GetColor("_EmissionColor");

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



        StartCoroutine(MyLib.LoopDelayCoroutineIf(Time.deltaTime, IntensityVal > 0, () =>
        {
            IntensityVal -= TrailEndSpeed;//Time.deltaTime;
            if (IntensityVal <= 0)
            {
                IntensityVal = 0;
                //return;
            }


            GetComponent<TrailRenderer>().material.SetColor("_EmissionColor", color * IntensityVal);
        }));

        //GetComponent<TrailRenderer>().material.SetColor("_EmissionColor", color * 0);

        //GetComponent<TrailRenderer>().material.GetColor("_EmissionColor");


        //GetComponent<TrailRenderer>().enabled = false;
        //if (!moveEnd) return;
        //GetComponent<JerryScr>().IsAttack = true;

        //GetComponent<JerryScr>().IsMove = true;

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
