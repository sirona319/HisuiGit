using DG.Tweening;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PointMoveJerry : MonoBehaviour
{

    [SerializeField] bool trailDisable = false;


    [SerializeField] List<Transform> moveTrans;
    //[SerializeField] List<Vector3> moveVecs = new();
    [SerializeField] List<float> endLength;
    [SerializeField] float speed = 1f;
    const float rotSpeed = 5f;

    [SerializeField] bool isLoop = false;
    public ReactiveProperty<bool> isPointMoveEnd = new ReactiveProperty<bool>(false);//CreateMoveでSubscribe　エネミークラスなど？

    int targetNo = 0;
    Rigidbody2D rb2;

    //TargetSet targetSet;


    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();

        var targetSet = GetComponent<TargetSet>();
        moveTrans = targetSet.SetPointArray(moveTrans);     //配列を作成

        var trailSe = (GameObject)Resources.Load("Prefab/Sound/JerryTrailSe");
        //トレイルサウンド用
        var seObj = Instantiate(trailSe, trailSe.transform.position, Quaternion.identity, transform);
        seObj.GetComponent<AudioSource>().Play();

        //var pFloatMove = GetComponent<PointFloatMove>();
        isPointMoveEnd.Skip(1).Subscribe(pointBool =>
        {
            Debug.Log("移動終了");
            const float fadeSpeed = 1f;//1秒で止まる
            seObj.GetComponent<AudioSource>().DOFade(0, fadeSpeed);

            //GetComponent<EnemyBase>().SetIsAttack();
            //GetComponent<EnemyBase>().MoveEnd();

            if (!trailDisable)
                GetComponent<TrailRenderer>().material.DOFade(endValue: 0, duration: 1f);

        });
    }

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

    void Update()
    {

        PointUpdate();

        rb2.MovePosition(rb2.position + (Vector2)transform.up * speed * Time.deltaTime);

    }

    void PointUpdate()
    {
        float len = Vector3.Distance(transform.position, moveTrans[targetNo].position);
        if (len < endLength[targetNo])
        {

            targetNo++;
            if (targetNo > moveTrans.Count - 1)
            {

                //if (!IsKeepMove)
                isPointMoveEnd.Value = true;

                if (isLoop)
                    targetNo = 0;
                else
                    targetNo--;
            }

        }

        transform.rotation = MyLib.GetAngleRotationFuncs(moveTrans[targetNo].position, transform, rotSpeed);

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
