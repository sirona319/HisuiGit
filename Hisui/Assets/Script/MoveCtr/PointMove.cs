using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PointMove : BaseMove
{
    //[SerializeField] List<Vector3> moveVecs = new();
    //[SerializeField] float[] endLength;
    //[SerializeField] float speed = 4f;
    //const float rotSpeed = 5f;

    //[SerializeField] bool isLoop = false;
    //public ReactiveProperty<bool> isPointMoveEnd = new ReactiveProperty<bool>(false);//CreateMoveでSubscribe　エネミークラスなど？

    //int targetNo = 0;
    //Rigidbody2D rb2;

    //TargetSet targetSet;

    ////GameObject trailSe;


    ////public void TargetSet(Transform[] t)
    ////{
    ////    targets = t;

    ////    if (targets.Length <= 0)
    ////        throw new System.Exception(transform.name + "PointMoveムーブポイント未設定");
    ////}

    //public override void Initialize()
    //{
    //    rb2 = GetComponent<Rigidbody2D>();

    //    //foreach (Transform t in moveTrans)
    //    //{
    //    //    moveVecs.Add(t.position);
    //    //}
    //    targetSet = GetComponent<TargetSet>();
    //    moveVecs = targetSet.SetArrayVec();     //配列を作成
    //}

    //public override void MoveEnter()
    //{
    //    //このクラスを継承してPointMoveJerryなどに移行？＊＊＊

    //    //var trailSe = (GameObject)Resources.Load("Prefab/Sound/JerryTrailSe");
    //    ////トレイルサウンド用
    //    //var seObj = Instantiate(trailSe, trailSe.transform.position, Quaternion.identity, transform);
    //    //seObj.GetComponent<AudioSource>().Play();

    //    ////var pFloatMove = GetComponent<PointFloatMove>();
    //    //isPointMoveEnd.Skip(1).Subscribe(pointBool =>
    //    //{
    //    //    const float fadeSpeed = 1f;//1秒で止まる
    //    //    seObj.GetComponent<AudioSource>().DOFade(0, fadeSpeed);

    //    //    GetComponent<EnemyBase>().SetEndMoveKeep();
    //    //    GetComponent<TrailRenderer>().material.DOFade(endValue: 0, duration: 1f);

    //    //});

    //    //****
    //}

    //public override void MoveUpdate()
    //{
    //    //if (isPointMoveEnd.Value)
    //    //{
    //    //    //Debug.Log("ポイントムーブ終了　Subscribe");
    //    //    //ポイントムーブ終了　Subscribe
    //    //    //enabled = false;
    //    //}
    //    //else
    //    //{
    //    //    PointUpdate();
    //    //}
    //    PointUpdate();

    //    rb2.MovePosition(rb2.position + (Vector2)transform.up * speed * Time.deltaTime);

    //}


    ////Vector2 velocity = Vector2.zero;
    //void PointUpdate()
    //{
    //    float len = Vector3.Distance(transform.position, moveVecs[targetNo]);
    //    if (len < endLength[targetNo])
    //    {

    //        targetNo++;
    //        if (targetNo > moveVecs.Count - 1)
    //        {

    //            //if (!IsKeepMove)
    //            isPointMoveEnd.Value = true;

    //            if (isLoop)
    //                targetNo = 0;
    //            else
    //                targetNo--;
    //        }

    //    }

    //    transform.rotation = MyLib.GetAngleRotationFuncs(moveVecs[targetNo], transform, rotSpeed);

    //}


    ////移行する?s
    //private void OnTriggerExit2D(Collider2D other)
    //{

    //    if (other.CompareTag("ExitErea"))
    //    {
    //        if (gameObject.tag == "Enemy")
    //        {
    //            gameObject.GetComponent<CreateDeadSound>().IsSoundEnable = false;
    //            gameObject.transform.GetComponent<EnemyBase>().EnemyDamage(10);
    //            return;
    //        }

    //    }

    //}







    [SerializeField] List<Transform> moveTrans;
    //[SerializeField] List<Vector3> moveVecs = new();
    [SerializeField] List<float> endLength;
    [SerializeField] float speed = 4f;
    const float rotSpeed = 5f;

    [SerializeField] bool isLoop = false;
    public ReactiveProperty<bool> isPointMoveEnd = new ReactiveProperty<bool>(false);//CreateMoveでSubscribe　エネミークラスなど？

    int targetNo = 0;
    Rigidbody2D rb2;

    TargetSet targetSet;


    public override void Initialize()
    {
        rb2 = GetComponent<Rigidbody2D>();

        //foreach (Transform t in moveTrans)
        //{
        //    moveVecs.Add(t.position);
        //}
        targetSet = GetComponent<TargetSet>();
        targetSet.SetPointArray(endLength,moveTrans);     //配列を作成
    }

    public override void MoveEnter()
    {
        //このクラスを継承してPointMoveJerryなどに移行？＊＊＊

        //var trailSe = (GameObject)Resources.Load("Prefab/Sound/JerryTrailSe");
        ////トレイルサウンド用
        //var seObj = Instantiate(trailSe, trailSe.transform.position, Quaternion.identity, transform);
        //seObj.GetComponent<AudioSource>().Play();

        ////var pFloatMove = GetComponent<PointFloatMove>();
        //isPointMoveEnd.Skip(1).Subscribe(pointBool =>
        //{
        //    const float fadeSpeed = 1f;//1秒で止まる
        //    seObj.GetComponent<AudioSource>().DOFade(0, fadeSpeed);

        //    GetComponent<EnemyBase>().SetEndMoveKeep();
        //    GetComponent<TrailRenderer>().material.DOFade(endValue: 0, duration: 1f);

        //});

        //****
    }

    public override void MoveUpdate()
    {
        //if (isPointMoveEnd.Value)
        //{
        //    //Debug.Log("ポイントムーブ終了　Subscribe");
        //    //ポイントムーブ終了　Subscribe
        //    //enabled = false;
        //}
        //else
        //{
        //    PointUpdate();
        //}
        PointUpdate();

        rb2.MovePosition(rb2.position + (Vector2)transform.up * speed * Time.deltaTime);

    }


    //Vector2 velocity = Vector2.zero;
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


    //移行する?s
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("ExitErea"))
        {
            if (gameObject.tag == "Enemy")
            {
                gameObject.GetComponent<CreateDeadSound>().IsSoundEnable = false;
                gameObject.transform.GetComponent<EnemyBase>().EnemyDamage(10);
                return;
            }

        }

    }
}
