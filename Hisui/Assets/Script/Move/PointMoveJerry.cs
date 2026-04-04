using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class PointMoveJerry : BaseMove
{

    [SerializeField] bool isTrailLoop = false;
    const float rotSpeed = 5f;


    [SerializeField] List<Transform> moveTrans;

    [SerializeField] List<float> endLength;
    [SerializeField][Range(1f, 20f)] float speed = 1f;

    [SerializeField] bool isLoop = false;
    //public ReactiveProperty<bool> isPointMoveEnd = new ReactiveProperty<bool>(false);//CreateMoveでSubscribe　エネミークラスなど？

    int targetNo = 0;
    Rigidbody2D rb2;


    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();

        moveTrans = TargetSet.I.SetPointArray(moveTrans,gameObject);
        //moveTrans = GetComponent<TargetSet>().SetPointArray(moveTrans);//.SetPointArray(moveTrans);     //配列を作成

        //Debug.Log("moveTransの数" + moveTrans.Count);

        GetComponent<SoundMove>().SoundPlay();

    }

    //private void OnEnable()
    //{
    //}

    //public override void MoveEnter()
    //{

    //    //var trailSe = (GameObject)Resources.Load("Prefab/Sound/JerryTrailSe");
    //    ////トレイルサウンド用
    //    //var seObj = Instantiate(trailSe, trailSe.transform.position, Quaternion.identity, transform);
    //    //seObj.GetComponent<AudioSource>().Play();

    //    ////var pFloatMove = GetComponent<PointFloatMove>();
    //    //isPointMoveEnd.Skip(1).Subscribe(pointBool =>
    //    //{
    //    //    Debug.Log("移動終了");
    //    //    const float fadeSpeed = 1f;//1秒で止まる
    //    //    seObj.GetComponent<AudioSource>().DOFade(0, fadeSpeed);

    //    //    GetComponent<EnemyBase>().SetIsAttack();
    //    //    GetComponent<EnemyBase>().MoveEnd();

    //    //    if (!trailDisable)
    //    //        GetComponent<TrailRenderer>().material.DOFade(endValue: 0, duration: 1f);

    //    //});
    //}

    private void FixedUpdate()
    {
        PointUpdate();

        rb2.MovePosition(rb2.position + (Vector2)transform.up * (speed * Time.fixedDeltaTime));

    }

    void PointUpdate()
    {
        float len = Vector2.Distance(rb2.position, moveTrans[targetNo].position);
        if (len < endLength[targetNo])
        {

            targetNo++;
            if (targetNo > moveTrans.Count - 1)
            {
                //GetComponent<SoundMove>().SoundFadeStop();

                if (GetComponent<FloatMoveJerry>() != null)
                {
                    Debug.Log("PointMoveJerryからFloatMoveJerryに移行");
                    GetComponent<SoundMove>().SoundFadeStop();
                    GetComponent<FloatMoveJerry>().enabled = true;
                    GetComponent<BaseMagazine>().enabled = true;
                    this.enabled = false;
                }

                if (!isTrailLoop)
                    GetComponent<TrailRenderer>().material.DOFade(endValue: 0, duration: 1f);

                if (isLoop)
                    targetNo = 0;
                else
                    targetNo--;
            }

        }


        transform.rotation = MyLib.GetAngleRotationFuncs(moveTrans[targetNo].position, transform, rotSpeed);

    }

    public override void MoveEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void MoveUpdate()
    {
        throw new System.NotImplementedException();
    }

    //private void OnTriggerExit2D(Collider2D other)
    //{

    //    if (other.CompareTag("ExitErea"))
    //    {
    //        if (gameObject.tag == "Enemy")
    //        {
    //            Debug.Log("ExitEreaから外れた  SoundCreateDead");
    //            //gameObject.GetComponent<SoundCreateDead>().IsSoundEnable = false;
    //            gameObject.transform.GetComponent<CharaBase>().isDead=true;
    //            return;
    //        }

    //    }

    //}
    //public override void MoveEnter()
    //{
    //    base.MoveEnter();

    //    var trailSe = (GameObject)Resources.Load("Prefab/Sound/JerryTrailSe");
    //    //トレイルサウンド用
    //    var seObj = Instantiate(trailSe, trailSe.transform.position, Quaternion.identity, transform);
    //    seObj.GetComponent<AudioSource>().Play();

    //    //var pFloatMove = GetComponent<PointFloatMove>();
    //    isPointMoveEnd.Skip(1).Subscribe(pointBool =>
    //    {
    //        Debug.Log("移動終了");
    //        const float fadeSpeed = 1f;//1秒で止まる
    //        seObj.GetComponent<AudioSource>().DOFade(0, fadeSpeed);

    //        GetComponent<EnemyBase>().SetIsAttack();
    //        GetComponent<EnemyBase>().MoveEnd();

    //        if(!trailDisable)
    //            GetComponent<TrailRenderer>().material.DOFade(endValue: 0, duration: 1f);

    //    });

    //}

    //移行する?s

}
