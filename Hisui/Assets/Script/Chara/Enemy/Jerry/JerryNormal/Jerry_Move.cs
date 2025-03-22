using DG.Tweening;
using UniRx;
using UnityEngine;
using static BaseMove;
using static UnityEngine.ParticleSystem;


public class Jerry_Move : StateChildBase
{
    //[HideInInspector]
    //public bool IsKeepMove = false;

    BaseMove move;
    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

        move = GetComponent<EnemyBase>().move;
        move.Initialize();
    }

    public override void OnEnter()
    {
        stateTime = 0f;

        //if (this.GetType().FullName == MoveType.PointFloatMove.ToString())
        //{
        //    Debug.Log("成功");

        //    var trailSe= (GameObject)Resources.Load("Prefab/Sound/JerryTrailSe");
        //    //トレイルサウンド用
        //    var seObj = Instantiate(trailSe, trailSe.transform.position, Quaternion.identity, transform);
        //    seObj.GetComponent<AudioSource>().Play();

        //    var pMove = (PointFloatMove)GetComponent<JerryScr>().move;
        //    //var pFloatMove = GetComponent<PointFloatMove>();
        //    pMove.isPointMoveEnd.Skip(1).Subscribe(pointBool =>
        //    {
        //        const float fadeSpeed = 1f;//1秒で止まる
        //        seObj.GetComponent<AudioSource>().DOFade(0, fadeSpeed);

        //        GetComponent<EnemyBase>().SetEndMoveKeep();
        //        GetComponent<TrailRenderer>().material.DOFade(endValue: 0, duration: 1f);

        //    });

        //    //子階層から取得？
        //    //pMove.TargetSet(movePoint);
        //}

        move.MoveEnter();

    }

    public override void OnExit()
    {
        //stateTime = 0;
    }

    public override int StateUpdate()
    {
        stateTime += Time.deltaTime;

        if (GetComponent<EnemyBase>().IsDamage)
            if (GetComponent<EnemyBase>().ReturnStateTypeDead())
                return (int)JerryCtr.State.Jerry_Dead;


        //移動の更新
        move.MoveUpdate();


        if (GetComponent<JerryScr>().AtkInterval <= 0|| !GetComponent<JerryScr>().IsMove)
        {

            return (int)GetComponent<JerryScr>().JerryReturnStateType(StateType);
        }
            


        return StateType;

    }
}
